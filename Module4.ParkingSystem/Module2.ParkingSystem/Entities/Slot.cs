using System;
using Module4.ParkingSystem.Interfaces;

namespace Module4.ParkingSystem.Entities
{
    using Module4.ParkingSystem.EventHandlers;

    public class Slot
    {
        public string SlotNumber { get; set; }

        public bool IsAvailable { get; set; }

        public ICar ParkedCar { get; set; }

        public Slot()
        {
            IsAvailable = true;
        }

        public void CarPark(ICar parkedCar)
        {
            if (ParkedCar != null || parkedCar == null)
            {
                return;
            }

            IsAvailable = false;
            ParkedCar = parkedCar;

            DisplayMessageHandler.MessageHandler +=
                DisplayMessageHandler.DisplyMessage($"Successfully allotted slot for {ParkedCar.OwnerName}");
        }

        public bool CarUnPark(ICar unParkedCar)
        {
            if (ParkedCar == null || !unParkedCar.Equals(ParkedCar))
            {
                return false;
            }

            ParkedCar = null;
            DisplayMessageHandler.MessageHandler +=
                DisplayMessageHandler.DisplyMessage($"Successfully deallotted slot for {unParkedCar.OwnerName}");
            return IsAvailable = true;
        }
    }
}