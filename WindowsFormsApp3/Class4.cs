using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace WindowsFormsApp3
{
    public class Class4
    {
        private static string path = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Baza_dannykh7.accdb";
        private OleDbConnection connection = new OleDbConnection(path);

        public DataTable DGW_table()
        {
            string query = $"SELECT * FROM [Корпус]";
            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();
            return table;
        }
        public DataTable GetOt()
        {
            string query = $"SELECT [ID],[ФИО] FROM [Сотрудник]";
            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();
            return table;
        }
        public void UpdateDB(string adres, string name, int responsible, string ID)
        {

            int id = int.Parse(ID);

            connection.Open();
            OleDbCommand commP = connection.CreateCommand();
            commP.CommandText = $"UPDATE [Корпус] SET [Адрес]='{adres}' , [Название]='{name}', [Заведующий]='{responsible}' WHERE ID={id}";
            commP.ExecuteNonQuery();
            connection.Close();
        }
        public void DeleteBD(string ID)
        {
            int id = int.Parse(ID);
            connection.Open();
            OleDbCommand commP = connection.CreateCommand();
            commP.CommandText = $"DELETE FROM [Корпус] WHERE [ID] = {id}";
            commP.ExecuteNonQuery();
            connection.Close();
        }

        public void InsertBD(string adres, string name, int responsible, int ID)
        {
            connection.Open();
            OleDbCommand commP = connection.CreateCommand();
            commP.CommandText = $"INSERT INTO [Корпус] ([Адрес],[Название],[Заведующий], [ID]) VALUES('{adres}','{name}','{responsible}','{ID}')";
            commP.ExecuteNonQuery();
            connection.Close();
        }
    }
}
