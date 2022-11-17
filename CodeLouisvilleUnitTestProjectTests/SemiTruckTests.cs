using CodeLouisvilleUnitTestProject;
using FluentAssertions;
using FluentAssertions.Execution;
//using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using System.Diagnostics;

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
                semiTruck.Should().BeOfType<SemiTruck>();
                semiTruck.Should().BeAssignableTo<Vehicle>();
                semiTruck.NumberOfTires.Should().Be(18);    
                semiTruck.Cargo.Should().BeEmpty().And.NotBeNull();    //can I do this or needs to be sep?


            }
        }

        //Verify that adding a CargoItem using LoadCargo does successfully add
        //that CargoItem to the Cargo. Confirm both the existence of the new
        //CargoItem in the Cargo and also that the count of Cargo increased to 1.

        [Fact]
        public void LoadCargoTest()
        {                                                       //remember string name, string description, int quantity

            CargoItem crate = new CargoItem("Barbies", "Pool Party", 300);
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
            CargoItem crate = new CargoItem("Barbies", "Pool Party", 300);
            SemiTruck semiTruck = new SemiTruck();

            //act
            semiTruck.LoadCargo(crate);
            var outcome = semiTruck.UnloadCargo("Barbies");

            //assert
            using (new AssertionScope())
            {
                semiTruck.Cargo.Should().NotContain(crate);
                outcome.Should().Be(crate);


            }
        }
        //Verify that attempting to unload a CargoItem that does not
        //appear in the Cargo throws a System.ArgumentException
        [Fact]
        public void UnloadCargoWithInvalidCargoTest()
        {
            //arrange
            SemiTruck semTrucki = new SemiTruck();
            CargoItem crate = new CargoItem("Barbies", "Pool Party", 300);
            //act
            Action action = () => semTrucki.UnloadCargo("m");
            //assert
            action.Should().Throw<ArgumentException>();        //this isn't right. why?? spelled argument wrong
        }

        //Verify that getting cargo items by name returns all items
        //in Cargo with that name.
        [Fact]
        public void GetCargoItemsByNameWithValidName()
        {

            SemiTruck semiTruck = new SemiTruck();
            var item1 = new CargoItem("Barbies", "Pool Party", 300);
            var item2 = new CargoItem("Barbies", "Rock Stars", 30);
            var item3 = new CargoItem("Fresh Pet", "Dog Food", 100);
            var item4 = new CargoItem("Samsung", "TVs", 500);
            var item5 = new CargoItem("Tide", "Dryer Sheet", 1000);

            semiTruck.LoadCargo(item1);
            semiTruck.LoadCargo(item2);
            semiTruck.LoadCargo(item3);
            semiTruck.LoadCargo(item4);
            semiTruck.LoadCargo(item5);

            var outcome = semiTruck.GetCargoItemsByName("Barbies");
            using (new AssertionScope())
            {
                outcome.Should().NotBeNull();
                outcome.Count.Should().Be(2);
            }

        }

        //Verify that searching the Carto list for an item that does not
        //exist returns an empty list
        [Fact]
        public void GetCargoItemsByNameWithInvalidName()
        {

            SemiTruck semiTruck = new SemiTruck();
            var item1 = new CargoItem("Barbies", "Pool Party", 300);
            var item2 = new CargoItem("Barbies", "Rock Stars", 30);
            var item3 = new CargoItem("Fresh Pet", "Dog Food", 100);
            var item4 = new CargoItem("Samsung", "TVs", 500);
            var item5 = new CargoItem("Tide", "Dryer Sheet", 1000);

            semiTruck.LoadCargo(item1);
            semiTruck.LoadCargo(item2);
            semiTruck.LoadCargo(item3);
            semiTruck.LoadCargo(item4);
            semiTruck.LoadCargo(item5);

            var outcome = semiTruck.GetCargoItemsByName("Friskies");

            //assert
            using (new AssertionScope())
            {
                outcome.Should().NotBeNull();
                outcome.Should().BeEmpty();
            }
        }

        //Verify that searching the Cargo list by description for an item
        //that does exist returns all matched items that contain that description.
        [Fact]
        public void GetCargoItemsByPartialDescriptionWithValidDescription()
        {
            //arrange
            SemiTruck semiTruck = new SemiTruck();
            var item1 = new CargoItem("Barbies", "Pool Party", 300);
            var item2 = new CargoItem("Barbies", "Beach Party", 30);
            var item3 = new CargoItem("Fresh Pet", "Dog Food", 100);
            var item4 = new CargoItem("Samsung", "TVs", 500);
            var item5 = new CargoItem("Tide", "Dryer Sheet", 1000);

            semiTruck.LoadCargo(item1);
            semiTruck.LoadCargo(item2);
            semiTruck.LoadCargo(item3);
            semiTruck.LoadCargo(item4);
            semiTruck.LoadCargo(item5);

            var outcome = semiTruck.GetCargoItemsByPartialDescription("Party");
            using (new AssertionScope())
            {
                outcome.Should().NotBeNull();
                outcome.Count.Should().Be(2);
            }

        }

        //Verify that searching the Carto list by description for an item
        //that does not exist returns an empty list
        [Fact]
        public void GetCargoItemsByPartialDescriptionWithInvalidDescription()
        {
            SemiTruck semiTruck = new SemiTruck();
            var item1 = new CargoItem("Barbies", "Pool Party", 300);
            var item2 = new CargoItem("Barbies", "Rock Stars", 30);
            var item3 = new CargoItem("Fresh Pet", "Dog Food", 100);
            var item4 = new CargoItem("Samsung", "TVs", 500);
            var item5 = new CargoItem("Tide", "Dryer Sheet", 1000);

            semiTruck.LoadCargo(item1);
            semiTruck.LoadCargo(item2);
            semiTruck.LoadCargo(item3);
            semiTruck.LoadCargo(item4);
            semiTruck.LoadCargo(item5);

            var outcome = semiTruck.GetCargoItemsByPartialDescription("Cat Treats");

            //assert
            using (new AssertionScope())
            {
                outcome.Should().NotBeNull();
                outcome.Should().BeEmpty();

            }
        }

        //Verify that the method returns the sum of all quantities of all
        //items in the Cargo
        [Fact]
        public void GetTotalNumberOfItemsReturnsSumOfAllQuantities()
        {
            //arrange 
            SemiTruck semiTruck = new SemiTruck();
            var item1 = new CargoItem("Barbies", "Pool Party", 300);
            var item2 = new CargoItem("Barbies", "Beach Party", 30);
            var item3 = new CargoItem("Fresh Pet", "Dog Food", 100);
            var item4 = new CargoItem("Samsung", "TVs", 500);
            var item5 = new CargoItem("Tide", "Dryer Sheet", 1000);

            semiTruck.LoadCargo(item1);
            semiTruck.LoadCargo(item2);
            semiTruck.LoadCargo(item3);
            semiTruck.LoadCargo(item4);
            semiTruck.LoadCargo(item5);

            var outcome = semiTruck.GetTotalNumberOfItems();

            //assertion
            outcome.Should().Be(1930);                          //goal: get better at theory, be less redundant

        }

    }
}

