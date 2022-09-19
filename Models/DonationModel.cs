using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GanpatiBappa.Models
{
    public class DonationModel
    {
        public int d_Id { get; set; }
        public string donaterName { get; set; }
        public int donateAmount { get; set; }
        public DateTime donationDate { get; set; }
        public string donationRecievedBy { get; set; }
        public string donationYear { get; set; }
        public string PaymentBy { get; set; }
    }
}