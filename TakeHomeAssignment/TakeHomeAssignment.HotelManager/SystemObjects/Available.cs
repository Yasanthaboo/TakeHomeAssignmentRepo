namespace TakeHomeAssignment.HotelManager.SystemObjects
{
    public class Available : RoomState
    {
        public Available()
        {

        }

        public override void ChangeRoomState(Room room)
        {
            room.State = new Occupied();
        }
    }
}