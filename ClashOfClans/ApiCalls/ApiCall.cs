using ClashOfClans.Models;
using RestSharp;
using System.Collections.Generic;

namespace ClashOfClans.ApiCalls
{
    public class ApiCall
    {
        RestClient azureClient = new RestClient("https://apicalls.azurewebsites.net/api/");
       
        public List<Member> GetOurClan()
        {
            var azureToken = "ct41QO9aZ8EWhu3yb80gP6a2ggH5wlpL6P0fApCPtBLnxSC4ppq/Nw==";

            var azureRequest = new RestRequest("HttpTriggerCSharp2?", Method.GET);
            azureRequest.AddHeader("Accept", "application/json");
            azureRequest.AddParameter("code", azureToken);

            var response = azureClient.Execute<ClanListViewModel>(azureRequest);

            return response.Data.Members;
        }

        public Member GetPlayerInfo(string playerTag)
        {
            var token =
                "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6IjdlNWVjYWFjLWE4Y2QtNGZkNC1hNDRkLWFiMzhjNjI1ZGZhYiIsImlhdCI6MTQ5NTE2MjI3OSwic3ViIjoiZGV2ZWxvcGVyLzhhZTlkY2MxLTY2OTctNGMwZS1jMTI1LWJkNGNkNzc0MWMwZSIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjk5LjE2NC4xNzYuMzUiLCIyNTUuMjU1LjI1NS4wIl0sInR5cGUiOiJjbGllbnQifV19.tSYU-C5VOXf3goTNoGMFJc5BCEAc2WFKbLyMD_O5PPAuJ4Gy5IlhgYyawE4wG36OIux_BrBqW1wdeBudO73dCQ";
            var request = new RestRequest("players/{playerTag}", Method.GET);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", token);
            request.AddParameter("playerTag", playerTag, ParameterType.UrlSegment);

           // var response = client.Execute<Member>(request).Data;
           // return response;
            return new Member();
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