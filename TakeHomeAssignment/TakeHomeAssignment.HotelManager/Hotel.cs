using System;
using System.Collections.Generic;
using System.Linq;
using TakeHomeAssignment.HotelManager.SystemObjects;

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
            InitialiseConnectors();

        }

        private void Initilise(List<string> roomNames, int noOfFloors)
        {
            _noOfFloors = noOfFloors;
            _roomNames = roomNames;
            Rooms = new List<Room>();
            Paths = new List<Edge>();
            int Counter = 1;

            for (int i = 1; i <= noOfFloors; i++)
            {
                foreach (var item in roomNames)
                {
                    var room = new Room(new Available())
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

            if(currentRoom.IsAvailable())
            {
                return currentRoom.Name;
            }

            var possibleRooms = paths.Where(p => p.fromNodeId == currentRoom.Id).ToList();

            if(possibleRooms.FirstOrDefault() !=null)
            {
                foreach (var room in possibleRooms)
                {
                    FindRoom(paths, rooms, rooms.Where(x => x.Id == room.toNodeId).First());
                }
            }
            return roomName; 
        }

        internal Room CheckOut(string roomNo)
        {
            var selectedRoom = this.Rooms.Where(x => x.Name.Equals(roomNo)).First();
            if (selectedRoom.CurrentState().Equals("Occupied"))
            {
                selectedRoom.CheckOut();
                return selectedRoom;
            }
            return null;
        }

        internal Room RequestToRepair(string roomNo)
        {
            var selectedRoom = this.Rooms.Where(x => x.Name.Equals(roomNo)).First();
            if (selectedRoom.CurrentState().Equals("Vacant"))
            {
                selectedRoom.MarkRepair();
                return selectedRoom;
            }
            return null;
        }

        internal Room CompleteRepair(string roomNo)
        {
            var selectedRoom = this.Rooms.Where(x => x.Name.Equals(roomNo)).First();
            if (selectedRoom.CurrentState().Equals("Repair"))
            {
                selectedRoom.CompleteRepair();
                return selectedRoom;
            }
            return null;
        }
        internal Room CleanTheRoom(string roomNo)
        {
            var selectedRoom = this.Rooms.Where(x => x.Name.Equals(roomNo)).First();
            if (selectedRoom.CurrentState().Equals("Vacant") ||
                selectedRoom.CurrentState().Equals("Repair"))
            {
                selectedRoom.Clean();
                return selectedRoom;
            }
            return null;
        }

        public List<Room> FindAllAvailableRooms()
        {
            var rooms = this.Rooms.Where(x => x.IsAvailable() == true).ToList();

            foreach (var item in rooms)
            {
                Console.WriteLine(string.Format("Room {0} is  in {1} state", item.Name, item.CurrentState()));
            }
            return rooms;
        }

        public Room CheckIn(string roomNo)
        {
            var selectedRoom = this.Rooms.Where(x => x.Name.Equals(roomNo)).First();
            if (selectedRoom.IsAvailable())
            {
                selectedRoom.CheckIn();
                return selectedRoom;
            }
            return null;
        }

        public   void  InitialiseConnectors()
        {
            var path1 = new KeyValuePair<int, int>(1, 2);
            var path2 = new KeyValuePair<int, int>(2, 3);
            var path3 = new KeyValuePair<int, int>(3,4);
            var path4 = new KeyValuePair<int, int>(4, 5);
            var path5 = new KeyValuePair<int, int>(5, 10);
            var path6 = new KeyValuePair<int, int>(10, 9);
            var path7 = new KeyValuePair<int, int>(9,8);
            var path8 = new KeyValuePair<int, int>(8, 7);
            var path9 = new KeyValuePair<int, int>(7, 6);
            var path10 = new KeyValuePair<int, int>(6, 11);
            var path11 = new KeyValuePair<int, int>(11, 12);
            var path12 = new KeyValuePair<int, int>(12, 13);
            var path13 = new KeyValuePair<int, int>(13, 14);
            var path14 = new KeyValuePair<int, int>(14, 15);
            var path15 = new KeyValuePair<int, int>(15, 20);
            var path16 = new KeyValuePair<int, int>(20, 19);
            var path17 = new KeyValuePair<int, int>(19, 18);
            var path18 = new KeyValuePair<int, int>(18, 17);
            var path19 = new KeyValuePair<int, int>(17, 16);
            



            var connectors = new List<KeyValuePair<int, int>>
            {
                path1,
                path2,
                path3,
                path4,
                path5,
                path6,
                path7,
                path8,
                path9,
                path10,
                path11,
                path12,
                path13,
                path14,
                path15,
                path16,
                path17,
                path18,
                path19


            };

         GetPath(connectors);
        }

    }
}