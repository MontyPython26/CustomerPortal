using BusinessObjectLayer.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataServices;



namespace BusinessLogicLayer.LogicServices
{
    public class CustomerLogic : ICustomerLogic
    {
        public readonly ICustomersDataDAL _customersDataDAL;

        public CustomerLogic(ICustomersDataDAL CustomerdataDAL)
        {
            this._customersDataDAL = CustomerdataDAL;

        }
        public List<CustomerList> GetCustomerListLogic()
        {
            List<CustomerList> result = new List<CustomerList>();

            result = _customersDataDAL.GetCustomersListDAL();
            return result;
        }

        public string InsertRecordLogic(CustomerList FormData)
        {
            string result = string.Empty;
            if (String.IsNullOrWhiteSpace(FormData.FirstName) || String.IsNullOrWhiteSpace(FormData.LastName) || String.IsNullOrWhiteSpace(FormData.EMail))
            {
                result = "Please Fill out details";
                return result;
            }

            if (FormData.EMail.StartsWith("ka"))
                {

                result = "Email should not start with ka";
                return result;
            }


            //------Call Data Access Layer to save record----

           result =  _customersDataDAL.InsertRecordLogicDAL(FormData);

            if(result =="Saved Successfully")
            {
                return result;
            }
            else
            {
                result = "An Error Occurred try again";
                return result;
            }

        }




    }

}
