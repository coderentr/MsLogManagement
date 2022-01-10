using ExceptionLogService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExceptionLogService
{
    public interface ILogService
    {
        void Save_Exception_Log_To_Db(ExceptionModel model);
    }
}
