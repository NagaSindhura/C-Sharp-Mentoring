using System;
using System.Collections.Generic;
using Module4.ParkingSystem.Interfaces;

namespace Module4.ParkingSystem.Entities
{
    using System.Linq;

    public class Floor
    {
        public string FloorNo { get; set; }

        public int MaxSlots { get; set; }

        public List<Slot> Slots { get; set; }

        public bool IsAvailable
        {
            get
            {
                return Slots.Where(slot => slot != null).Count(slot => slot.IsAvailable) !=0;
            }
        }

        public Floor()
        {
            Slots = new List<Slot>();
        }

        public int VacentSlots()
        {
            return Slots.Where(slot => slot != null).Count(slot => slot.IsAvailable);
        }

        public void CarParkingFloor(ICar car)
        {
            foreach (var slot in Slots)
            {
                if (!slot.IsAvailable)
                {
                    continue;
                }

                slot.CarPark(car);

                return;
            }
        }

        public void CarUnParkingSlot(ICar car)
        {
            foreach (var slot in Slots)
            {
                if (slot.IsAvailable)
                {
                    continue;
                }

                if (slot.CarUnPark(car))
                {
                    return;
                }
            }
        }
    }
}