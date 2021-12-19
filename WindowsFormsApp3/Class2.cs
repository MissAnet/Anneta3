using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace WindowsFormsApp3
{
    public class Class2
    {
        private static string path = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Baza_dannykh7.accdb";
        private OleDbConnection connection = new OleDbConnection(path);

        public DataTable DGW_table()
        {
            string query = $"SELECT * FROM [Кафедры]";
            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();
            return table;
        }
        public void UpdateDB(string direction,string Manager, string ID)
        {

            int id = int.Parse(ID);
            int manager = int.Parse(Manager);

            connection.Open();
            OleDbCommand commP = connection.CreateCommand();
            commP.CommandText = $"UPDATE [Кафедры] SET [Направление]='{direction}' , [Заведующий]='{manager}' WHERE ID={id}";
            commP.ExecuteNonQuery();
            connection.Close();
        }
        public void DeleteBD(string ID)
        {
            int id = int.Parse(ID);
            connection.Open();
            OleDbCommand commP = connection.CreateCommand();
            commP.CommandText = $"DELETE FROM [Кафедры] WHERE [ID] = {id}";
            commP.ExecuteNonQuery();
            connection.Close();
        }

        public void InsertBD(string direction, string Manager, int ID)
        {
            int manager = Convert.ToInt32(Manager);

            connection.Open();
            OleDbCommand commP = connection.CreateCommand();
            commP.CommandText = $"INSERT INTO [Кафедры] ([Направление],[Заведующий], [ID]) VALUES('{direction}','{manager}','{ID}')";
            commP.ExecuteNonQuery();
            connection.Close();
        }
    }
}
