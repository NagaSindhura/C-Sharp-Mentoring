using System;
using Module4.ParkingSystem.Entities;
using Module4.ParkingSystem.CarTypes;
using Module4.ParkingSystem.EventHandlers;

namespace Module4.ParkingSystem
{
    public class Program
    {
        public static void Main()
        {
            var building = new Building();

            for (var i = 1; i <= 3; i++)
            {
                building.MaxOfFllors = 3;
                building.Floors.Add(new Floor { FloorNo = $"Floor-{i}" });
            }

            foreach (var floor in building.Floors)
            {
                floor.MaxSlots = 3;
                for (var j = 1; j <= floor.MaxSlots; j++)
                {
                    floor.Slots.Add(new Slot() { SlotNumber = $"Slot-{j}" });
                }
            }

            building.ParkACar(null);

            building.ParkACar(new Car<BmwCar> { OwnerName = "Person1", CarNo = "AP 1234" });
            building.ParkACar(new Car<BmwCar> { OwnerName = "Person2", CarNo = "AP 1235" });
            building.ParkACar(new Car<Toyota> { OwnerName = "Person3", CarNo = "AP 1236" });
            building.ParkACar(new Car<BmwCar> { OwnerName = "Person4", CarNo = "AP 1237" });
            building.ParkACar(new Car<Toyota> { OwnerName = "Person5", CarNo = "AP 1238" });
            building.ParkACar(new Car<BmwCar> { OwnerName = "Person6", CarNo = "AP 1239" });

            foreach (var floor in building.Floors)
            {
                if (floor.FloorNo.ToUpper().Equals("Floor-2".ToUpper()))
                {
                    DisplayMessageHandler.MessageHandler +=
                        DisplayMessageHandler.DisplyMessage(
                            $"Count of all available (free) parking slots for a floor i.e. Floor-2 = {floor.VacentSlots()}");
                }
            }

            DisplayMessageHandler.MessageHandler +=
                DisplayMessageHandler.DisplyMessage(
                    $"count of all available parking slots in a building - {building.VacantSlots()}");

            building.ParkACar(new Car<BmwCar> { OwnerName = "Person7", CarNo = "AP 1240" });
            building.ParkACar(new Car<BmwCar> { OwnerName = "Person8", CarNo = "AP 1241" });
            var car1 = new Car<BmwCar> { OwnerName = "Person9", CarNo = "AP 1242" };
            building.ParkACar(car1);
            var car2 = new Car<BmwCar> { OwnerName = "Person10", CarNo = "AP 1243" };
            building.ParkACar(car2);

            DisplayMessageHandler.MessageHandler +=
                DisplayMessageHandler.DisplyMessage(
                    $"count of all the available parking slots for all floors - {building.VacantSlots()}");

            building.UnParkACar(car1);

            DisplayMessageHandler.MessageHandler +=
                DisplayMessageHandler.DisplyMessage(
                    $"count of all the available parking slots for all floors - {building.VacantSlots()}");

            building.ParkACar(car2);

            DisplayMessageHandler.MessageHandler +=
                DisplayMessageHandler.DisplyMessage(
                    $"count of all the available parking slots for all floors - {building.VacantSlots()}");

            DisplayMessageHandler.MessageHandler +=
                DisplayMessageHandler.DisplyMessage(
                    $"count of total parking slots in the building is- {building.AllAvaialableSlots()}");

            Console.ReadLine();
        }
    }
}