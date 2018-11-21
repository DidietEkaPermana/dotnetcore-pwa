using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class PoitemDetail
    {
        public long OrderItemDetailId { get; set; }
        public long OrderItemId { get; set; }
        public string Branch { get; set; }
        public int QtyAvailable { get; set; }
        public string ItemDetailStatus { get; set; }
        public DateTime Etadate { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public Poitem OrderItem { get; set; }
    }
}
