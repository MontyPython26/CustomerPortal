using BusinessObjectLayer.NewFolder;
using Dapper;
using DataAccessLayer.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataServices
{
    public class CustomersDataDAL : ICustomersDataDAL
    {
        private readonly IDapperORMHelper _dapperORMHelper;

        public CustomersDataDAL(IDapperORMHelper ldapperORMHelper)
        {
            _dapperORMHelper= ldapperORMHelper;
        }
        public List<CustomerList> GetCustomersListDAL()
        {

            List<CustomerList> customersList = new List<CustomerList>();

            try
            {

                using (IDbConnection dbConnection = _dapperORMHelper.GetDapperContextHelper())
                {
                    string SqlQuery = "SELECT * FROM Customers";
                    customersList = dbConnection.Query<CustomerList>(SqlQuery, commandType: CommandType.Text).ToList();
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;

            }

            return customersList;

             
        }

        public string InsertRecordLogicDAL(CustomerList Formdata)
        {

            string result = string.Empty;

            try
            {

                using (IDbConnection dbConnection = _dapperORMHelper.GetDapperContextHelper())
                {

                    dbConnection.Execute(@"INSERT INTO CUSTOMERS(FirstName,LastName,Email)VALUES(@FirstName,@LastName,@Email)",

                        new
                        {
                            FirstName = Formdata.FirstName,
                            LastName = Formdata.LastName,
                            Email = Formdata.EMail
                        },

                      commandType: CommandType.Text);
                    result = "Saved Successfully"; 
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;

            }

            return result;


        }



    }
}
