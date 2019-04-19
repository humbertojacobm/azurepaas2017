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

            //Profesor profeUno = new Profesor("001", "Profesores");

            //profeUno.NombreProfesor = "Ricardo Celis";
            //profeUno.NombreAsignatura = "Microcontraladores";

            //Profesor profeDos = new Profesor("002", "Profesores");

            //profeDos.NombreProfesor = "Carlos Paredes";
            //profeDos.NombreAsignatura = "Diseño audiovisual";

            //TableOperation insertarProfeUno = TableOperation.Insert(profeUno);

            //TableOperation insertarProfeDos = TableOperation.Insert(profeDos);

            //tabla.Execute(insertarProfeUno);

            //tabla.Execute(insertarProfeDos);

            //TableQuery<Profesor> consulta =
            //    new TableQuery<Profesor>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.NotEqual, "001"));

            //foreach (Profesor profe in tabla.ExecuteQuery(consulta))
            //{
            //    System.Console.WriteLine("{0}, {1}\t{2}\t{3}",profe.PartitionKey, profe.RowKey, profe.NombreProfesor, profe.NombreAsignatura);
            //}

            TableOperation operacionModificar = TableOperation.Retrieve<Profesor>("002", "Profesores");

            TableResult resultadoObtenido = tabla.Execute(operacionModificar);

            Profesor entidadModificada = (Profesor)resultadoObtenido.Result;

            if (entidadModificada != null)
            {
                entidadModificada.NombreAsignatura = "Diseñño audio visual";
                TableOperation operacionActualizar = TableOperation.Replace(entidadModificada);
                tabla.Execute(operacionActualizar);
                System.Console.WriteLine("Tu registro ha sido modificado");
            }
            else
            {
                System.Console.WriteLine("Tu entidad no existe");
            }

            TableQuery<Profesor> consulta =
                new TableQuery<Profesor>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.NotEqual, "000"));

            foreach (Profesor profe in tabla.ExecuteQuery(consulta))
            {
                System.Console.WriteLine("{0}, {1}\t{2}\t{3}", profe.PartitionKey, profe.RowKey, profe.NombreProfesor, profe.NombreAsignatura);
            }

            System.Console.WriteLine("Lista de profesores obtenida");

            //System.Console.WriteLine("Tus entidades han sido insertadas");
           
            System.Console.ReadLine();
        }
    }
}
