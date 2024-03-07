using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PBS_React_API.DatabaseContext.Interface;
using PBS_React_API.Model;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PBS_React_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataSyncController : ControllerBase
    {

        private readonly iProjectDataContext _dataContext;

        public DataSyncController( iProjectDataContext dataContext)
        {
           
            _dataContext = dataContext;
        }


        [HttpGet("GET_AUTOCOMPLETE_DATA_QUICK_SYNC")]
        public async Task<APIServiceResponse> GET_AUTOCOMPLETE_DATA_QUICK([FromHeader(Name = "pass")] string pass)
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            try
            {
                DataSet ds = _dataContext.GetTransInfo("TestFahad", "GET_AUTOCOMPLETE_DATA_QUICK_SYCN");
                ds.WriteXml(@"QuickSearchData.xml");

                objResponse.ResponseBusinessData = JsonConvert.SerializeObject("Ok").ToString();
                objResponse.ResponseCode = 200;
                objResponse.SuccessMsg = "DATA SYNC SUCCESSFULLY";

                return objResponse;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("GET_AUTOCOMPLETE_DATA_QUICK")]
        public async Task<APIServiceResponse> GET_AUTOCOMPLETE_DATA([FromHeader(Name = "pass")] string pass,string SerText)
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            try
            {

                DataSet ds1 = new DataSet();
                ds1.ReadXml(@"QuickSearchData.xml");

                DataView dv = new DataView();

                dv.Table = ds1.Tables[0];
                dv.RowFilter = "name like '%" + SerText + "%' or searchingkeyword like '%" + SerText + "%' or NameBN like '%" + SerText + "%' or AuthorNameBn like '%" + SerText + "%' or PublisherNameBN like '%" + SerText + "%'";

                DataTable dt = (dv.ToTable()).Rows.Cast<System.Data.DataRow>().Take(20).CopyToDataTable();

                objResponse.ResponseBusinessData = JsonConvert.SerializeObject(dt);
                objResponse.ResponseCode = 200;
                return objResponse;



            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
