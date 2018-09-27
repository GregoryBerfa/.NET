using Eta.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eta.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new EtaServiceReference.EtaServiceClient())
            {
                var trainings = client.GetTrainings();

                foreach (var item in trainings)
                {
                    Console.WriteLine(item.Name);
                }
                Console.ReadKey();
            }
        }

        public async Task<List<Training>> GetAllTrainingsAsync()
        {
            var client = new EtaServiceReference.EtaServiceClient();
            return await client.GetTrainingsAsync();
        }


    }
}
