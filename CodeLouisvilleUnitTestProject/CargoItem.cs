//using System.ComponentModel;
//using System.Runtime.CompilerServices;



namespace CodeLouisvilleUnitTestProject
{
    public class CargoItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public CargoItem(string name, string description, int quantity)    //for testing purposes
        {
            Name = name;
            Description = description;
            Quantity = quantity;
        }
    }
}



