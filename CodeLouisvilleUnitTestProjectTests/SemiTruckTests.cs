using CodeLouisvilleUnitTestProject;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;

namespace CodeLouisvilleUnitTestProjectTests
{
    public class SemiTruckTestsShould
    {

        //Verify that the SemiTruck constructor creates a new SemiTruck
        //object which is also a Vehicle and has 18 wheels. Verify that the
        //Cargo property for the newly created SemiTruck is a List of
        //CargoItems which is empty, but not null.
        [Fact]
        public void NewSemiTruckIsAVehicleAndHas18TiresAndEmptyCargoTest()
        {
            //arrange
            SemiTruck semiTruck = new SemiTruck();
            //act

            //assert
            using (new AssertionScope())
            {
                semiTruck.Should().Be(semiTruck);
                semiTruck.Should().BeOfType<Vehicle>();
                semiTruck.NumberOfTires.Should().Be(18);    //is this redundant?
                semiTruck.Cargo.Should().BeEmpty().And.NotBeNull();    //can I do this or needs to be sep?


            }

            //Verify that adding a CargoItem using LoadCargo does successfully add
            //that CargoItem to the Cargo. Confirm both the existence of the new
            //CargoItem in the Cargo and also that the count of Cargo increased to 1.

            [Fact]
            public void LoadCargoTest()
            {
                //arrange
              CargoItem crate = new CargoItem();
              SemiTruck semiTruck = new SemiTruck();
                

                //act
              semiTruck.LoadCargo(crate);

                //assert
                using (new AssertionScope())
                {
                    semiTruck.Cargo.Should().Contain(crate);
                    semiTruck.Cargo.Should().HaveCountGreaterThanOrEqualTo(1);

                }

            }
        

        //Verify that unloading a  cargo item that is in the Cargo does
        //remove it from the Cargo and return the matching CargoItem
        [Fact]
        public void UnloadCargoWithValidCargoTest()
        {
                //arrange
                SemiTruck semiTruck = new SemiTruck();
                CargoItem crate = new CargoItem();
            //act

            //assert

        }

        //Verify that attempting to unload a CargoItem that does not
        //appear in the Cargo throws a System.ArgumentException
        [Fact]
        public void UnloadCargoWithInvalidCargoTest()
        {
            //arrange
            throw new NotImplementedException();
            //act

            //assert

        }

        //Verify that getting cargo items by name returns all items
        //in Cargo with that name.
        [Fact]
        public void GetCargoItemsByNameWithValidName()
        {
            //arrange
            throw new NotImplementedException();
            //act

            //assert

        }

        //Verify that searching the Carto list for an item that does not
        //exist returns an empty list
        [Fact]
        public void GetCargoItemsByNameWithInvalidName()
        {
            //arrange
            throw new NotImplementedException();
            //act

            //assert

        }

        //Verify that searching the Cargo list by description for an item
        //that does exist returns all matched items that contain that description.
        [Fact]
        public void GetCargoItemsByPartialDescriptionWithValidDescription()
        {
            //arrange
            throw new NotImplementedException();
            //act

            //assert

        }

        //Verify that searching the Carto list by description for an item
        //that does not exist returns an empty list
        [Fact]
        public void GetCargoItemsByPartialDescriptionWithInvalidDescription()
        {
            //arrange
            throw new NotImplementedException();
            //act

            //assert

        }

        //Verify that the method returns the sum of all quantities of all
        //items in the Cargo
        [Fact]
        public void GetTotalNumberOfItemsReturnsSumOfAllQuantities()
        {
            //arrange
            throw new NotImplementedException();
            //act

            //assert

        }
    }
}
