using Microsoft.EntityFrameworkCore.Metadata;
using ServerDeclara.Datos;
using ServerDeclara.DTOs;
using ServerDeclara.Utilidades;
using System.Data;
using System.Reflection;
using System.Xml.Linq;

namespace ServerDeclara.Servicios
{
    public static class CalculosIRPFServicio
    {
        
        public static BimensualIRPF_DTO GenerarCalculos(BimensualIRPF_DTO bimensualDeclaracion)
        {
            var parametros = bimensualDeclaracion.GetParametros();
            DeclaracionMensualIRPFDTO LiquidacionMes1 = CalculosIRPFServicio.DeclaracionIRPFMes(parametros, bimensualDeclaracion.DeclaracionMes1);
            DeclaracionMensualIRPFDTO LiquidacionMes2 = CalculosIRPFServicio.DeclaracionIRPFMes(parametros, bimensualDeclaracion.DeclaracionMes2);

            bimensualDeclaracion.DeclaracionMes1 = LiquidacionMes1;
            bimensualDeclaracion.DeclaracionMes2 = LiquidacionMes2;


            return bimensualDeclaracion;
        }


        private static DeclaracionMensualIRPFDTO DeclaracionIRPFMes(List<ParametroDTO> parametros, DeclaracionMensualIRPFDTO declaracionMes)
        {
            DeclaracionMensualIRPFDTO declaracion = new();

            DataTable declaracionDT = Convertidor.CrearColumnasDatatableDesdeDeclaracion(parametros,declaracionMes);
           
            var paramRenta = CalculosIRPFServicio.GetParametrosRenta(parametros);

            DataRow fila = declaracionDT.NewRow();

            declaracionDT.Rows.Add(fila);

            double valor = RentaMensual_Recusivo(paramRenta, 0, (double)declaracionDT.Rows[0]["IngParaAnticipo"], 0, 0, 0, (double)declaracionDT.Rows[0]["BPC"], paramRenta.Count);

            declaracionDT.Rows[0]["LiquidacionIngresos"] = valor;

            declaracion = Convertidor.DeclaracionDesdeDatatable(declaracionDT);

            return declaracion;
        }



        private static List<ParametroDTO>  GetParametrosRenta(List<ParametroDTO> parametros)
        {
            return parametros.Where(w => w.Tipo == Constantes.TIPO_RENTA).OrderBy(o => o.Orden).ToList();
        }
        private static double RentaMensual_Recusivo(List<ParametroDTO> parametrosRenta, int indice, double ingAnticipo, double diferencia, double auxRenta, double impuestoValor, double BPC, int cantidadParametros)
        {

            if (indice == cantidadParametros)
            {
                return Math.Round(impuestoValor);
            }

            if (indice == 0)
            {
                auxRenta = ingAnticipo;
            }
            else
            {
                auxRenta = auxRenta > diferencia ? auxRenta - diferencia : 0;
            }

            diferencia = parametrosRenta[indice].IngresosHasta * BPC - parametrosRenta[indice].IngresosDesde * BPC;

            double ingresoMinimo = Math.Min(auxRenta, diferencia);
            double valorImpuesto = ingresoMinimo * parametrosRenta[indice].Tasa;

            impuestoValor += Math.Round(valorImpuesto, 2);

            indice++;

            return RentaMensual_Recusivo(parametrosRenta, indice, ingAnticipo, diferencia, auxRenta, impuestoValor, BPC, cantidadParametros);

        }


    }
}
