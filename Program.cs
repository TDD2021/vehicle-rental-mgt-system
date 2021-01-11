using System.Collections.Generic;

namespace A1TimDonaldDavis
{
    //Populate collection and start program
    class Program
    {
        /*
      * Using Dictionary because in theory a car rental agency wouldn't be frequently
      * adding removing from inventory as they would have limited product storage
      * A 'Lot' of a warehouse... Even when they did add new vehicles it would be infrequently.
      * 
      * They would mainly be updating the fields of the exsisting cars.
      * IsReserved, price.. etc. Makes more sense to optomize searching with Dictionary.
      */
        static void Main(string[] args)
        {
            Dictionary<int, Vehicle> _vehicles = new Dictionary<int, Vehicle>(14)
            {
                {0, new Car(1, "Honda Civic", 69.9, false, CarCategory.Sedan, CarType.Standard) },
                {1, new Car(2, "Toyota Corolla", 69.9, false, CarCategory.Sedan, CarType.Standard )},
                {2, new Car(3, "Ford Explorer", 99.9, false, CarCategory.SUV, CarType.Standard) },
                {3, new Car(4, "Nissan Versa", 49.9, false, CarCategory.Hatchback, CarType.Standard)},
                {4, new Car(5, "Hyundai Tucson", 89.9, false, CarCategory.SUV, CarType.Standard )},
                {5, new Car(6, "Lamborghini Aventador", 189.9, false,  CarCategory.Sports, CarType.Standard)},
                {6, new Car(7, "Ferrari 488 GTB", 179.9, false,  CarCategory.Sports, CarType.Standard)},
                {7, new Car(8, "McLaren P1", 199.9, false,  CarCategory.Sports, CarType.Standard)},

                {8, new Motorcycle(9, "Suzuki Boulevard M109R", 49.9, false,  MotorcycleCategory.Cruiser, MotorcycleType.Bike)},
                {9, new Motorcycle(10, "Harley-Davidson Street Glide", 79.9, false,  MotorcycleCategory.Cruiser, MotorcycleType.Bike)},
                {10, new Motorcycle(11, "Honda CRF125", 39.9, false,  MotorcycleCategory.Dirt, MotorcycleType.Bike)},
                {11, new Motorcycle(12, "Ducati Monster", 69.9, false,  MotorcycleCategory.Sports, MotorcycleType.Bike)},
                {12, new Motorcycle(13, "Can-Am Spyder", 59.9, false,  MotorcycleCategory.Cruiser, MotorcycleType.Trike)},
                {13, new Motorcycle(14, "Polaris Slingshot", 69.9, false,  MotorcycleCategory.Cruiser, MotorcycleType.Trike )}
             };

            Menu m1 = new Menu(_vehicles);
        }
    }
}
