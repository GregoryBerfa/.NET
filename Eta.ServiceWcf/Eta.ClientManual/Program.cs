using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eta.ClientManual
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new ProxyEtaService("BasicHttpBinding_IEtaService"))
            {
                var trainings = client.GetTrainings();

                foreach (var item in trainings)
                {
                    Console.WriteLine(item.Name);
                }
                Console.ReadKey();
            }
        }

    }
}
