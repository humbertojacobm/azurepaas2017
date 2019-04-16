
using Microsoft.Azure;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.File;

namespace FileExplorer
{
    class Program
    {
        static void Main(string[] args)
        {
            CloudStorageAccount cuentaAlmacenamiento =
                CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("cadenaConexion"));

        }
    }
}
