using System;
using System.Collections.Generic;
using System.Linq;
using Module4.ParkingSystem.Interfaces;
using Module4.ParkingSystem.EventHandlers;

namespace Module4.ParkingSystem.Entities
{
    public class Building
    {
        public string Name { get; set; }

        public int MaxOfFllors { get; set; }

        public List<Floor> Floors { get; set; }

        public bool IsAvailable
        {
            get
            {
                return Floors.Where(floor => floor != null).Count(slot => slot.IsAvailable) != 0;
            }
        }

        public Building()
        {
            Floors = new List<Floor>();
        }

        public int AllAvaialableSlots()
        {
            var _allAvaialableSlots = 0;

            if (Floors != null)
            {
                return Floors.Sum(floor => floor.MaxSlots);
            }

            DisplayMessageHandler.MessageHandler += DisplayMessageHandler.DisplyMessage(
                "No floors in the Building.. !!");

            return _allAvaialableSlots;
        }

        public int VacantSlots()
        {
            return Floors.Aggregate(0, (current, floor) => current + floor.VacentSlots());
        }

        public void ParkACar(ICar car)
        {
            if (!IsAvailable)
            {
                DisplayMessageHandler.MessageHandler += DisplayMessageHandler.DisplyMessage("Empty Building");

                return;
            }

            foreach (var floor in Floors)
            {
                if (!floor.IsAvailable)
                {
                    continue;
                }

                floor.CarParkingFloor(car);

                return;
            }
        }

        public void UnParkACar(ICar car)
        {
            foreach (var floor in Floors)
            {
                if (floor.IsAvailable)
                {
                    continue;
                }

                floor.CarUnParkingSlot(car);
            }
        }
    }
}