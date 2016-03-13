using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.UnitTesting.Models
{
    public class PaymentModel
    {
        public PaymentModel()
        {

        }

        public int PaymentModelID { get; set; }
        public int LoanID { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
