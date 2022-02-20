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
            var hotel = new Hote(List<string> roomNames ,int  noOfFloors);
            Assert.That("1",Is.EqualTo("1"));
        }
    }
}
