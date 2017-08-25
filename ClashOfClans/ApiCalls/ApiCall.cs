using ClashOfClans.Models;
using RestSharp;
using System.Collections.Generic;
using ClashOfClans.Data;

namespace ClashOfClans.ApiCalls
{
    public class ApiCall
    {
        Queries database = new Queries();
        RestClient client = new RestClient("https://api.clashofclans.com/v1/");
        string token = "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6IjdiM2Y4M2ZlLWRmNDAtNDVkYS05MjYzLTU0ZTdmNDRmYzFmNiIsImlhdCI6MTUwMzI4NTUyMCwic3ViIjoiZGV2ZWxvcGVyLzhhZTlkY2MxLTY2OTctNGMwZS1jMTI1LWJkNGNkNzc0MWMwZSIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjk5LjE2NC4xNzYuMzUiLCIxMy42NS40MS4xMjciLCIxMy44NC4xODEuNDciLCIxMy42NS40Mi40MiIsIjEzLjY1LjQyLjM1Il0sInR5cGUiOiJjbGllbnQifV19.VAvdlOdT0zqjAi1ZdingQ0Id-wha25EqSZyh0CKI15UYvlyM1jKcf6icB49QKiSUzFItflIt9Ih00WGnXqbjHg";

        public void ClanApiCall()
        {
            var request = new RestRequest("clans/{clanTag}/members", Method.GET);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", token);
            request.AddParameter("clanTag", "#8UJGPROJ", ParameterType.UrlSegment);
            var response = client.Execute<ClanListViewModel>(request);
            var newList = new List<MemberModel>();
           
            foreach (var member in response.Data.Members)
            {
                newList.Add(PlayerApiCall(member.PlayerTag));
            }
            database.PopulateMembers(newList);
        }
        public MemberModel PlayerApiCall(string playerTag)
        {
            RestClient client = new RestClient("https://api.clashofclans.com/v1/");
            var request = new RestRequest("players/{playerTag}", Method.GET);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", token);
            request.AddParameter("playerTag", playerTag, ParameterType.UrlSegment);

            var response = client.Execute<MemberModel>(request);
            return response.Data;
        }

        public CurrentWar GetCurrentWar(string clanTag)
        {
            var request = new RestRequest("clans/{clanTag}/currentwar", Method.GET);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", token);
            request.AddParameter("clanTag", "#8UJGPROJ", ParameterType.UrlSegment);
            var response = client.Execute<ClanListViewModel>(request);

            return new CurrentWar();
        }
    }
}