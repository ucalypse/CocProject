using System;
using ClashOfClans.ApiCalls;
using ClashOfClans.Data;
using NUnit.Framework;

namespace ClashOfClans.Tests
{
    [TestFixture]
    public class ApiCallTests
    {
        ApiCall apiCall = new ApiCall();
        [Test]
        public void PlayerApiCall_Returns_Member()
        {
            var testMember = new MemberModel
            {
                Name = "Dada",
                PlayerTag = "#RPP222JV",
                Level = 186,
                WarStars = 720,
                TownHallLevel = 11
            };

            var samplePlayer = apiCall.PlayerApiCall(testMember.PlayerTag);
            Assert.That(samplePlayer.Name, Is.EqualTo("Dada"));
        }
    }
}
