using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class Poheader
    {
        public Poheader()
        {
            Poitem = new HashSet<Poitem>();
        }

        public string Ponumber { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? Eta { get; set; }
        public long OrderId { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public ICollection<Poitem> Poitem { get; set; }
    }
}
