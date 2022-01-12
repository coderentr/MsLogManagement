using ExlogWorkerService.Models.Context;
using ExlogWorkerService.Models.Dtos;
using ExlogWorkerService.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExlogWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                GetLogsFromRabbitMq();
                await Task.Delay(1000, stoppingToken);
            }
        }

        protected void GetLogsFromRabbitMq()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            List<ExceptionModel> exlogList = new List<ExceptionModel>();
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "Exception_Log_Management_Queue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                var consumer = new EventingBasicConsumer(channel);
                var a = "";
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    ExceptionModel log = JsonConvert.DeserializeObject<ExceptionModel>(message);
                    a = message;
                    SetExLogsToDb(log);
                    exlogList.Add(log);
                };
                channel.BasicConsume(queue: "Exception_Log_Management_Queue", autoAck: true, consumer: consumer);
            }
        }
        public void SetExLogsToDb(ExceptionModel model)
        {
            using (var db = new WorkerDbContext())
            {
                if (model != null)
                {

                    var newItem = new EXCEPTION_LOG
                    {
                        Id = new Guid(),
                        ActionName = model.ActionName,
                        Message = model.Message,
                        ServiceName = model.ServiceName,
                        StackTrace = model.StackTrace,
                        CreatedBy = model.CreatedBy,
                        CreatedDate = model.CreatedDate
                    };
                    db.Entry(newItem).State = EntityState.Added;

                    db.SaveChanges();

                }
            }
        }
    }
}
