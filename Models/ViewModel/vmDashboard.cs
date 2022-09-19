using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GanpatiBappa.Models.ViewModel
{
    public class vmDashboard
    {
        public int TotalDonations { get; set; }
        public int TotalExpenses { get; set; }
        public int TotalSaveAmount { get; set; }
        public int TotalDonaters { get; set; }
        public int highestdonateAmount { get; set; }
        public string highestdonateName { get; set; }
        public int MyProperty { get; set; }
        public int TotalByCash { get; set; }
        public int TotalByOnline { get; set; }
        
    }
}