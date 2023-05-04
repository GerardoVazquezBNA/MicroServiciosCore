using Newtonsoft.Json;

namespace PracticaWebApi.Entidades
{
    public class Cliente
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("apellido")]
        public string Apellido { get; set; }

        [JsonProperty("cuil")]
        public string Cuil { get; set; }

        [JsonProperty("tipoDocumento")]
        public string TipoDocumento { get; set; }

        [JsonProperty("nroDocumento")]
        public int NroDocumento { get; set; }

        [JsonProperty("esEmpleadoBNA")]
        public bool EsEmpleadoBNA { get; set; }

        [JsonProperty("paisOrigen")]
        public string PaisOrigen { get; set; }
    }
}
