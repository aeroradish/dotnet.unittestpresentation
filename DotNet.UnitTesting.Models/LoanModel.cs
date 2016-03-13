using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.UnitTesting.Models
{
    public class LoanModel
    {
        public LoanModel()
        {

        }

        public int LoanID { get; set; }
        public string LoanNumber { get; set; }
        public int Amount { get; set; }
        public DateTime? DateBooked { get; set; }
        public int CompanyID { get; set; }

    }
}
