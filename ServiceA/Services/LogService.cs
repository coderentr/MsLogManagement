using ServiceA.Interfaces;
using ServiceA.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceA.Entities.Context;
using ServiceA.Entities.Models;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using Newtonsoft.Json;
using System.Text;

namespace ServiceA.Services 
{
    public  class LogService : ILogService
    {
        public void Save_Exception_Log_To_Db(ExceptionModel model)
        {
            try
            {
                using (var db=new MyDbContext())
                {
                    var exModel = new EXCEPTION_LOG
                    {
                        ActionName = model.ActionName,
                        Message = model.Message,
                        ServiceName = model.ServiceName,
                        StackTrace = model.StackTrace,
                        CreatedBy = "cleims.email ets.",
                        CreatedDate = DateTime.Now,
                    };
                    db.Entry(exModel).State = EntityState.Added;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                var exModel = new ExceptionModel
                {
                    ActionName= "Save_Exception_Log_To_Db",
                    Message=ex.Message,
                    StackTrace=ex.StackTrace,
                    ServiceName="LogService",
                };
                Save_Exception_Log_To_Db(exModel);
            }
        }
        public void Produce_Exception_Log_To_RabbitMq(ExceptionModel model)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (IConnection connection = factory.CreateConnection())
                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "Exception_Log_Management_Queue",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);
                    string message = JsonConvert.SerializeObject(model);
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "",
                                         routingKey: "Exception_Log_Management_Queue",
                                         basicProperties: null,
                                         body: body);
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
