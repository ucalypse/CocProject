using ClashOfClans.Models;
using RestSharp;
using System.Collections.Generic;

namespace ClashOfClans.ApiCalls
{
    public class ApiCall
    {
        RestClient azureClient = new RestClient("https://apicalls.azurewebsites.net/api/");
        RestClient client = new RestClient("https://api.clashofclans.com/v1/");

        public List<Member> GetOurClan()
        {
            var azureToken = "ct41QO9aZ8EWhu3yb80gP6a2ggH5wlpL6P0fApCPtBLnxSC4ppq/Nw==";

            var azureRequest = new RestRequest("GetClanInfo?code=CcCrot5q10/R8WKilALr1UANRmI413gRkKqeTbJjAxxy5oh3AeGoIg==", Method.GET);
            azureRequest.AddHeader("Accept", "application/json");
            var response = azureClient.Execute<ClanListViewModel>(azureRequest);
            return response.Data.Members;
        }

        public Member GetPlayerInfo(string playerTag)
        {
            var token =
                "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6ImFjYjIzYjBhLWU4NWEtNDQ4ZC1iZmNjLWM2YTBkMDhjMGJjMSIsImlhdCI6MTQ5NjE3MTQ4Niwic3ViIjoiZGV2ZWxvcGVyLzhhZTlkY2MxLTY2OTctNGMwZS1jMTI1LWJkNGNkNzc0MWMwZSIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjEzLjg0LjE4MS40NyIsIjEzLjg0LjE3OS44OCIsIjEzLjg0LjE4MS4xMTQiLCIxMy44NC4xODAuODciLCIxMy44NC4xODIuMTUxIl0sInR5cGUiOiJjbGllbnQifV19.nmpxNXGCG9hNsG5Im_nTYdePfL9s0A9nDwIgIT2Eh_4beDEppE8QpdaUGpehlOE1pTj7WyWsoJSKV9S39u8PNA";
            var request = new RestRequest("players/{playerTag}", Method.GET);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", token);
            request.AddParameter("playerTag", playerTag, ParameterType.UrlSegment);

            var response = client.Execute<Member>(request).Data;
            return response;
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
    }
}