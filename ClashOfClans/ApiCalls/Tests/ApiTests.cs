using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClashOfClans.Controllers;
using NUnit.Framework;

namespace ClashOfClans.ApiCalls
{
    [TestFixture]
    public class ApiTests
    {
        
        [Test]
        public void getClans_Returns_Clan()
        {
            var clan = new Clan();
            Assert.That(clan.GetOurClan(), Is.EqualTo("1"));
        }
       
    }
}