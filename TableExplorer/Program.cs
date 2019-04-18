using Microsoft.Azure;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using TableExplorer.Entidades;

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

            //tabla.CreateIfNotExists();

            //var nombreTablas = clienteTablas.ListTables();

            //foreach (CloudTable item in nombreTablas)
            //{
            //    System.Console.WriteLine(item.Name);
            //}

            Profesor profeUno = new Profesor("001", "Profesores");

            profeUno.NombreProfesor = "Ricardo Celis";
            profeUno.NombreAsignatura = "Microcontraladores";

            Profesor profeDos = new Profesor("002", "Profesores");

            profeDos.NombreProfesor = "Carlos Paredes";
            profeDos.NombreAsignatura = "Diseño audiovisual";

            TableOperation insertarProfeUno = TableOperation.Insert(profeUno);

            TableOperation insertarProfeDos = TableOperation.Insert(profeDos);

            tabla.Execute(insertarProfeUno);

            tabla.Execute(insertarProfeDos);

            System.Console.WriteLine("Tus entidades han sido insertadas");
           
            System.Console.ReadLine();
        }
    }
}
