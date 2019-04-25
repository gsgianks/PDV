using ServiciosCore.Utilidades;
using ServiciosCore.Utilidades.Api;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace POS.UI.Shared
{
    internal static class ApiClienteFactory
    {
        private static Uri apiUri;

        private static Lazy<ApiCliente> restClient = new Lazy<ApiCliente>(
          () => new ApiCliente(apiUri),
          LazyThreadSafetyMode.ExecutionAndPublication);

        static ApiClienteFactory()
        {
            //base uri
            apiUri = new Uri(ConfigurationManager.AppSettings[Constantes.ConfigKey.BaseURLApi]);
        }

        public static ApiCliente Instance
        {
            get
            {
                return restClient.Value;
            }
        }        
    }
}
