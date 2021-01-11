
namespace A1TimDonaldDavis
{
    //base class for Motorcycle and Car
    public abstract class Vehicle
    {
        /*Declared type and category within their respective concrete classes to provide proper implementation of enum.
         * Didn't want the car class to have access to motorcycle types / categories etc..
         * Made more sense to implement compile time checking then runtime
         */
        private int _id;
        private string _name;
        private double _rentalPrice;
        private bool _isReserved;

        public Vehicle(int id, string name, double rentalPrice, bool isReserved)
        {
            Id = id;
            Name = name;
            RentalPrice = rentalPrice;
            IsReserved = isReserved;
        }

        public int Id 
        {
            get => _id;
            private set => _id = value; 
        }
        public string Name 
        {
            get => _name;
            private set => _name = value;
        }
        public double RentalPrice
        {
            get => _rentalPrice;
            private set => _rentalPrice = value;
        }

        public bool IsReserved
        {
            get => _isReserved;
            set => _isReserved = value;
        }

        //return all fields except isreserved
        public virtual string Details()
        {
            return $"{Id,10} {Name,-33} {RentalPrice,7:C} ";
        }

        //force implementation of method for both derived classes 
        public abstract string Availability(); 

        // return all fields with string formatting
        public override string ToString()
        {
            return $"{Id,10} {Name,-33} {RentalPrice, 7:C} {(IsReserved ? "No" : "Yes"), 12} "; 
        }

    }
}
