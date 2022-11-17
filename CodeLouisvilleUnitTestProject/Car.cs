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
        private HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("https://vpic.nhtsa.dot/gov/api/")
        };
        public int NumberOfPassengers { get; private set; }

        public Car()
            : this(0, "", "", 0)
        {
        }

        public Car(double gasTankCapacity,
                   string make,
                   string model,
                   double milesPerGallon)
            : base(4, gasTankCapacity, make, model, milesPerGallon);
        {
        }
        

        
    }

}
        
    

