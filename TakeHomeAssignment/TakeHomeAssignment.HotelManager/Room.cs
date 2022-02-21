using System;
using TakeHomeAssignment.HotelManager.SystemObjects;

namespace TakeHomeAssignment.HotelManager
{
    public class Room
    {
        public int Id;
        RoomState state;
        internal bool IsCleaned;
        internal bool IsRepaired;

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
                this.IsRepaired = true;
                this.state.ChangeRoomState(this);
                Console.WriteLine(string.Format("{0}-------> is unavailable due to the ongoing repair", this.Name));
              }
        }

        private bool IsAvailableForRepair()
        {
            return this.state != null && this.state.GetType().Name == "Vacant";
        }

        public void CompleteRepair()
        {
            //this.state = new Vacant();
            this.IsCleaned = false;
            this.IsRepaired = false;
            this.State.ChangeRoomState(this);
            Console.WriteLine(string.Format("{0}-------> is Ready  for clean", this.Name));
        }

        public void Clean()
        {
            //this.state = new Available();
            this.IsCleaned = true;
            this.State.ChangeRoomState(this);
            Console.WriteLine(string.Format("{0}-------> is Ready  for Visitors", this.Name));
        }

        public void CheckIn()
        {
            //this.state = new Occupied();
            this.State.ChangeRoomState(this);
            Console.WriteLine(string.Format("{0}-------> is already assigned", this.Name));
        }

        public void CheckOut()
        {
            //this.state = new Vacant();
            this.State.ChangeRoomState(this);
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