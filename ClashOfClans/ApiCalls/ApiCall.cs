﻿using ClashOfClans.Models;
using RestSharp;
using System.Collections.Generic;

namespace ClashOfClans.ApiCalls
{
    public class ApiCall
    {
        RestClient client = new RestClient("https://api.clashofclans.com/v1/");
        string token =
            "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6IjdlNWVjYWFjLWE4Y2QtNGZkNC1hNDRkLWFiMzhjNjI1ZGZhYiIsImlhdCI6MTQ5NTE2MjI3OSwic3ViIjoiZGV2ZWxvcGVyLzhhZTlkY2MxLTY2OTctNGMwZS1jMTI1LWJkNGNkNzc0MWMwZSIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjk5LjE2NC4xNzYuMzUiLCIyNTUuMjU1LjI1NS4wIl0sInR5cGUiOiJjbGllbnQifV19.tSYU-C5VOXf3goTNoGMFJc5BCEAc2WFKbLyMD_O5PPAuJ4Gy5IlhgYyawE4wG36OIux_BrBqW1wdeBudO73dCQ";
        string productionToken =
            "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6ImFjYjIzYjBhLWU4NWEtNDQ4ZC1iZmNjLWM2YTBkMDhjMGJjMSIsImlhdCI6MTQ5NjE3MTQ4Niwic3ViIjoiZGV2ZWxvcGVyLzhhZTlkY2MxLTY2OTctNGMwZS1jMTI1LWJkNGNkNzc0MWMwZSIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjEzLjg0LjE4MS40NyIsIjEzLjg0LjE3OS44OCIsIjEzLjg0LjE4MS4xMTQiLCIxMy44NC4xODAuODciLCIxMy44NC4xODIuMTUxIl0sInR5cGUiOiJjbGllbnQifV19.nmpxNXGCG9hNsG5Im_nTYdePfL9s0A9nDwIgIT2Eh_4beDEppE8QpdaUGpehlOE1pTj7WyWsoJSKV9S39u8PNA";
        public List<Member> GetOurClan()
        {

            var request = new RestRequest("clans/{clanTag}/members", Method.GET);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", token);
            request.AddParameter("clanTag", "#8UJGPROJ", ParameterType.UrlSegment);

            var response = client.Execute<ClanListViewModel>(request);

            return response.Data.Members;

           // return new List<Member>();
        }

        public Member GetPlayerInfo(string playerTag)
        {
            var token =
                "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6IjdlNWVjYWFjLWE4Y2QtNGZkNC1hNDRkLWFiMzhjNjI1ZGZhYiIsImlhdCI6MTQ5NTE2MjI3OSwic3ViIjoiZGV2ZWxvcGVyLzhhZTlkY2MxLTY2OTctNGMwZS1jMTI1LWJkNGNkNzc0MWMwZSIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjk5LjE2NC4xNzYuMzUiLCIyNTUuMjU1LjI1NS4wIl0sInR5cGUiOiJjbGllbnQifV19.tSYU-C5VOXf3goTNoGMFJc5BCEAc2WFKbLyMD_O5PPAuJ4Gy5IlhgYyawE4wG36OIux_BrBqW1wdeBudO73dCQ";
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