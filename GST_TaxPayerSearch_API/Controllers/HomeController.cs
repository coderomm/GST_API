using GST_TaxPayerSearch_API.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GST_TaxPayerSearch_API.Controllers
{
    public class HomeController : Controller
    {
        private readonly Credentials _credentials;

        public HomeController()
        {
            _credentials = new Credentials();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(string gstNum)
        {
            try
            {
                var client = new RestClient(_credentials.BaseUrl);
                var request = new RestRequest(_credentials.Endpoint, Method.Get);

                request.AddHeader("client_id", _credentials.ClientId);
                request.AddHeader("client_secret", _credentials.ClientSecret);
                // Add query parameters
                request.AddParameter("email", _credentials.Email);
                
                request.AddParameter("gstin", gstNum);
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                // Execute the request and get the response
                RestResponse response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    // Read and process the API response content as JSON
                    string responseData = response.Content;

                    // Deserialize JSON response to object
                    var responseObject = JsonConvert.DeserializeObject<ApiResponse>(responseData);

                    // Access properties of the deserialized object
                    //string stjCd = responseObject.Data.StjCd;
                    //string lgnm = responseObject.Data.Lgnm;

                    return View(responseObject);
                }
                else
                {
                    // Handle API error
                    return View(new Exception("API request failed"));
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return View(ex);
            }
        }

    }
}