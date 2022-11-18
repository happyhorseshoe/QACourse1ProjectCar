/*using System;
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
            public void NewCarIsAVehicleAndHas4Test()
        {
            //arrange
            Car car = new Car();
            //act

            //assert
            using (new AssertionScope())
            {
                car.Should().BeOfType<Car>();
                car.Should().BeAssignableTo<Vehicle>();
                car.NumberOfTires.Should().Be(4);    
                semiTruck.Cargo.Should().BeEmpty().And.NotBeNull();    //can I do this or needs to be sep?


            }

        }
    }
*/