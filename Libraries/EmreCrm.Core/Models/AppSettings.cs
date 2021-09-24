using System;
using System.Collections.Generic;
using System.Text;

namespace EmreCrm.Core.Models
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; }
    }

    public class Redis
    {
        public string ConnectionString { get; set; }
    }

    public class JwtConfiguration
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SigningKey { get; set; }
    }

    public class AppSettings
    {
        public string AppName { get; set; }

        public Redis Redis { get; set; }

        public DatabaseSettings DatabaseSettings { get; set; }

        public JwtConfiguration JwtConfiguration { get; set; }
    }
}
