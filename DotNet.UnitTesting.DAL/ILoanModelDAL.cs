using System;
using DotNet.UnitTesting.Models;
using System.Collections.Generic;

namespace DotNet.UnitTesting.DAL
{
    public interface ILoanModelDAL
    {
        List<LoanModel> LoanSelectAll(int CompanyID);
        LoanModel LoanSelectByID(int LoanID);
        int MakePayment(PaymentModel payment);     
    }
}
