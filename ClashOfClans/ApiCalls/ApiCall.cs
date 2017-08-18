using ClashOfClans.Models;
using RestSharp;
using System.Collections.Generic;
using ClashOfClans.Data;

namespace ClashOfClans.ApiCalls
{
    public class ApiCall
    {
        RestClient client = new RestClient("https://api.clashofclans.com/v1/");
        string token = "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6ImI2NjExMzIzLTA3ZTEtNDdhMi1hNmM3LWViODBjOGQwMjRlNyIsImlhdCI6MTUwMzA2Njc4NCwic3ViIjoiZGV2ZWxvcGVyLzhhZTlkY2MxLTY2OTctNGMwZS1jMTI1LWJkNGNkNzc0MWMwZSIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjEzLjY1LjQyLjM1IiwiMTMuNjUuNDIuNDIiLCIxMy44NC4xODEuNDciLCI5OS4xNjQuMTc2LjM1IiwiMTMuNjUuNDEuMTI3Il0sInR5cGUiOiJjbGllbnQifV19.OoPPUFhfEcamulBZk8LScJHFONim7uPIKt99llIpsgKEMT_8blnWT-GVBjLLRZxOr1aet0k8dLUFaOgzAVEj6w";

        public List<Member> GetOurClan()
        {
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
            RestClient client = new RestClient("https://api.clashofclans.com/v1/");
            var request = new RestRequest("players/{playerTag}", Method.GET);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", token);
            request.AddParameter("playerTag", playerTag, ParameterType.UrlSegment);

            var response = client.Execute<Member>(request);
            return response.Data;
        }
    }
}