using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace GrifindoPS.config
{
    // DB Connection
    public struct DB
    {
        public string data_source { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public string initial_catalog { get; set; }
        public bool integrated_sec { get; set; }
    }

    internal class DBConnection
    {
        public readonly SqlConnection server;
        public DBConnection(DB db_properties)
        {
            // creating the connection string using the DB struct
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = db_properties.data_source;
            builder.InitialCatalog = db_properties.initial_catalog;
            if (db_properties.integrated_sec)
            {
                builder.IntegratedSecurity = true;
            }
            else
            {
                builder.UserID = db_properties.user;
                builder.Password = db_properties.password;

            }

            server = new(builder.ConnectionString);
            // Openning the connection
            Open();
        }

        public void Open()
        {
            try
            {
                server.Open();
                MessageBox.Show("DB connection is opened.", "Grifindo - DB Connection", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Grifindo - DB Connection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Close()
        {
            try
            {
                server.Close();
                MessageBox.Show("DB connection is closed.", "Grifindo - DB Connection", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Grifindo - DB Connection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
