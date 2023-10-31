using BusinessObjectLayer.CustomerList_DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.LogicServices
{
    public interface IUserLogic
    {
        public bool VerifyUser(UserModel userModel);
    }
}
