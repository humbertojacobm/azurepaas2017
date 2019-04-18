using Microsoft.Azure;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace TableExplorer
{
    class Program
    {
        static void Main(string[] args)
        {
            CloudStorageAccount cuentaAlmacenamiento =
                CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("cadenaconexion"));
            CloudTableClient clienteTablas = cuentaAlmacenamiento.CreateCloudTableClient();
            CloudTable tabla = clienteTablas.GetTableReference("clases");

            tabla.CreateIfNotExists();

            var nombreTablas = clienteTablas.ListTables();

            foreach (CloudTable item in nombreTablas)
            {
                System.Console.WriteLine(item.Name);
            }

            System.Console.ReadLine();
        }
    }
}
