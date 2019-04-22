
using System.IO;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Blob;
using System;

namespace QueueHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            CloudStorageAccount miCuenta =
                CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("cadenaconexion"));

            CloudQueueClient clienteColas = miCuenta.CreateCloudQueueClient();

            CloudQueue queue = clienteColas.GetQueueReference("mifiladeprocesos");

            CloudQueueMessage peekedMessage = queue.PeekMessage();

            foreach (CloudQueueMessage item in queue.GetMessages(250))
            {
                string rutaArchivo = string.Format(@"c:\Tempr\log{0}.txt", item.Id);
                TextWriter archivoTemp = File.CreateText(rutaArchivo);
                var mensaje = queue.GetMessage().AsString;
                archivoTemp.WriteLine(mensaje);
                Console.WriteLine("Archivo creado");
                archivoTemp.Close();
            }

        }
    }
}
