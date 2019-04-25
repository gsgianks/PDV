using Newtonsoft.Json;
using ServiciosCore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosCore.Utilidades.Api
{
    public partial class ApiCliente
    {
        /// <summary>
        /// Consume el método que obtiene el token
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public async Task<string> ObtenerToken()
        {
            Usuario usuario = new Usuario
            {
                Email = "eddy.gerardo@gmail.com",
                Password = "1234"
            };
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "token"));

            var respuesta = _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<Usuario>(usuario)).Result;
            respuesta.EnsureSuccessStatusCode();
            var data = respuesta.Content.ReadAsStringAsync().Result;
            var respToken = JsonConvert.DeserializeObject<JsonWebToken>(data);

            string token = respToken.access_Token;

            return $"bearer {token}";
        }
    }
}
