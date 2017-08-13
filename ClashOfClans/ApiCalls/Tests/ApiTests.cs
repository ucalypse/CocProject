using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClashOfClans.Controllers;
using ClashOfClans.Data;
using ClashOfClans.Models;
using NUnit.Framework;

namespace ClashOfClans.ApiCalls
{
    [TestFixture]
    public class ApiTests
    {
        ApiCall apiCalls = new ApiCall();
        Queries queries = new Queries();

        [Test]
        public void getClans_Returns_Clan()
        {
            Assert.That(apiCalls.GetOurClan(), Is.EqualTo(34));
        }

        [Test]
        public void getPlayerInfo_Returns_Info()
        {
            var expected = apiCalls.GetPlayerInfo("#RPP222JV");
            Assert.That(expected.Name, Is.EqualTo("Dada"));
            Assert.That(expected.TownHallLevel, Is.EqualTo(11));
        }

        [Test]
        public void GetMemersJson_Returns_Modified_List()
        {
            
            var testMembers = new List<Member>{new Member{Name= "Dada", TownHallLevel = 6}, new Member{Name = "Wah", TownHallLevel = 9}, new Member{Name = "Wally", TownHallLevel = 2}, new Member{Name = "Brutus", TownHallLevel = 10}};
            var expected = apiCalls.FilterMembers(testMembers, 6);
            Assert.That(expected.Count, Is.EqualTo(2));
        }
        [Test]
        public void PopulateMembers_Populates_Members()
        {
            var testMembers = new List<Member>{new Member{Name= "Dada", TownHallLevel = 6, WarStars = 123}, new Member{Name = "Wah", TownHallLevel = 9}, new Member{Name = "Wally", TownHallLevel = 2}, new Member{Name = "Brutus", TownHallLevel = 10}};
           
                queries.PopulateMembers(testMembers);
        }

        [Test]
        public void RetrieveMembers_Populates_Members()
        {
            
            var testMembers = new List<Member>
            {
                new Member {Name = "Dada",PlayerTag = "123"},
                new Member {Name = "Steve",PlayerTag = "456"},
                new Member {Name = "Wah",PlayerTag = "789"}
            };
            foreach (var member in testMembers)
            {
                queries.RetrieveMember(member.PlayerTag);
            }
            
        }
       
    }
}