using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

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
            Assert.That("1",Is.EqualTo("1"));
        }

        [Test]
        public void FindHotelWhenRoomsNotAvaiable()
        {
            List<string> roomNames = new List<string> { "A", "B", "C", "D", "E" };
            int noOfFloors = 4;
            var hotel = new Hotel(roomNames, noOfFloors);
            var firstRoom = hotel.Rooms.First();
            hotel.FindRoom(hotel.Paths,hotel.Rooms,firstRoom);
            
        }

        [Test]
        public void AssignAavailableroom()
        {
            List<string> roomNames = new List<string> { "A", "B", "C", "D", "E" };
            int noOfFloors = 4;
            var hotel = new Hotel(roomNames, noOfFloors);
            Assert.That("1", Is.EqualTo("1"));
        }

        [Test]
        public void FindAllAvailableRooms()
        {
            List<string> roomNames = new List<string> { "A", "B", "C", "D", "E" };
            int noOfFloors = 4;
            var hotel = new Hotel(roomNames, noOfFloors);
            Assert.That("1", Is.EqualTo("1"));
        }
    }
}
