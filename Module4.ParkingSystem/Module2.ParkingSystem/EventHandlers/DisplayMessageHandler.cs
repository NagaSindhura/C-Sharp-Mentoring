using System;

namespace Module4.ParkingSystem.EventHandlers
{
    public class DisplayMessageHandler
    {
        public static event EventHandler MessageHandler;
        public static EventHandler DisplyMessage(string message)
        {
            Console.WriteLine(message);
            return null;
        }
    }
}