using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;

namespace ClashOfClans.ApiCalls
{
    public class Clans
    {
        public IEnumerable<Clans> GetOurClan()
        {
            var client = new RestClient("http://api.clashofclans.com/v1/");
            var clanTag = "#8UJGPROJ";
            var request = new RestRequest("clans", Method.GET);
            request.AddParameter("clanTag", clanTag);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization",
                "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6IjNkMDkzZThhLWMxNTAtNDI1NS04NTA4LWMzYTBlMTU1MTMyNiIsImlhdCI6MTQ5NTE1MzMyNSwic3ViIjoiZGV2ZWxvcGVyLzEzNmQ0NzI1LTYyMWItMmY1OC1iNTcwLWM1ZGY2ZmVmN2U2MyIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjEwOC44NC4xOTguMTQiXSwidHlwZSI6ImNsaWVudCJ9XX0.hIjNh83gOEbkbLdaQn-9u8gkSxFuyOAoDaq1tarxlvpKolZh5kKQYP9MCGhitYSaeJNUuJwIm7kUTXeHXZPYug");

            Console.WriteLine("Sending request....");
            var response = client.Execute(request);
            Console.WriteLine("Request Completed....");

            var responseContent = response.Content;
            Console.WriteLine(responseContent);

            Console.ReadLine();
            return new List<Clans>();
        }
    }
}