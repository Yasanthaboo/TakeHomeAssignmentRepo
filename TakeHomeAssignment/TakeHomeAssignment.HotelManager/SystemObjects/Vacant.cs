namespace TakeHomeAssignment.HotelManager.SystemObjects
{
    public class Vacant : RoomState
    {
        public Vacant()
        {

        }
        public override void ChangeRoomState(Room room)
        {
            room.State = new Clean();
        }
    }
}