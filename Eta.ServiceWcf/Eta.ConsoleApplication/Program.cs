using Eta.ServiceWcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Eta.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(EtaService)))
            {
                host.Open();

                Console.ReadKey();
            }
        }
    }
}
