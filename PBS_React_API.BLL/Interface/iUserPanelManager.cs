using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBS_React_API.BLL.Interface
{
    public interface iUserPanelManager
    {
        DataSet Delete_User_Address(string addressId, string customerId);
    }
}
