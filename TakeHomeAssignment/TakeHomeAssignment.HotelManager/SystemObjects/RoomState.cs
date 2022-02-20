using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeHomeAssignment.HotelManager.SystemObjects
{
    public abstract class RoomState
    {
        public abstract void ChangeRoomState(Room room);
    }
}
