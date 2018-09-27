using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtaRest.Data
{
    public class Review
    {
        public string Description { get; set; }
        public int Id { get; set; }
        public int TrainingId { get; set; }
    }
}
