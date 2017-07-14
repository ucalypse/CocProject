using System;
using System.Configuration;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage; 
using Microsoft.WindowsAzure.Storage.Blob; 
using Microsoft.WindowsAzure.Storage.File;

namespace MediaContent
{
    public class FileGetter
    {
        public void GetVideo()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting(
                    "DefaultEndpointsProtocol=https;AccountName=cs2f8f00c4e0061x4b5bx89e;AccountKey=G9i5mZZ7LktofYdhJvDVNURFtnmzGOuxAjCmiFCEAXf5edp6Z4YQteXnpm97cbpgD4wP4uWhjPu2u9MI6Xs3hg==;EndpointSuffix=core.windows.net"));

            // Create a CloudFileClient object for credentialed access to Azure File storage.
            CloudFileClient fileClient = storageAccount.CreateCloudFileClient();

            // Get a reference to the file share we created previously.
            CloudFileShare share = fileClient.GetShareReference("logs");
        }
    }
}