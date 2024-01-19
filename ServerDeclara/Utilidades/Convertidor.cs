using Microsoft.EntityFrameworkCore.Metadata;
using ServerDeclara.Datos;
using ServerDeclara.DTOs;
using System.Data;
using System.Drawing;
using System.Reflection;

namespace ServerDeclara.Utilidades
{
    public static class Convertidor
    {
        public static DataTable CrearColumnasDatatableDesdeDeclaracion(List<ParametroDTO> parametros, DeclaracionMensualIRPFDTO declaracionMes)
        {
            DataTable miTabla = new();
            Type declaracion = declaracionMes.GetType();

            // Obtener las propiedades de la clase Persona
            PropertyInfo[] propiedades = declaracion.GetProperties();

            foreach (var propiedad in propiedades)
            {
                DataColumn nuevaColumna = new DataColumn(propiedad.Name, propiedad.PropertyType);
                miTabla.Columns.Add(nuevaColumna);
            }


            foreach (var propiedad in propiedades)
            {
                DataColumn seleccionColumna = miTabla.Columns[propiedad.Name];
                ParametroDTO parametro = parametros.SingleOrDefault(s => s.Atributo == propiedad.Name);

                if (parametro != null)
                {
                    seleccionColumna.Expression = parametro.Formula;
                }
                else
                {
                    seleccionColumna.DefaultValue = propiedad.GetValue(declaracionMes);
                }
            }

            return miTabla;
        }

        public static DeclaracionMensualIRPFDTO DeclaracionDesdeDatatable(DataTable declaracionDT)
        {
            string[] nombresPropiedades = ObtenerNombresColumnas(declaracionDT);
            DeclaracionMensualIRPFDTO declaracion = new();

            for (int i = 0; i < nombresPropiedades.Length; i++)
            {
                string nombreProp = nombresPropiedades[i];
                PropertyInfo propiedad = declaracion.GetType().GetProperty(nombreProp);
                propiedad.SetValue(declaracion, Convert.ChangeType(declaracionDT.Rows[0][nombreProp], propiedad.PropertyType));
            }

            return declaracion;
        }

        private static string[] ObtenerNombresColumnas(DataTable dataTable)
        {
            // Crear un array para almacenar los nombres de las columnas
            string[] nombresColumnas = new string[dataTable.Columns.Count];

            // Iterar a través de las columnas y guardar los nombres en el array
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                nombresColumnas[i] = dataTable.Columns[i].ColumnName;
            }

            return nombresColumnas;
        }


    }
}
