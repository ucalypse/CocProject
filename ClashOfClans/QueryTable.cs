using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using RestSharp;

namespace ClashOfClans
{
    public class QueryTable
    {
        public string storageName = "apicallse64";
        public string credentials =
            "F9b1FHzrrm + DXWxSUyL / +UHpu / kkIBf1BDCtkDkWpmVv8K1Q2tRHw0gvXjIAYg7kdrnl3UWE6Am8vW81ffCA5g ==";
        public string baseUri = "https://apicalls8e64.table.core.windows.net/";


        
        public int GetWarStars(string playerTag)
        {
            CloudTable table = new CloudTable(new Uri(baseUri), new StorageCredentials(storageName, credentials));
            CloudTableClient client = new CloudTableClient(new Uri(baseUri), new StorageCredentials(storageName, credentials));

            return 0;
        }
    }
}