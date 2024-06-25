
using System;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace BackFacture.app
{
    public class MiClaseEjemplo
    {
        public string MiMetodoText(dynamic data)
        {
            return $"Método ejecutado con data: {data} y entorno: {Config.Enviroment}";
        }

        public Response MiMetodoJson(JObject data)
        {
            string mensaje = $"Método ejecutado por: {Config.User} y entorno: {Config.Enviroment}";

            if (Config.Verbose)
            {
                // Procesar los datos y generar la respuesta
                Console.WriteLine(mensaje);
            }
            // Crear y retornar un objeto Response
            return new Response(ResponseStatus.Success, mensaje, data);
        }
    }
}
