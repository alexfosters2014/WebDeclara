using ServerDeclara.Utilidades;

namespace ServerDeclara.Servicios
{
    public static class Calculos
    {

        //public static double RentaMensual_Recusivo(List<Parametros> parametrosRenta, int indice, double ingAnticipo, double diferencia, double auxRenta, double impuestoValor)
        //{
        //    if (indice == parametros.Count)
        //    {
        //        return impuestoValor;
        //    }

        //    if (indice == 0)
        //    {
        //        auxRenta = ingAnticipo;
        //    }
        //    else
        //    {
        //        auxRenta = auxRenta > diferencia ? auxRenta - diferencia : 0;
        //    }

        //    diferencia = parametros[indice].RangoHasta - parametros[indice].RangoDesde;

        //    double ingresoMinimo = Math.Min(auxRenta, diferencia);
        //    double valorImpuesto = ingresoMinimo * parametros[indice].Valor / 100;

        //    impuestoValor += Math.Round(valorImpuesto, 2);


        //    indice++;

        //    return CaluloRentaMensual_Recusivo(parametros, indice, ingAnticipo, diferencia, auxRenta, impuestoValor);

        //}
    }
}
