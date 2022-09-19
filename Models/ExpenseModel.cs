using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GanpatiBappa.Models
{
    public class ExpenseModel
    {
        public int e_Id { get; set; }
        public string expenseFor { get; set; }
        public int expenseAmount { get; set; }
        public string expenseBy { get; set; }
        public DateTime expenseDate { get; set; }
        public string expenseYear { get; set; }
    }
}