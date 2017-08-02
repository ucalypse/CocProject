using ClashOfClans.Models;
using RestSharp;
using System.Collections.Generic;

namespace ClashOfClans.ApiCalls
{
    public class ApiCall
    {
        RestClient client = new RestClient("https://api.clashofclans.com/v1/");

        public List<Member> GetOurClan()
        {
            string token = "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6ImJjYWQxOWEyLTMyNDgtNDE2My04ZjJiLTIzNmUzMjA3NzM1MyIsImlhdCI6MTUwMTU1NzQ1Niwic3ViIjoiZGV2ZWxvcGVyLzhhZTlkY2MxLTY2OTctNGMwZS1jMTI1LWJkNGNkNzc0MWMwZSIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjEzLjg0LjE4MS40NyIsIjEzLjY1LjQyLjQyIiwiMTMuNjUuNDIuMzUiXSwidHlwZSI6ImNsaWVudCJ9XX0.tNY-RncRfJrho1AKSDSp6TLdRhBQPapiSZCJFxEOu5o7wFznq7mCQhxEwnYKkoNCkMUY0OYJh8VccHQ_Bteucw";

            var request = new RestRequest("clans/{clanTag}/members", Method.GET);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", token);
            request.AddParameter("clanTag", "#8UJGPROJ", ParameterType.UrlSegment);
            var response = client.Execute<ClanListViewModel>(request);
            return response.Data.Members;
        }
        public List<Member> FilterMembers(List<Member> filterList, int townHallLevel)
        {
            var filteredList = new List<Member>();
            foreach (var member in filterList)
            {
                if (member.TownHallLevel <= townHallLevel)
                {
                    filteredList.Add(member);
                }
            }
            return filteredList;
        }

        public Member GetPlayerInfo(string playerTag)
        {
            return new Member();
        }
    }
}