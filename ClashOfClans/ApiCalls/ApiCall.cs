using ClashOfClans.Models;
using RestSharp;
using System.Collections.Generic;
using ClashOfClans.Data;

namespace ClashOfClans.ApiCalls
{
    public class ApiCall
    {
        RestClient client = new RestClient("https://api.clashofclans.com/v1/");
        string token = "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6IjQ5ODZmNDE1LTJjNWQtNDI2Ny05Y2U0LTNhNzA1ODYwMzAwMyIsImlhdCI6MTUwMzA4MzU5Mywic3ViIjoiZGV2ZWxvcGVyLzhhZTlkY2MxLTY2OTctNGMwZS1jMTI1LWJkNGNkNzc0MWMwZSIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjE1Mi4xNzkuNy4yMDYiLCIxMy42NS40Mi4zNSIsIjEzLjY1LjQyLjQyIiwiMTMuODQuMTgxLjQ3IiwiMTMuNjUuNDEuMTI3Il0sInR5cGUiOiJjbGllbnQifV19.qTJbcUfBTRpEh2Hrx-K600GgnPYtTpJVAzZWjFODAovTdVxc4Cww35Yt5XdNf_nz-1NlC7abuZw9F9XParHnLA";

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