using GST_TaxPayerSearch_API.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GST_TaxPayerSearch_API.Controllers
{
    public class SearchController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> GetData()
        {
            try
            {
                // Base URL and API endpoint
                string baseUrl = "https://api.mastergst.com";
                string endpoint = "/public/search";

                // Request parameters
                string email = "omopyt2020@gmail.com";
                string gstin = "33AAGCC7144L6ZE";
                string clientId = "c9892867-bb20-42ae-95cf-0eda2100c9a1";
                string clientSecret = "284c606f-7f26-4b47-a51f-3c32a3c9f21f";

                // Create RestSharp client
                var client = new RestClient(baseUrl);

                // Create RestSharp request for the resource
                var request = new RestRequest(endpoint, Method.Get);

                // Set Authorization header
                string base64Auth = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{clientId}:{clientSecret}"));
                request.AddHeader("Authorization", $"Basic {base64Auth}");

                // Add query parameters
                request.AddParameter("email", email);
                request.AddParameter("gstin", gstin);

                // Execute the request and get the response
                RestResponse response = await client.ExecuteAsync(request);

                // Check if the request was successful
                if (response.IsSuccessful)
                {
                    // Read and process the API response content as JSON
                    string responseData = response.Content;

                    // Deserialize JSON response to object
                    var responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResponse>(responseData);

                    // Access properties of the deserialized object
                    string stjCd = responseObject.Data.StjCd;
                    string lgnm = responseObject.Data.Lgnm;

                    // Process the API data as needed
                    // ...

                    return Ok(responseObject);
                }
                else
                {
                    // Handle API error
                    // ...
                    return InternalServerError(new Exception("API request failed"));
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                // ...
                return InternalServerError(ex);
            }
        }
    }
}
