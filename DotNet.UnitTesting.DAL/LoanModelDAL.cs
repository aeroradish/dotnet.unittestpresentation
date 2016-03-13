using DotNet.UnitTesting.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace DotNet.UnitTesting.DAL
{
    public class LoanModelDAL : DotNet.UnitTesting.DAL.ILoanModelDAL
    {

        public LoanModel LoanSelectByID(int LoanID)
        {

            LoanModel rc = null;

            using (SqlConnection con = DBUtils.GetConnection())
            {
                con.Open();
                rc = con.Query<LoanModel>("LoanSelectByID",
                    new
                    {
                        LoanID = LoanID
                    },
                    null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }

            return rc;

        }

        public List<LoanModel> LoanSelectAll(int CompanyID)
        {

            List<LoanModel> rc = null;

            using (SqlConnection con = DBUtils.GetConnection())
            {
                con.Open();
                rc = con.Query<LoanModel>("LoanSelectAll",
                    new
                    {
                        CompanyID = CompanyID
                    },
                    null, false, null, CommandType.StoredProcedure).ToList();
            }

            return rc;

        }

        public int LoanCreate(LoanModel loan)
        {
            int retVal = 0;

            using (SqlConnection con = DBUtils.GetConnection())
            {
                con.Open();
                retVal = con.Execute("LoanCreate",
                    new
                    {
                        Amount = loan.Amount,
                        CompanyID = loan.CompanyID,
                        DateBooked = loan.DateBooked,
                        LoanNumber = loan.LoanNumber
                    },
                    null, null, CommandType.StoredProcedure);
            }

            return retVal;
        }

        public int MakePayment(PaymentModel payment)        
        {
            int retVal = 0;

            using (SqlConnection con = DBUtils.GetConnection())
            {
                con.Open();
                retVal = con.Execute("MakePayment",
                    new
                    {
                        Active = payment.LoanID,
                        Description = payment.PaymentAmount,
                        ProjectID = payment.PaymentDate,
                    },
                    null, null, CommandType.StoredProcedure);
            }

            return retVal;
        }
    }
}
