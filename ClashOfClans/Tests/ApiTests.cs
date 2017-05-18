using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClashOfClans.Controllers;
using NUnit.Framework;

namespace ClashOfClans.Tests
{
    [TestFixture]
    public class ApiTests
    {
        HomeController homeController = new HomeController();
        [Test]
        public void getClans_Returns_Clan()
        {
            Assert.That(homeController.GetClanList("8UJGPROJ"), Is.EqualTo("In yo face"));
        }
    }
}