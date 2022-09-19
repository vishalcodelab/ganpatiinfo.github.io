using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GanpatiBappa.Models
{
    public class MemberModel
    {
        public int memberId { get; set; }
        public string memberName { get; set; }
        public string memberMobileNo { get; set; }
        public string memberCurrentStatus { get; set; }
        public int memberDonation { get; set; }
        public DateTime memberDonationDate { get; set; }
        public string memberPaymentBy { get; set; }
    }
}