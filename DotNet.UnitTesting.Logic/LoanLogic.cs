using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet.UnitTesting.DAL;
using DotNet.UnitTesting.Models;

namespace DotNet.UnitTesting.Logic
{
    
    public class LoanLogic
    {

        Repository repo = null;

        public LoanLogic()
        {

        }

        public LoanLogic(Repository repo)
        {
            this.repo = repo;
        }

        public bool AttemptPayment(PaymentModel pay)
        {
            LoanModel loan = null;

            loan = repo.iLoanModelDAL.LoanSelectByID(pay.LoanID);

            if (pay.PaymentAmount > loan.Amount)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        public bool CalculatePayment(PaymentModel pay)
        {
            LoanModel loan = null;

            try
            {

                loan = repo.iLoanModelDAL.LoanSelectByID(pay.LoanID);

                if (pay.PaymentAmount > loan.Amount)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Exception newEx = new Exception("TestError");
                throw newEx;
            }

        }

    }
}
