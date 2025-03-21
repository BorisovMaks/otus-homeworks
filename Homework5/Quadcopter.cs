﻿namespace Homework5
{
    internal class Quadcopter : IFlyingRobot, IChargeable
    {
        private List<string> _components = new()
        { 
            "rotor1",
            "rotor2",
            "rotor3",
            "rotor4"
        };

        public void Charge()
        {
            Console.WriteLine("Charging...");
            Thread.Sleep(3000);
            Console.WriteLine("Charged!");
        }

        public List<string> GetComponents()
        {
            return _components;
        }

        public string GetInfo()
        {
            return "I am a flying and chargeable robot.";
        }
    }
}
