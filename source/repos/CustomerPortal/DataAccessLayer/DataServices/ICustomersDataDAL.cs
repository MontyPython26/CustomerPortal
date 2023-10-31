using BusinessObjectLayer.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataServices
{
    public interface ICustomersDataDAL
    {
        List<CustomerList> GetCustomersListDAL();

        string InsertRecordLogicDAL(CustomerList Formdata);
    }
}
