using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBS_React_API.DAL.Interface
{
    public interface IDataSyncRepository
    {
        DataSet GET_AUTOCOMPLETE_DATA_QUICK();
    }
}
