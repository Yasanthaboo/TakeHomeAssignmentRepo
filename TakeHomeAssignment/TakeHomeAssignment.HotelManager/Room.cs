using System;
using TakeHomeAssignment.HotelManager.SystemObjects;

namespace TakeHomeAssignment.HotelManager
{
    public class Room
    {
        public int Id;
        RoomState state;
        public string Name { get; internal set; }

        public RoomState State
        {
            get { return state; }
            set { state = value; }
        }

        public Room()
        {

        }

        public Room(RoomState state)
        {
            this.state = state;
        }

        public void MarkRepair()
        {
            if(IsAvailableForRepair())
              {
                this.state = new Repair();
                Console.WriteLine(string.Format("{0}-------> is unavailable due to the ongoing repair", this.Name));
              }
        }

        private bool IsAvailableForRepair()
        {
            return this.state != null && this.state.GetType().Name == "Vacant";
        }

        public void CompleteRepair()
        {
            this.state = new Vacant();
            Console.WriteLine(string.Format("{0}-------> is Ready  for clean", this.Name));
        }

        public void Clean()
        {
            this.state = new Available();
            Console.WriteLine(string.Format("{0}-------> is Ready  for Visitors", this.Name));
        }

        public void CheckIn()
        {
            this.state = new Occupied();
            Console.WriteLine(string.Format("{0}-------> is already assigned", this.Name));
        }

        public void CheckOut()
        {
            this.state = new Vacant();
            Console.WriteLine(string.Format("{0}-------> is Vacant", this.Name));
        }

        public string CurrentState()
        {
            return this.State.GetType().Name;
        }

        public bool IsAvailable()
        {
            return  this.State.GetType().Name.Equals("Available");
        }
    }
}