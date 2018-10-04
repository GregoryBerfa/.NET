using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CorrectionPanier.Classes
{
    public sealed class Connection
    {
        private static SqlConnection instance = null;
        private static string connectionString = @"Data Source=(localdb)\CoursSql;Integrated Security=True";
        private static readonly object lockobject = new object();

        private Connection()
        {

        }

        public static SqlConnection Instance
        {
            get
            {
                lock (lockobject)
                {
                    if (instance == null)
                    {
                        instance = new SqlConnection(connectionString);
                    }
                    return instance;
                }
            }
        }
    }
}