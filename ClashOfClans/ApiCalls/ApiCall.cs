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
            //return response.Data.Members;
            return new List<Member>();
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