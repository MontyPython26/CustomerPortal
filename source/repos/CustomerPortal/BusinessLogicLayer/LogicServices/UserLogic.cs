using BusinessObjectLayer.CustomerList_DbEntities;
using DataAccessLayer.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.LogicServices
{
    public class UserLogic : IUserLogic
    {
        private IUserDataDAL _userDataDAL;
        public UserLogic(IUserDataDAL userDataDAL) 
        { 
            _userDataDAL = userDataDAL;
        }
        public bool VerifyUser(UserModel userModel)
        {
            return _userDataDAL.VerifyUser(userModel);
        }
    }
}
