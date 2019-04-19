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

            tabla.DeleteIfExists();            

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

            ////insertar
            //Profesor profeUno = new Profesor("007", "Profesores");

            //profeUno.NombreProfesor = "James Bond";
            //profeUno.NombreAsignatura = "Espionaje internacional";

            //TableOperation insertar = TableOperation.Insert(profeUno);

            //tabla.Execute(insertar);

            ////modificar

            //TableOperation operacionModificar = TableOperation.Retrieve<Profesor>("004", "Profesor");

            //TableResult resultadoObtenido = tabla.Execute(operacionModificar);

            //Profesor entidadEliminada = (Profesor)resultadoObtenido.Result;

            //if (entidadEliminada != null)
            //{

            //    TableOperation operacionActualizar = TableOperation.Delete(entidadEliminada);
            //    tabla.Execute(operacionActualizar);
            //    System.Console.WriteLine("Tu registro ha sido eliminado");
            //}
            //else
            //{
            //    System.Console.WriteLine("Tu entidad no existe");
            //}

            ////consulta
            //TableQuery<Profesor> consulta =
            //    new TableQuery<Profesor>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.NotEqual, "000"));

            //foreach (Profesor profe in tabla.ExecuteQuery(consulta))
            //{
            //    System.Console.WriteLine("{0}, {1}\t{2}\t{3}", profe.PartitionKey, profe.RowKey, profe.NombreProfesor, profe.NombreAsignatura);
            //}

            System.Console.WriteLine("toda tu información ha sido borrada");

            //System.Console.WriteLine("Tus entidades han sido insertadas");
           
            System.Console.ReadLine();
        }
    }
}
