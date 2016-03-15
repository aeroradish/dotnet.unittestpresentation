using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.UnitTesting.DAL
{
    public class Repository
    {
        public Repository()
        {


        }

        public Repository(bool SetDefault)
        {

            if (true == SetDefault)
            {
                this.iLoanModelDAL = new LoanModelDAL();      
            }

        }

        public ILoanModelDAL iLoanModelDAL { get; set; }
    }
}
