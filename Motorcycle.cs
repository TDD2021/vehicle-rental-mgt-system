
namespace A1TimDonaldDavis
{
    //enums for values unique to Motorcycle
    public enum MotorcycleCategory
    {
        Cruiser,
        Sports,
        Dirt
    }
    public enum MotorcycleType
    {
        Bike,
        Trike
    }
    class Motorcycle : Vehicle
    {
        private MotorcycleCategory _category;
        private MotorcycleType _type;
       
        public MotorcycleCategory Category
        {
            get => _category;
            set => _category = value;
        }

        public MotorcycleType Type
        {
            get => _type;
            set => _type = value;
        }

        public Motorcycle(int id, string name,  double rentalPrice, bool isReserved, MotorcycleCategory category, MotorcycleType type) //string category, string type,
            : base(id, name,  rentalPrice,  isReserved) 
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
