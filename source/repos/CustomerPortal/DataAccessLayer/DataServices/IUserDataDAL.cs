using BusinessObjectLayer.CustomerList_DbEntities;
using BusinessObjectLayer.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataServices
{
    public interface IUserDataDAL
    {
        public bool VerifyUser(UserModel userModel);
    }

}
