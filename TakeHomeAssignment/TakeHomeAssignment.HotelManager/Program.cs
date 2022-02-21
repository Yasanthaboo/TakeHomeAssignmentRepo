using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeHomeAssignment.HotelManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var roomNames = new List<string> { "A", "B", "C", "D", "E" };
            var floors = 4;
            var allocationManager = new Hotel(roomNames, floors) { Id=1,Name="Test hotel"};
            bool IsExit = false;

            while (!IsExit)
            {
                Display();
                var request = Console.ReadLine();
                IsExit = HandleOperations(allocationManager, IsExit, request);
            }
        }

        /// <summary>
        /// display  instructions
        /// </summary>
        private static void Display()
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("Please enter option no  to continue.");
            Console.WriteLine("Enter 1 for display all available rooms.");
            Console.WriteLine("Enter 2 for assign a  room.");
            Console.WriteLine("Enter 3 for check in  to a room.");
            Console.WriteLine("Enter 4 for check out. ");
            Console.WriteLine("Enter 5 for  assign the room for repair.");
            Console.WriteLine("Enter 6 clean the  room");
            Console.WriteLine("Enter 7 complete the  repair");
            Console.WriteLine("Enter 'Exit' exit from application");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
        }

        /// <summary>
        /// Manage operations
        /// </summary>
        /// <param name="allocationManager"></param>
        /// <param name="IsExit"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        private static bool HandleOperations(Hotel allocationManager, bool IsExit, string request)
        {
            try
            {
                switch (request)
                {
                    case "Exit":
                        IsExit = true;
                        break;
                    case "1":
                        allocationManager.FindAllAvailableRooms();
                        break;

                    case "2":
                        AssignNewRoom(allocationManager);
                        break;
                    case "3":

                        HandleCheckIn(allocationManager);
                        break;
                    case "4":
                        HandleCheckOut(allocationManager);
                        break;
                    case "5":
                        HandleRepair(allocationManager);
                        break;
                    case "6":
                        HandleCleaing(allocationManager);
                        break;
                    case "7":
                        HandleCompleteRepair(allocationManager);
                        break;
                    default:
                        break;
                }

                return IsExit;
            }
            catch (Exception er)
            {
                Console.WriteLine(string.Format("Error occured. Unable to execute the  request./n{0}",er.Message));
                //add logs  here
                return false;
            }
            
        }

        private static void HandleCompleteRepair(Hotel allocationManager)
        {
            Console.WriteLine("Please enter room no to proceede with complete the repair.");
            var selectedRoomNo = Console.ReadLine();
            var fixedRoom = allocationManager.CompleteRepair(selectedRoomNo);
            if (fixedRoom != null)
                Console.WriteLine(string.Format("{0} been repaired.", fixedRoom.Name));
            else
                Console.WriteLine("Unble to fix the room");
        }

        private static void HandleCleaing(Hotel allocationManager)
        {
            Console.WriteLine("Please enter room no to proceede with cleaning.");
            var selectedRoomNo = Console.ReadLine();
            var CleanedRoom = allocationManager.CleanTheRoom(selectedRoomNo);
            if (CleanedRoom != null)
                Console.WriteLine(string.Format("{0} is  Cleaned.", CleanedRoom.Name));
            else
                Console.WriteLine("Unble to clean the room");
        }

        private static void HandleRepair(Hotel allocationManager)
        {
            Console.WriteLine("Please enter room no to proceede with repair.");
            var selectedRoomNo = Console.ReadLine();
            var repaired = allocationManager.RequestToRepair(selectedRoomNo);
            if (repaired != null)
                Console.WriteLine(string.Format("{0} been assinged to repair.", repaired.Name));
            else
                Console.WriteLine("Unble to assing the room to  repair");
        }

        private static void HandleCheckIn(Hotel allocationManager)
        {
            Console.WriteLine("Please enter room no to proceede with check-in");
            var selectedRoomNo = Console.ReadLine();
            var allocatedRoom = allocationManager.CheckIn(selectedRoomNo);
            if (allocatedRoom != null)
                Console.WriteLine(string.Format("{0} been assinged to you.", allocatedRoom.Name));
            else
                Console.WriteLine("Unble to assing the room");
        }

        private static void AssignNewRoom(Hotel allocationManager)
        {
            var roomNo = allocationManager.FindRoom(allocationManager.Paths,
                                                                            allocationManager.Rooms, allocationManager.Rooms.First());
            if (!string.IsNullOrEmpty(roomNo))
                Console.WriteLine(string.Format("{0} been assinged to you.", roomNo));
            else
                Console.WriteLine("Unble to assing a room");

            allocationManager.CheckIn(roomNo);
          
        }

        private static void HandleCheckOut(Hotel allocationManager)
        {
            Console.WriteLine("Please enter room no to proceede with check-out");
            var selectedRoomNo = Console.ReadLine();
            var checkoutRoom = allocationManager.CheckOut(selectedRoomNo);
            if (checkoutRoom != null)
                Console.WriteLine(string.Format("You have been check-out from {0}.", checkoutRoom.Name));
            else
                Console.WriteLine("Unble to check-out the room");
        }
    }
}
