using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.Azure;

namespace BlobExplorer
{
    class Program
    {
        static void Main(string[] args)
        {

            CloudStorageAccount cuentaAlmacenamiento =
                CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudBlobClient clienteBlob = cuentaAlmacenamiento.CreateCloudBlobClient();
            CloudBlobContainer contenedor = clienteBlob.GetContainerReference("contenedorcodigo");

            //to create container

            //contenedor.CreateIfNotExists();
            //contenedor.SetPermissions(new BlobContainerPermissions {PublicAccess = BlobContainerPublicAccessType.Blob});

            CloudBlockBlob miBlob = contenedor.GetBlockBlobReference("foto.jpg");

            using ( var fileStream = System.IO.File.OpenRead(@"c:\\vane.jpg"))
            {
                miBlob.UploadFromStream(fileStream);

            }

            Console.WriteLine("Tu contenedor esta listo y creado");
            Console.ReadLine();

        }
    }
}
