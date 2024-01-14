using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using ServerDeclara.DTOs;
using ServerDeclara.Utilidades;

namespace ServerDeclara.Servicios
{
    public static class Calculos
    {

        public static double RentaMensual_Recusivo(List<ParametroDTO> parametrosRenta, int indice, double ingAnticipo, double diferencia, double auxRenta, double impuestoValor, double BPC, int cantidadParametros)
        {

            if (indice == cantidadParametros)
            {
                return impuestoValor;
            }

            if (indice == 0)
            {
                auxRenta = ingAnticipo;
            }
            else
            {
                auxRenta = auxRenta > diferencia ? auxRenta - diferencia : 0;
            }

            diferencia = parametrosRenta[indice].IngresosDesde * BPC - parametrosRenta[indice].IngresosHasta * BPC;

            double ingresoMinimo = Math.Min(auxRenta, diferencia);
            double valorImpuesto = ingresoMinimo * parametrosRenta[indice].Tasa;

            impuestoValor += Math.Round(valorImpuesto, 2);

            indice++;

            return RentaMensual_Recusivo(parametrosRenta, indice, ingAnticipo, diferencia, auxRenta, impuestoValor, BPC, cantidadParametros);

        }
    }
}
