using System.Collections.Generic;

namespace TakeHomeAssignment.HotelManager
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Room> Rooms { get; set; }
        public List<Edge> Paths { get; set; }

        private int _noOfFloors = -1;
        private List<string> _roomNames = null;
        public Hotel()
        {
        }
        public Hotel(List<string> roomNames, int noOfFloors)
        {
            Initilise(roomNames, noOfFloors);

        }

        private void Initilise(List<string> roomNames, int noOfFloors)
        {
            _noOfFloors = noOfFloors;
            _roomNames = roomNames;
            Rooms = new List<Room>();
            Paths = new List<Edge>();
            int Counter = 1;

            for (int i = 0; i < noOfFloors; i++)
            {
                foreach (var item in roomNames)
                {
                    var room = new Room()
                    {
                        Id = Counter,
                        Name = string.Format("{0}{1}", i, item)
                    };

                    Rooms.Add(room);
                    Counter++;
                }
            }
        }

        public void GetPath(List<KeyValuePair<int,int>> connectors)
        {
            foreach (var connector in connectors)
            {
                var conecor = new Edge
                {
                    fromNodeId = connector.Key,
                    toNodeId = connector.Value
                };

                Paths.Add(conecor);
            }
        }

        public string FindRoom(List<Edge> paths,List<Room> rooms,Room currentRoom)
        {
            var roomName = "No room found";

            return roomName; 
        }

        public List<Room> FindAllAvailableRooms(List<Edge> paths, List<Room> rooms, Room currentRoom)
        { 
            

            return new List<Room>();
        }

    }
}