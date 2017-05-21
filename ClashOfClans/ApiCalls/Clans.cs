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
        
                       var client = new RestClient("https://api.clashofclans.com/v1/");
           
                       var request = new RestRequest("clans/{clanTag}", Method.GET);
                       
        
                  request.AddHeader("Accept", "application/json");
                  request.AddHeader("Authorization",
                          "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6IjdlNWVjYWFjLWE4Y2QtNGZkNC1hNDRkLWFiMzhjNjI1ZGZhYiIsImlhdCI6MTQ5NTE2MjI3OSwic3ViIjoiZGV2ZWxvcGVyLzhhZTlkY2MxLTY2OTctNGMwZS1jMTI1LWJkNGNkNzc0MWMwZSIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjk5LjE2NC4xNzYuMzUiLCIyNTUuMjU1LjI1NS4wIl0sInR5cGUiOiJjbGllbnQifV19.tSYU-C5VOXf3goTNoGMFJc5BCEAc2WFKbLyMD_O5PPAuJ4Gy5IlhgYyawE4wG36OIux_BrBqW1wdeBudO73dCQ");
            request.AddParameter("clanTag", "#8UJGPROJ", ParameterType.UrlSegment);
            Console.WriteLine("Sending request....");
            foreach (var item in request.Parameters)
            {
                Console.Write(item);
            }

            var response = client.Execute(request);
                      Console.WriteLine("Request Completed....");
        
                  var responseContent = response.Content;
        
                    Console.Write(responseContent);
                    return new List<Clans>();
        }
    }
}