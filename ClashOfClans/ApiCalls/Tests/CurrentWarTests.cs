using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using NUnit.Framework;

namespace ClashOfClans.ApiCalls.Tests
{
    [TestFixture]
    public class CurrentWarTests
    {
        CurrentWar currentWar = new CurrentWar();
        ApiCall apiCalls = new ApiCall();
        string clanTag = "8UJGPROJ";

        [Test]
        public void GetCurrentWar_Displays_List_Of_Opponents()
        {
            var expected = "mosi2";
            var data = apiCalls.GetCurrentWar(clanTag);
            var actual = data.OpposingClan.MembersInWars.Where(n => n.MapPosition == 11).Single();

            Assert.That(actual.Name, Is.EqualTo(expected));
        }

        //[Test]
        //public void GetCurrentWar_Returns_Correct_Time()
        //{
        //    var expected = "4:00";

        //    var data = apiCalls.GetCurrentWar(clanTag);
        //    var startTime = data.StartTime.ToString();
        //    var endTime = currentWar.convertedDateTime(data.EndTime);

        //    Assert.That(endTime, Is.EqualTo(expected));
        //}
    }
}