using TakeHomeAssignment.HotelManager.SystemObjects;

namespace TakeHomeAssignment.HotelManager
{
    public class Room
    {
        public int Id;
        internal Clean State;

        public string Name { get; internal set; }
    }
}