using CodeLouisvilleUnitTestProject;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit.Abstractions;

namespace CodeLouisvilleUnitTestProjectTests
{
    public class VehicleTestsShould
    {

        //Verify the parameterless constructor successfully creates a new
        //object of type Vehicle, and instantiates all public properties
        //to their default values.
        [Fact]
        public void VehicleParameterlessConstructorTest()
        {
            //arrange
            Vehicle vehicle = new Vehicle();

            //throw new NotImplementedException();
            //act

            //assert
            using (new AssertionScope())
            {
                vehicle.Should().Be(vehicle);
                vehicle.NumberOfTires.Should().Be(0);
                vehicle.GasTankCapacity.Should().Be(0);
                vehicle.Make.Should().Be("");
                vehicle.Model.Should().Be("");
                vehicle.MilesPerGallon.Should().Be(0);
            }


        }

        //Verify the parameterized constructor successfully creates a new
        //object of type Vehicle, and instantiates all public properties
        //to the provided values.
        [Fact]
        public void VehicleConstructorTest()
        {
            //arrange
            Vehicle vehicle = new(4, 10, "Lexus", "RX", 30);

            //throw new NotImplementedException();
            //act

            //assert
            using (new AssertionScope())
            {
                vehicle.Should().Be(vehicle);
                vehicle.NumberOfTires.Should().Be(4);
                vehicle.GasTankCapacity.Should().Be(10);
                vehicle.Make.Should().Be("Lexus");
                vehicle.Model.Should().Be("RX");
                vehicle.MilesPerGallon.Should().Be(30);
            }
        }

        //Verify that the parameterless AddGas method fills the gas tank
        //to 100% of its capacity
        [Fact]
        public void AddGasParameterlessFillsGasToMax()
        {
            //arrange
            Vehicle vehicle = new Vehicle(4, 10, "Lexus", "RX", 30);

            //throw new NotImplementedException();

            //act
            _ = vehicle.Drive(30);
            vehicle.AddGas();
            
            //assert
            vehicle.GasLevel.Should().Be("100%");

        }

        //Verify that the AddGas method with a parameter adds the
        //supplied amount of gas to the gas tank.
        [Fact]
        public void AddGasWithParameterAddsSuppliedAmountOfGas()
        {
            //arrange
            Vehicle vehicle = new(4, 10, "Lexus", "RX", 30);

            //act
            vehicle.AddGas(10);
            //assert
            Assert.Equal(10, vehicle.GasTankCapacity);
        }

        //Verify that the AddGas method with a parameter will throw
        //a GasOverfillException if too much gas is added to the tank.
        [Fact]
        public void AddingTooMuchGasThrowsGasOverflowException()
        {
            //arrange
            Vehicle vehicle = new Vehicle(4, 10, "Lexus", "RX", 30);
            //act
            Action act = () => vehicle.AddGas(15).Should();
            //assert
            _ = act.Should().Throw<GasOverfillException>().WithMessage($"Unable to add 15 gallons to tank " +
                  $"because it would exceed the capacity of 10 gallons");


        }

        //Using a Theory (or data-driven test), verify that the GasLevel
        //property returns the correct percentage when the gas level is
        //at 0%, 25%, 50%, 75%, and 100%.
        [Theory]
        [InlineData("0%", 0)]
        [InlineData("25%", 2.5)]
        [InlineData("50%", 5)]
        [InlineData("75%", 7.5)]
        [InlineData("100%", 10)]
        public void GasLevelPercentageIsCorrectForAmountOfGas(string percent, float gasToAdd)
        {
            //arrange

            Vehicle vehicle = new Vehicle(4, 10, "Lexus", "RX", 30);
            //act
            vehicle.AddGas(gasToAdd);

            //assert
            vehicle.GasLevel.Should().Be(percent);
        }

        /*
         * Using a Theory (or data-driven test), or a combination of several 
         * individual Fact tests, test the following functionality of the 
         * Drive method:
         *      a. Attempting to drive a car without gas returns the status 
         *      string “Cannot drive, out of gas.”.
         *      b. Attempting to drive a car with a flat tire returns 
         *      the status string “Cannot drive due to flat tire.”.
         *      c. Drive the car 10 miles. Verify that the correct amount 
         *      of gas was used, that the correct distance was traveled, 
         *      that GasLevel is correct, that MilesRemaining is correct, 
         *      and that the total mileage on the vehicle is correct.
         *      d. Drive the car 100 miles. Verify that the correct amount 
         *      of gas was used, that the correct distance was traveled,
         *      that GasLevel is correct, that MilesRemaining is correct, 
         *      and that the total mileage on the vehicle is correct.
         *      e. Drive the car until it runs out of gas. Verify that the 
         *      correct amount of gas was used, that the correct distance 
         *      was traveled, that GasLevel is correct, that MilesRemaining
         *      is correct, and that the total mileage on the vehicle is 
         *      correct. Verify that the status reports the car is out of gas.
        */

