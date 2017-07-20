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
        CloudTable table = new CloudTable(new Uri("https://apicalls8e64.table.core.windows.net/"), new StorageCredentials("apicalls864", "F9b1FHzrrm + DXWxSUyL / +UHpu / kkIBf1BDCtkDkWpmVv8K1Q2tRHw0gvXjIAYg7kdrnl3UWE6Am8vW81ffCA5g =="));
        public int GetWarStars(string playerTag)
        {
           
            return 0;
        }
    }
}