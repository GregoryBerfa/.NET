
using EtaRest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace EtaRest.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (HttpClient client = new HttpClient())
            {
                Review review = new Review();
                review.TrainingId = 1;
                review.Description = "ma nouvelle description";
                review.Id = 123;

                var result = client.PostAsXmlAsync<Review>("http://localhost:27999/etarestservice/addreview",
                    review).Result;

            }


            Console.ReadKey();
        }
    }
}