        [Fact]        //a.
        public void GasLevelEmpty()
        {
            //arrange
            Vehicle vehicle = new Vehicle(4, 10, "Lexus", "RX", 30);
            //act
            Action act = () => vehicle.AddGas(0);
            //assert
            vehicle.MilesRemaining.Should().Be(0, because: "Cannot drive, out of gas.");
        }

        //b.Flat Tire  Attempting to drive a car with a flat tire returns the status string “Cannot drive due to flat tire.”.

        [Fact]
        public void DriveWithFlatTire()
        {
            //arrange
            Vehicle vehicle = new Vehicle(4, 10, "Lexus", "RX", 30);
            //act
            vehicle.AddGas();
            vehicle.FlatTireTest();
            string drive = vehicle.Drive(5);
            //assert
            drive.Should().Be("Cannot drive due to flat tire.");


        }
        /*Drive the car c.) 10 miles. d.)100miles e.) out of gas (300miles) Verify that the correct amount
         * of gas was used, that the correct distance was traveled,
         *      that GasLevel is correct, that MilesRemaining is correct, 
         *      and that the total mileage on the vehicle is correct.*/

        /* [Theory]
         [InlineData(10,.333, "96.6%", 290, 10)]
         [InlineData(100,3.33,"66.7%",200,100)]
         [InlineData(300, 10)]
         public void DrivePositiveTestsCorrect(double milesTraveled, double gasUsed,string percent, double milesLeft, double totalMileage )
         {
             //arrange
             Vehicle vehicle= new Vehicle(4, 10, "Lexus", "RX", 30);
             vehicle.Drive(gasUsed);
             //act

             //assert
             vehicle.Mileage.Should().Be(milesTraveled);*/

        /*Drive the car c.) 10 miles. d.)100miles e.) out of gas (300miles) Verify that the correct amount
         * of gas was used, that the correct distance was traveled,
         *      that GasLevel is correct, that MilesRemaining is correct, 
         *      and that the total mileage on the vehicle is correct.*/

        [Fact]     //c//
        public void VerifyAmountsBasedOnDistance10()
        {
            //arrange
            Vehicle vehicle = new Vehicle(4, 10, "Lexus", "RX", 30);
            //act
            vehicle.AddGas();
            string amount = vehicle.Drive(10);
            //assert
            using (new AssertionScope())
            {
                amount.Should().Be("Drove 10 miles using 0.33 gallons of gas.");
                vehicle.GasLevel.Should().Be("96.66666666666666%");
                vehicle.MilesRemaining.Should().Be(290);
                vehicle.Mileage.Should().Be(10);
            }

        }
        [Fact] //d//
        public void VerifyAmountsBasedOnDistance100()
        {
            //arrange
            Vehicle vehicle = new Vehicle(4, 10, "Lexus", "RX", 30);
            //act
            vehicle.AddGas();
            string amount = vehicle.Drive(100);
            //assert
            using (new AssertionScope())
            {
                amount.Should().Be("Drove 100 miles using 3.33 gallons of gas.");
                vehicle.GasLevel.Should().Be("66.66666666666666%");
                vehicle.MilesRemaining.Should().Be(199.99999999999997);
                vehicle.Mileage.Should().Be(100);
            }

        }
        [Fact]  //e//
        public void VerifyAmountsBasedOnDistance300()
        {
            //arrange
            Vehicle vehicle = new Vehicle(4, 10, "Lexus", "RX", 30);
            //act
            vehicle.AddGas();
            string amounts = vehicle.Drive(300);
            //assert
            using (new AssertionScope())
            {
                amounts.Should().Be("Drove 300 miles, then ran out of gas.");  //every other test it wants flat tire included??
                vehicle.GasLevel.Should().Be("0%");
                vehicle.MilesRemaining.Should().Be(0);
                vehicle.Mileage.Should().Be(300);
            }
        }

        //Verify that attempting to change a flat tire using
        //ChangeTireAsync will throw a NoTireToChangeException
        //if there is no flat tire.
        [Fact]
        public async Task ChangeTireWithoutFlatTest()
        {
            //arrange
            Vehicle vehicle = new Vehicle(4, 10, "Lexus", "RX", 30);
            //act

            Func<Task> noTire = async () => { await vehicle.ChangeTireAsyncTest(); };

            //assert
            await noTire.Should().ThrowAsync<NoTireToChangeException>();
        }

        //Verify that ChangeTireAsync can successfully
        //be used to change a flat tire
        [Fact]
        public async Task ChangeTireSuccessfulTest()
        {
            //arrange
            Vehicle vehicle = new Vehicle(4, 10, "Lexus", "RX", 30);
            //act
            vehicle.FlatTireTest();
            await vehicle.ChangeTireAsyncTest();
            //assert
            vehicle.HasFlatTire.Should().Be(false);

        }
    }
}

        /*BONUS: Write a unit test that verifies that a flat
        //tire will occur after a certain number of miles.
        [Theory]
        [InlineData("MysteryParamValue")]
        public void GetFlatTireAfterCertainNumberOfMilesTest(params object[] yourParamsHere)
        {
            //arrange
            throw new NotImplementedException();
            //act

            //assert

        }
    }
}*/