using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiNetCore.Jwt
{
    public class JwtConfiguration
    {
        public string Issuer { get; set; }
        public string Secret { get; set; }
    }
}
