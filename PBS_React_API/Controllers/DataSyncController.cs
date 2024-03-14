using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PBS_React_API.BLL.Interface;
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

        private readonly IDataSyncManager _dataManager;

        public DataSyncController(IDataSyncManager dataManager)
        {

            _dataManager = dataManager;
        }

        [HttpGet("Get_AutoComplete_Data_Quick_Sync")]
        public async Task<APIServiceResponse> GET_AUTOCOMPLETE_DATA_QUICK()
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            try
            {
                DataSet ds = _dataManager.GET_AUTOCOMPLETE_DATA_QUICK();

                string json = JsonConvert.SerializeObject(ds.Tables[0], Formatting.Indented);
                System.IO.File.WriteAllText(@"QuickSearchData.json", json);

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
        
        [HttpGet("Get_AutoComplete_Data_Quick")]
        public async Task<APIServiceResponse> Get_AutoComplete_Data([FromHeader(Name = "SessionKey")] string SessionKey, string SerText)
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            try
            {
                DataSet ds1 = new DataSet();
                ds1.Tables.Add((DataTable)JsonConvert.DeserializeObject(System.IO.File.ReadAllText("QuickSearchData.json"), (typeof(DataTable))));
                DataTable dt = _dataManager.GET_AUTOCOMPLETE_DATA(ds1, SerText);

                objResponse.ResponseBusinessData = JsonConvert.SerializeObject(dt);
                objResponse.ResponseCode = 200;
                return objResponse;



            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("Get_Search_Data")]
        public async Task<string> Get_Search_Data(string SerText)
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            try
            {
                DataSet ds1 = new DataSet();
                ds1.Tables.Add((DataTable)JsonConvert.DeserializeObject(System.IO.File.ReadAllText("QuickSearchData.json"), typeof(DataTable)));
               
                return JsonConvert.SerializeObject(_dataManager.Get_Search_Data(ds1, SerText));

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //[HttpGet("makekeywords")]
        //public async Task<APIServiceResponse> makekeywords()
        //{
        //    try
        //    {
        //        DataSet ds1 = new DataSet();
        //        ds1.ReadXml(@"QuickSearchData.xml");
        //        foreach (DataRow item in ds1.Tables[0].Rows)
        //        {
        //            var productCode = item["productcode"].ToString();
        //            var sentenceKey = item["searchingkeyword"].ToString();
        //            var sentenceKeys = sentenceKey.Split("NewSrcTxt");

        //            //DataSet ds = _dataContext.GetTransInfo("SP_INFO_SEARCH", "UpdateSearchKey", sentenceKeys[0], productCode);

        //        }

        //        APIServiceResponse objResponse = new APIServiceResponse();

        //        objResponse.ResponseBusinessData = JsonConvert.SerializeObject("ok");
        //        objResponse.ResponseCode = 200;
        //        return objResponse;



        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

       
    }
}
