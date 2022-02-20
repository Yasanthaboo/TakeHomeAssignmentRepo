using TakeHomeAssignment.HotelManager.SystemObjects;

namespace TakeHomeAssignment.HotelManager
{
    public class Room
    {
        public int Id;
        public RoomState State;
        public string Name { get; internal set; }
    }
}