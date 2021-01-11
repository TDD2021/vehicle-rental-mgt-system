
namespace A1TimDonaldDavis
{
    //enums for values unique to Car
    public enum CarCategory
    {
        Hatchback,
        Sedan,
        SUV,
        Sports
    }
    public enum CarType
    {
        Standard,
        Exotic
    }
    //concrete class that inheirts from vehicle
    public class Car : Vehicle
    {
        private CarCategory _category;
        private CarType _type;
       
        public CarCategory Category
        {
            get => _category;
            set => _category = value;
        }

        public CarType Type
        {
            get => _type;
            set => _type = value;
        }
        public Car(int id, string name,  double rentalPrice, bool isReserved, CarCategory category, CarType type) 
            : base(id, name, rentalPrice, isReserved)
        {
            Category = category;
            Type = type;
        }

        //return all base class fields with formatting + local fields w/ formatting
        public override string ToString()
        {
            return $"{base.ToString()} \t{Category,-15} {Type,-15}";
        }

        //return all base class fields except isReserved with formatting + local fields w/ formatting
        public override string Availability()
        {
            return $"{base.Details()}\t{Category,-15} {Type,-15}";
        }


    }
}
