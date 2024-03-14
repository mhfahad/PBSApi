using PBS_React_API.BLL.Interface;
using PBS_React_API.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBS_React_API.BLL.BLL
{
    public class UserPanelManager : iUserPanelManager
    {
        private readonly iUserPanelRepository _dataRepository;

        public UserPanelManager(iUserPanelRepository dataRepository)
        {

            _dataRepository = dataRepository;
        }
        public DataSet Delete_User_Address(string addressId, string customerId)
        {
            return _dataRepository.Delete_User_Address(addressId, customerId);
        }
    }
}
