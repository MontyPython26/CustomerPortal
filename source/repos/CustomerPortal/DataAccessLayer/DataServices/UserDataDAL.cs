using BusinessObjectLayer.CustomerList_DbEntities;
using Dapper;
using DataAccessLayer.DataContext;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataServices
{
  
    public class UserDataDAL : IUserDataDAL
    {
        private readonly IDapperORMHelper _dapperORMHelper;

        public UserDataDAL(IDapperORMHelper ldapperORMHelper)
        {
            _dapperORMHelper = ldapperORMHelper;
        }

        public bool VerifyUser(UserModel userModel)
        {
            try
            {
                using (IDbConnection dbConnection = _dapperORMHelper.GetDapperContextHelper())
                {
                    int result = dbConnection.QuerySingleOrDefault<int>("spLoginUser", param: new { username = userModel.Username, password = userModel.PasswordHash }, commandType: CommandType.StoredProcedure);

                    return result == 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
