using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GST_TaxPayerSearch_API.Models
{
    public class Credentials
    {
        // Set you own credentials
        public string BaseUrl { get; } = "https://api.example.com";
        public string Endpoint { get; } = "/public/search";
        public string Email { get; } = "mail@gmail.com";
        public string ClientId { get; } = "c9892867-bb20-42ae-95cf-0eda2100c9a10";
        public string ClientSecret { get; } = "284c606f-7f26-4b47-a51f-3c32a3c9f21f0";
    }

}