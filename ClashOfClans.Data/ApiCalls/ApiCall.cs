﻿using ClashOfClans.Models;
using RestSharp;
using System.Collections.Generic;
using ClashOfClans.Data;

namespace ClashOfClans.ApiCalls
{
    public class ApiCall
    {
        RestClient client = new RestClient("https://api.clashofclans.com/v1/");
        string token = "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6ImJjYWQxOWEyLTMyNDgtNDE2My04ZjJiLTIzNmUzMjA3NzM1MyIsImlhdCI6MTUwMTU1NzQ1Niwic3ViIjoiZGV2ZWxvcGVyLzhhZTlkY2MxLTY2OTctNGMwZS1jMTI1LWJkNGNkNzc0MWMwZSIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjEzLjg0LjE4MS40NyIsIjEzLjY1LjQyLjQyIiwiMTMuNjUuNDIuMzUiXSwidHlwZSI6ImNsaWVudCJ9XX0.tNY-RncRfJrho1AKSDSp6TLdRhBQPapiSZCJFxEOu5o7wFznq7mCQhxEwnYKkoNCkMUY0OYJh8VccHQ_Bteucw";
        QueryDatabase queryDatabase = new QueryDatabase();
        public List<Member> GetOurClan()
        {
            var request = new RestRequest("clans/{clanTag}/members", Method.GET);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", token);
            request.AddParameter("clanTag", "#8UJGPROJ", ParameterType.UrlSegment);
            var response = client.Execute<ClanListViewModel>(request);
            PopulateMembersTable(response.Data.Members);
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
            var playerRequest = new RestRequest("players/{playerTag}", Method.GET);
            playerRequest.AddHeader("Accept", "application/json");
            playerRequest.AddHeader("Authorization", token);
            playerRequest.AddParameter("playerTag", playerTag, ParameterType.UrlSegment);

            var player = client.Execute<Member>(playerRequest);
            return player.Data;
        }

        public void PopulateMembersTable(List<Member> members)
        {
            foreach (var member in members)
            {
                queryDatabase.AddMember(member);
            }
        }
    }
}