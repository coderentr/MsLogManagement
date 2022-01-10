using ExceptionLogService.Dtos;
using ExceptionLogService.Models.Context;
using ExceptionLogService.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExceptionLogService.Services
{
    public class LogService : ILogService
    {
        public void Save_Exception_Log_To_Db(ExceptionModel model)
        {
            try
            {
                using (var db = new ExDbContext())
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
                    ActionName = "Save_Exception_Log_To_Db",
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    ServiceName = "LogService",
                };
                Save_Exception_Log_To_Db(exModel);
            }
        }
    }
}
