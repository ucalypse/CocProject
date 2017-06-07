using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClashOfClans.Controllers;
using ClashOfClans.Models;
using NUnit.Framework;

namespace ClashOfClans.ApiCalls
{
    [TestFixture]
    public class ApiTests
    {
        
        [Test]
        public void getClans_Returns_Clan()
        {
            var apiCalls = new ApiCall();

            Assert.That(apiCalls.GetOurClan(), Is.EqualTo(34));
        }

        [Test]
        public void getPlayerInfo_Returns_Info()
        {
            var apiCalls = new ApiCall();
            var expected = apiCalls.GetPlayerInfo("#RPP222JV");
            Assert.That(expected.Name, Is.EqualTo("Dada"));
        }

        [Test]
        public void SerializeData_SerializesObject()
        {
            var serialize = new Serialize();
            var expected = serialize.SerializeData(new ClanListViewModel());
            Assert.That(expected, Is.TypeOf<string>());
        }
       
    }
}