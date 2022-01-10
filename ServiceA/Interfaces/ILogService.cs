using ServiceA.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceA.Interfaces
{
    public interface ILogService
    {
        void Save_Exception_Log_To_Db(ExceptionModel model);
        void Produce_Exception_Log_To_RabbitMq(ExceptionModel model);
    }
}
