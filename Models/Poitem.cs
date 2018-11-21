using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class Poitem
    {
        public Poitem()
        {
            PoitemDetail = new HashSet<PoitemDetail>();
        }

        public long OrderItemId { get; set; }
        public long OrderId { get; set; }
        public string PartNo { get; set; }
        public int QtyOrder { get; set; }
        public int? QtyAvailable { get; set; }
        public string PartDescription { get; set; }
        public string ItemStatus { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public Poheader Order { get; set; }
        public ICollection<PoitemDetail> PoitemDetail { get; set; }
    }
}
