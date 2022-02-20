namespace TakeHomeAssignment.HotelManager.SystemObjects
{
    public class Occupied : RoomState
    {
        public Occupied()
        {
         
        }
        public override void ChangeRoomState(Room room)
        {
            room.State = new Vacant(); 
        }
    }
}