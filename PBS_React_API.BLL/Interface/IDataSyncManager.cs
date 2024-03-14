using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBS_React_API.BLL.Interface
{
    public interface IDataSyncManager
    {
        DataSet GET_AUTOCOMPLETE_DATA_QUICK();
        DataTable GET_AUTOCOMPLETE_DATA(DataSet ds, string SerText);
        DataTable Get_Search_Data(DataSet ds, string SerText);
    }
}
