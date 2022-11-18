using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeLouisvilleUnitTestProject;
using FluentAssertions.Execution;
using FluentAssertions;
using System.Diagnostics;
using Xunit;

namespace CodeLouisvilleUnitTestProjectTests
{
    public class CarTestsShould
    {
        //Verify the parameterless constructor successfully creates a new
        //object of type Vehicle, and instantiates all public properties
        //to their default values.
        [Fact]
        public void NewlyCreatedCarIsOfVehicleWith_4TiresParamlessTest()
        {
            //arrange
            Car car = new Car();

            //assert
            using (new AssertionScope())
            {
                car.Should().BeOfType<Car>();
                car.Should().BeAssignableTo<Vehicle>();
                car.NumberOfTires.Should().Be(4);
                car.Should().NotBeNull();
            }
        }
        [Fact]
        public void NewCarIsAVehicleAndHas_4TestParams()
        {
            //arrange
            Car car = new Car(10, "Honda", "Civic", 30);


            //assert
            using (new AssertionScope())
            {
                car.Should().BeOfType<Car>();
                car.GasTankCapacity.Should().Be(10);
                car.Make.Should().Be("Honda");
                car.Model.Should().Be("Civic");
                car.NumberOfTires.Should().Be(4);
                car.Should().NotBeNull();


            }

        }
        [Theory]
        [InlineData("Honda", "Civic", true)]
        [InlineData("Honda", "Camry", false)]      //is there a limit for params in theory?

        public async Task IsValidModelForMakeAsyncCorrect(string make, string model, bool isDefault)
        {
            Car car = new Car(10, make, model, 30);

            bool result = await car.IsValidModelForMakeAsync();
            result.Should().Be(isDefault);                        //isDefault?
        }
    }
}
    
