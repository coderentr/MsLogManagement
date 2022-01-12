using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ExLogService
{
    public partial class Exlog : ServiceBase
    {
        public Exlog()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var service = new ErrorListener();
            service.DoWork();
        }

        protected override void OnStop()
        {
        }
    }
}
