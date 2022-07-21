using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class AppSettings
    {
        public string ApplicationName { get; set; }
        public byte MaxLoginAttempts { get; set; }
        public string JwtSecret { get; set; }
        public int JwtExpiractionLimit { get; set; }
    }
}
