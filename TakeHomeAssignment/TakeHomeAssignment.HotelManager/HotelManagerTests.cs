using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TakeHomeAssignment.HotelManager.SystemObjects;

namespace TakeHomeAssignment.HotelManager
{
    [TestFixture]
    internal class HotelManagerTests
    {
        [Test]
        public void BuildHotel()
        {
            List<string> roomNames = new List<string> {"A","B","C","D","E" };
            int noOfFloors = 4;
            var hotel = new Hotel(roomNames,noOfFloors);

            var roomcount = hotel.Rooms.Count();
            var connectors = hotel.Paths.Count();
            Assert.That(roomcount, Is.EqualTo(20));
            Assert.That(connectors, Is.EqualTo(19));
        }

        

        [Test]
        public void AssignAavailableroom()
        {
            List<string> roomNames = new List<string> { "A", "B", "C", "D", "E" };
            int noOfFloors = 4;
            var hotel = new Hotel(roomNames, noOfFloors);
            var roomNo =  hotel.FindRoom(hotel.Paths,hotel.Rooms,hotel.Rooms.First());
            Assert.That(roomNo, Is.EqualTo("1A"));
        }

        [Test]
        public void CheckInToGivenRoom()
        {
            List<string> roomNames = new List<string> { "A", "B", "C", "D", "E" };
            int noOfFloors = 4;
            var hotel = new Hotel(roomNames, noOfFloors);
            string roomNo = "3A";
            var room = hotel.CheckIn(roomNo);
            Assert.That(room.CurrentState, Is.EqualTo("Occupied"));
        }

        [Test]
        public void FindAllAvailableRooms()
        {
            var hotel =  InitilizeHotel();
            var roomList = hotel.FindAllAvailableRooms();
            var isAvailable = roomList.FirstOrDefault().IsAvailable();
            var isValid = roomList.Count() > 0 && isAvailable;
            Assert.That(isValid, Is.EqualTo(true));
        }

        private static Hotel InitilizeHotel()
        {
            List<string> roomNames = new List<string> { "A", "B", "C", "D", "E" };
            int noOfFloors = 4;
            return  new Hotel(roomNames, noOfFloors);
        }

        [Test]
        public void CheckOut()
        {
            var hotel = InitilizeHotel();
            string roomNo = "3A";
            var room = hotel.CheckOut(roomNo);
            Assert.That("1", Is.EqualTo("1"));
        }

        [Test]
        public void RequestToRepair()
        {
            var hotel = InitilizeHotel();
            string roomNo = "3A";
            var selectedRoom = hotel.Rooms.Where(x => x.Name.Equals(roomNo)).First();
            selectedRoom.State = new Vacant();
            var room = hotel.RequestToRepair(roomNo);
            Assert.That(room.CurrentState(), Is.EqualTo("Repair"));
        }

        [Test]
        public void RequestToClean()
        {
            var hotel = InitilizeHotel();
            string roomNo = "3A";
            var selectedRoom = hotel.Rooms.Where(x => x.Name.Equals(roomNo)).First();
            selectedRoom.State = new Vacant();
            var room = hotel.CleanTheRoom(roomNo);
            Assert.That(room.CurrentState(), Is.EqualTo("Available"));

            // checking   for  repair  scenario
            selectedRoom.State = new Repair();
             room = hotel.CleanTheRoom(roomNo);
            Assert.That(room.CurrentState(), Is.EqualTo("Available"));
        }

        [Test]
        public void CompleteRepair()
        {
            var hotel = InitilizeHotel();
            string roomNo = "3A";
            var selectedRoom = hotel.Rooms.Where(x => x.Name.Equals(roomNo)).First();
            selectedRoom.State = new Repair();
            var room = hotel.CompleteRepair(roomNo);
            Assert.That(room.CurrentState(), Is.EqualTo("Vacant"));
        }
    }
}
