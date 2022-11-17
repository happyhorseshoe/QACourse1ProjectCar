using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;



namespace CodeLouisvilleUnitTestProject
{
    public class Car : Vehicle
    {
        private HttpClient _client = new HttpClient()
            {
                BaseAddress = new Uri("https://vpic.nhtsa.dot/gov/api/")
            };

    }
}
