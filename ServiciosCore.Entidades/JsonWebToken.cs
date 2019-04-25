using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosCore.Entidades
{
    public class JsonWebToken
    {
        public string access_Token { get; set; }
        public string token_Type { get; set; } = "bearer";
        public int expires_in { get; set; }
        public string refresh_Token { get; set; }
    }
}
