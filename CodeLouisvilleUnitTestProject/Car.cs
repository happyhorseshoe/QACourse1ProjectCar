using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;



namespace CodeLouisvilleUnitTestProject
{
    public class Car : Vehicle
    {
       //public new string Make { get; }
      // public new string Model { get; }
       
        private HttpClient _client = new HttpClient()
        {
            BaseAddress = new Uri("https://vpic.nhtsa.dot/gov/api/")
        };
        public int NumberOfPassengers { get; private set; }

        public Car()
            : this(0, "", "", 0)
        {
            NumberOfTires = 4;
        }

        public Car(double gasTankCapacity,
                   string make,
                   string model,
                   double milesPerGallon)
           
        {
            NumberOfTires = 4;
           // GasTankCapacity = gasTankCapacity;
           // MilesPerGallon = milesPerGallon;
           // Make = make;
           // Model = model;
        }

        public async Task<bool> WasModelMadeInYearAsync(int year)
        {
            var model = this.Model;
            if (year < 1995) throw new ArgumentException("No data is available for years before 1995");
            string urlSuffix = $"/vehicles/getmodelsformakeyear/make/{Make}/modelyear/{year}?format=json";
            var response = await _client.GetAsync(urlSuffix);
            var content = await response.Content.ReadAsStringAsync();
        }



    }

}
        
    

