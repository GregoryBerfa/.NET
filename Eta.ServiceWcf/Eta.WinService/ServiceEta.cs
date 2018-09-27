using Eta.ServiceWcf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Eta.WinService
{
    public partial class ServiceEta : ServiceBase
    {

        ServiceHost _host;
        public ServiceEta()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (_host != null) _host.Close();
            _host = new ServiceHost(typeof(EtaService));
            _host.Open();

        }

        protected override void OnStop()
        {
            if (_host != null)
            {
                _host.Close();
                _host = null;
            }
        }
    }
}
