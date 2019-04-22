using Microsoft.Azure;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace QueueExplorer
{
    class Program
    {
        static void Main(string[] args)
        {
            CloudStorageAccount miCuenta =
                CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("cadenaconexion"));

            CloudQueueClient clienteColas = miCuenta.CreateCloudQueueClient();
        }
    }
}
