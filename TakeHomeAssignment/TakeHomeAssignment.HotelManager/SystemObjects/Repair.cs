using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeHomeAssignment.HotelManager.SystemObjects
{
    public class Repair : RoomState
    {
        public Repair()
        {
        }
        public override void ChangeRoomState(Room room)
        {
            room.State = new Clean();
        }
    }
}
