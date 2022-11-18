using System;
using System.Linq;
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
            var car = new Car(10, "Honda", "Civic", 30);


            //assert
            using (new AssertionScope())
            {

                car.Make.Should().Be("Honda");
                car.Model.Should().Be("Civic");
                car.NumberOfTires.Should().Be(4);
                car.MilesPerGallon.Should().Be(30);
                car.Should().NotBeNull();


            }

        }
        //[Theory]
        //[InlineData("Honda", "Civic", true)]
        //[InlineData("Honda", "Camry", false)]      //is there a limit for params in theory?
        [Fact]
        public Task IsValidModelForMakeAsyncCorrect()//(string make, string model, bool isDefault)
        {
            Car car = new Car();
            string Honda = car.Make;
            string Civic = car.Model;
            Func<Task> act = async () => { await car.IsValidModelForMakeAsync(); };
            return Task.CompletedTask;
        }

        //bool result = await car.IsValidModelForMakeAsync();
        //result.Should().Be(isDefault);                        //isDefault?


        [Theory]
        [InlineData("Pants", "WRX", 2000, false)]
        [InlineData("Honda", "Camry", 2000, false)]
        [InlineData("Subaru", "WRX", 2020, true)]
        [InlineData("Subaru", "WRX", 2000, false)]


        public async Task IsModelMadeInYear(string make, string model, int year, bool expected)
        {
            Car car = new Car(10, make, model, 30);
            bool answer = await car.WasModelMadeInYearAsync(year);
            answer.Should().Be(expected);
        }

        [Theory]
        [InlineData("Honda", "Civic", 2000)]
        [InlineData("Honda", "Civic", 2005)]
        [InlineData("Honda", "Civic", 1992)]

        public Task ModelMadeInYearBefore1995(string make, string model, int year)
        {
            Car car = new Car(10, make, model, 30);
            Func<Task> action = async () => { await car.WasModelMadeInYearAsync(year); };
            action.Should().ThrowAsync<ArgumentException>()
                .WithMessage("No data is available for years before 1995.");
            return Task.CompletedTask;
        }

        [Theory]
        [InlineData(1, 30, 29.8)]
        [InlineData(0, 30, 30)]
        public void AddPassengers(int passengers, double milesPer, double expected)
        {
            Car car = new Car(10, "Honda", "Civic", milesPer);
            car.AddPassengers(passengers);
            car.MilesPerGallon.Should().Be(expected);
        }

        [Theory]
        [InlineData(5, 21, 3, 2, 20.6)]
        [InlineData(5, 21, 5, 0, 21)]
        [InlineData(5, 21, 25, 0, 21)]
        public void RemovePassengers(int passengers, double milesPer, int removeFrom, int passengersInside, double expectedMilesPer)
        {
            Car car = new Car(10, "Honda", "Civic", milesPer);
            car.AddPassengers(passengers);
            car.RemovePassengers(removeFrom);

            using (new AssertionScope())

            {
                car.NumberOfPassengers.Should().Be(passengersInside);
                car.MilesPerGallon.Should().Be(expectedMilesPer);
            }












        }
    }
}


    



    

    

   



   
