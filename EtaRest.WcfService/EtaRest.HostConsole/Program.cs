using EtaRest.WcfService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace EtaRest.HostConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(EtaRestService)))
            {
                host.Open();

                Console.ReadKey();
            }
        }
    }
}
