using ServiceB.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceB.Interfaces
{
    public interface ILogService
    {
        public void Save_Exception_Log_To_ExceptionLogDb(ExceptionModel model);
        public void Produce_Exception_Log_To_RabbitMq(ExceptionModel model);
    }
}
