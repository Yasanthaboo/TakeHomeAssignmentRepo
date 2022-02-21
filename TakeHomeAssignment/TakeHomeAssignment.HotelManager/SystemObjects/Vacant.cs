namespace TakeHomeAssignment.HotelManager.SystemObjects
{
    public class Vacant : RoomState
    {
        public Vacant()
        {

        }
        public override void ChangeRoomState(Room room)
        {
            if(room.IsCleaned)
                room.State = new Available();
            else if(room.IsRepaired)
                room.State = new Repair();

        }
    }
}