using PBS_React_API.DAL.Interface;
using PBS_React_API.DatabaseContext.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBS_React_API.DAL.DAL
{
    public class UserPanelRepository : iUserPanelRepository
    {
        private readonly iProjectDataContext _dataContext;

        public UserPanelRepository(iProjectDataContext dataContext)
        {

            _dataContext = dataContext;
        }
        public DataSet Delete_User_Address(string addressId, string customerId)
        {
            try
            {
                DataSet dResult = _dataContext.GetTransInfo("SP_INFO_USER_PANEL", "UPDATE_CUSTOMER_ADDRESS", addressId, customerId);
                return dResult;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
      
    }
}
