using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace WindowsFormsApp3
{
    public class Class3
    {
        private static string path = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Baza_dannykh7.accdb";
        private OleDbConnection connection = new OleDbConnection(path);

        public DataTable DGW_table()
        {
            string query = $"SELECT * FROM [Аудитории]";
            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();
            return table;
        }
        public DataTable GetKor()
        {
            string query = $"SELECT [ID],[Название] FROM [Корпус]";
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
        public void UpdateDB(int number, int corpus, int responsible, string ID)
        {

            int id = int.Parse(ID);

            connection.Open();
            OleDbCommand commP = connection.CreateCommand();
            commP.CommandText = $"UPDATE [Аудитории] SET [Номер]='{number}' , [Корпус]='{corpus}', [Ответственный]='{responsible}' WHERE ID={id}";
            commP.ExecuteNonQuery();
            connection.Close();
        }
        public void DeleteBD(string ID)
        {
            int id = int.Parse(ID);
            connection.Open();
            OleDbCommand commP = connection.CreateCommand();
            commP.CommandText = $"DELETE FROM [Аудитории] WHERE [ID] = {id}";
            commP.ExecuteNonQuery();
            connection.Close();
        }

        public void InsertBD(int number, int corpus, int responsible, int ID)
        {
            connection.Open();
            OleDbCommand commP = connection.CreateCommand();
            commP.CommandText = $"INSERT INTO [Аудитории] ([Номер],[Корпус],[Ответственный], [ID]) VALUES('{number}','{corpus}','{responsible}','{ID}')";
            commP.ExecuteNonQuery();
            connection.Close();
        }
    }
}
