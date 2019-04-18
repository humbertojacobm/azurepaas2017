using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace TableExplorer.Entidades
{
    public class Profesor: TableEntity
    {
        public Profesor(string identificador, string categoria)
        {
            this.PartitionKey = identificador;
            this.RowKey = categoria;
        }
        public Profesor()
        {

        }

        public string NombreProfesor { get; set; }
        public string NombreAsignatura { get; set; }


    }
}
