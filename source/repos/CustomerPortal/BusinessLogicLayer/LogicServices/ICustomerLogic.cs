using BusinessObjectLayer.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.LogicServices
{
    public interface ICustomerLogic
    {
        List<CustomerList> GetCustomerListLogic();

        string InsertRecordLogic(CustomerList Formdata);

        

    }
}
