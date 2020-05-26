using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.CSharp.Extensions
{
    public static class SqlDataReaderExtensions
    {
        public static string GetString(this SqlDataReader reader, string name)
        {
            return reader.GetString(reader.GetOrdinal(name));
        }

        public static int GetInt32(this SqlDataReader reader, string name)
        {
            return reader.GetInt32(reader.GetOrdinal(name));
        }

        public static float GetFloat(this SqlDataReader reader, string name)
        {
            return (float)reader.GetDouble(reader.GetOrdinal(name));
        }

        public static decimal GetDecimal(this SqlDataReader reader, string name)        {            return reader.GetDecimal(reader.GetOrdinal(name));        }
    }
}
