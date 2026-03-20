using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace Abstracciones.Modelos
{
    

    public class TipoCambioResponse
    {
        public bool estado { get; set; }
        public string mensaje { get; set; }
        public List<Datos> datos { get; set; }
    }

    public class Datos
    {
        public string titulo { get; set; }
        public List<Indicador> indicadores { get; set; }
    }

    public class Indicador
    {
        public string codigoIndicador { get; set; }
        public string nombreIndicador { get; set; }
        public List<Serie> series { get; set; }
    }

    public class Serie
    {
        public DateTime fecha { get; set; }
        public decimal valorDatoPorPeriodo { get; set; }
    }
}
