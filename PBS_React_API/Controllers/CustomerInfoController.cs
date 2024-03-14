
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PBS_React_API.BLL.Interface;
using PBS_React_API.Model;
using System.Data;

namespace PBS_React_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerInfoController : ControllerBase
    {
        private readonly iUserPanelManager _dataManager;

        public CustomerInfoController(iUserPanelManager dataManager)
        {

            _dataManager = dataManager;
        }

        [HttpGet("Get_Update_Customer_Address")]
        public async Task<APIServiceResponse> Update_Customer_Address([FromHeader(Name = "SessionKey")] string SessionKey, string addressId, string customerId)
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            string SSessionKey = customerId + Convert.ToDateTime(DateTime.Now).ToString("ddMMyyyHH");
            if (SessionKey != SSessionKey)
            {
                return objResponse;
            }
            try
            {
               

                DataSet ds = _dataManager.Delete_User_Address(addressId, customerId);

                objResponse.ResponseBusinessData = JsonConvert.SerializeObject(ds.Tables[0]).ToString();
                objResponse.ResponseCode = 200;
                objResponse.SuccessMsg = "DATA SYNC SUCCESSFULLY";

                return objResponse;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
