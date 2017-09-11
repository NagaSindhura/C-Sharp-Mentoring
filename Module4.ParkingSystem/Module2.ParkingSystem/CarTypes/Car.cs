using Module4.ParkingSystem.Interfaces;

namespace Module4.ParkingSystem.CarTypes
{
    public class Car<T> : ICar
    {
        public string CarModelName => typeof(T).Name;

        public string CarNo { get; set; }

        public string OwnerName { get; set; }
    }
}