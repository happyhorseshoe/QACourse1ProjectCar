using System.Linq;

namespace CodeLouisvilleUnitTestProject
{
    public class SemiTruck : Vehicle                          //inherits from Vehicle
    {
        public List<CargoItem> Cargo { get; private set; }  //Cargo can be retrieved throughout the application
                                                            //but only set from the class containing it

        /// <summary>
        /// Creates a new SemiTruck that always has 18 Tires
        /// </summary>

        public SemiTruck()
        {
            NumberOfTires = 18;
            Cargo = new List<CargoItem>();
        }

        /// <summary>
        /// Adds the passed CargoItem to the Cargo
        /// </summary>
        /// <param name="item">The CargoItem to add</param>
        public void LoadCargo(CargoItem item)
        {
            //YOUR CODE HERE
            Cargo.Add(item);
        }
            
        /// <summary>
        /// Attempts to remove the first item with the passed name from the Cargo and return it
        /// </summary>
        /// <param name="name">The name of the CargoItem to attempt to remove</param>
        /// <returns>The removed CargoItem</returns>
        /// <exception cref="ArgumentException">Thrown if no CargoItem in the Cargo matches the passed name</exception>
        public CargoItem UnloadCargo(string name)
        {
            var item = Cargo.FirstOrDefault(x => x.Name == name);
           
            
            if (name != null)
            {
               Cargo.Remove(item);
                return item;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Returns all CargoItems with the exact name passed. If no CargoItems have that name, returns an empty List.
        /// </summary>
        /// <param name="name">The name to match</param>
        /// <returns>A List of CargoItems with the exact name passed</returns>
        public List<CargoItem> GetCargoItemsByName(string name)       //not Where b/c empty list needs to return
        {
            return Cargo.FindAll(x => x.Name == name).ToList();
        }

        /// <summary>
        ///  Returns all CargoItems who have a description containing the passed description. If no CargoItems have that name, returns an empty list.
        /// </summary>
        /// <param name="description">The partial description to match</param>
        /// <returns>A List of CargoItems with a description containing the passed description</returns>
        public List<CargoItem> GetCargoItemsByPartialDescription(string description)
        {
            return GetCargoItemsByPartialDescription(description).ToList();
        }

        /// <summary>
        /// Get the number of total items in the Cargo.
        /// </summary>
        /// <returns>An integer representing the sum of all Quantity properties on all CargoItems</returns>
        public int GetTotalNumberOfItems()         //sums all quantity on each item and all items is this enough? groupby
        {
            return Cargo.Sum(x => x.Quantity);
        }
    }
}
