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
        public async Task<bool> IsValidModelForMakeAsync()
        {
            string urlSuffix = $"vehicles/getmodelsformake/{Make}?format=json";
            string response = await _client.GetStringAsync(urlSuffix);
            var data = JsonSerializer.Deserialize<ModelForMakeYearResponse>(response);
            return data.Results.Any(r => r.Model_Name == Model);

        }

        public async Task<bool> WasModelMadeInYearAsync(int year)
        {
            var model = this.Model;
            if (year < 1995) throw new ArgumentException("No data is available for years before 1995");
            string urlSuffix = $"vehicles/getmodelsformakeyear/make/{Make}/modelyear/{year}?format=json";
            var response = await _client.GetAsync(urlSuffix);
            var rawJson = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<ModelForMakeYearResponse>(rawJson);
            return data.Results.Any(r => r.Model_Name == Model);
            
        }
        public void AddPassengers(int passengers)
        {
            if(passengers > 0)
            {
                NumberOfPassengers += passengers;
                MilesPerGallon -= passengers * 0.2;
            }
        }
        public void RemovePassengers(int passengers)
        {
            if(passengers >0)

            {
                int removed = passengers;
                
                if(passengers > NumberOfPassengers)
                {
                    removed = NumberOfPassengers;
                }

                NumberOfPassengers -= removed;
                MilesPerGallon += removed * 0.2;
            }
        }


    }

}
        
    

