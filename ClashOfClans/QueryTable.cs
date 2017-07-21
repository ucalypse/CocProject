using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClashOfClans
{
    public class QueryTable
    {
        public string storageName = "apicalls8e64";
        public string credentials =
            "F9b1FHzrrm + DXWxSUyL / +UHpu / kkIBf1BDCtkDkWpmVv8K1Q2tRHw0gvXjIAYg7kdrnl3UWE6Am8vW81ffCA5g ==";
        public string baseUri = "https://apicalls8e64.table.core.windows.net/";



        public int GetWarStars(string playerTag)
        {
            CloudTableClient client = new CloudTableClient(new Uri(baseUri), new StorageCredentials(storageName, credentials));
            CloudTable table = client.GetTableReference("Members");
            TableQuery<Member> query = new TableQuery<Member>()
                .Where(TableQuery.GenerateFilterCondition("Tag", QueryComparisons.Equal, playerTag));

            return table.ExecuteQuery(query).Single().WarStars;
        }

        public Member GetPlayerInfo(string playerTag)
        {
            CloudTableClient client = new CloudTableClient(new Uri(baseUri), new StorageCredentials(storageName, credentials));
            CloudTable table = client.GetTableReference("Members");
            TableQuery<Member> query = new TableQuery<Member>()
                .Where(TableQuery.GenerateFilterCondition("Tag", QueryComparisons.Equal, playerTag));

            return table.ExecuteQuery(query).Single();
        }
    }
}