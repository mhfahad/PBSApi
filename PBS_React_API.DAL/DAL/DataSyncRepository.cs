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
    public class DataSyncRepository : IDataSyncRepository
    {
        private readonly iProjectDataContext _dataContext;

        public DataSyncRepository(iProjectDataContext dataContext)
        {

            _dataContext = dataContext;
        }
        public DataSet GET_AUTOCOMPLETE_DATA_QUICK()
        {
            try
            {
                DataSet ds = _dataContext.GetTransInfo("SP_INFO_SEARCH", "GET_AUTOCOMPLETE_DATA_QUICK_SYCN");
                return ds;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
