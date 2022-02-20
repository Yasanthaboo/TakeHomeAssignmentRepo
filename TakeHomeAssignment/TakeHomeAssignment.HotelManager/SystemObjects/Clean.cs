namespace TakeHomeAssignment.HotelManager.SystemObjects
{
    public class Clean : RoomState
    {
        public Clean()
        {
        }

        public override void ChangeRoomState(Room room)
        {
            room.State= new Available();
        }
    }
}