using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Eta.Data
{
    [DataContract]
    public class Training
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Id { get; set; }

    }
}
