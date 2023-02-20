using System;

namespace ConfigConnectionString
{
    [assembly: InternalsVisibleToAttribute("01. ADO.NET - Exercises")]
    internal static class ConnectionString
    {
        public const string ConfigString =
            @"Data Source = fsc-avconsulting.ch, 1433; Initial Catalog = MinionsDB; User ID = SA; Password = S0ftUn12023@; TrustServerCertificate=True";
    }
}

