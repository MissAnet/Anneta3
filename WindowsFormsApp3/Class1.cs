using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace WindowsFormsApp3
{
    public class Class1
    {
        private static string path = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Baza_dannykh7.accdb";
        private OleDbConnection connection = new OleDbConnection(path);

        public DataTable DGW_table()
        {
            string query = $"SELECT * FROM [Сотрудник]";
            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();
            return table;
        }
        public void UpdateDB(string name, string Experience, string Age, string education, string Pulpit, string ID)
        {
            int id = int.Parse(ID);
            int age = int.Parse(Age);
            int experience = int.Parse(Experience);
            int pulpit = int.Parse(Pulpit);

            connection.Open();
            OleDbCommand commP = connection.CreateCommand();
            commP.CommandText = $"UPDATE [Сотрудник] SET [ФИО]='{name}' ,[Стаж]='{experience} ' ,[Возраст]='{age}' ,[Образование]='{education}' ,[Кафедра]='{pulpit}' WHERE ID={id}";
            commP.ExecuteNonQuery();
            connection.Close();
        }
        public void DeleteBD(string ID)
        {
            int id = int.Parse(ID);
            connection.Open();
            OleDbCommand commP = connection.CreateCommand();
            commP.CommandText = $"DELETE FROM [Сотрудник] WHERE [ID] = {id}";
            commP.ExecuteNonQuery();
            connection.Close();
        }

        public void InsertBD(string name, string Experience, string Age, string education, int pulpit, int ID)
        {

            int age = int.Parse(Age);
            int experience = int.Parse(Experience);


            connection.Open();
            OleDbCommand commP = connection.CreateCommand();
            commP.CommandText = $"INSERT INTO [Сотрудник] ([ФИО],[Стаж],[Возраст],[Образование] ,[Кафедра], [ID]) VALUES('{name}','{experience}','{age}','{education}','{pulpit}','{ID}')";
            commP.ExecuteNonQuery();
            connection.Close();
        }
        public void UpdateID(int id)
        {
            connection.Open();
            OleDbCommand commP = connection.CreateCommand();
            commP.CommandText = $"UPDATE [Сотрудник] SET [ID] = {id} ";
            commP.ExecuteNonQuery();
            connection.Close();
        }
        public DataTable GetKaf()
        {
            string query = $"SELECT [ID],[Направление] FROM [Кафедры]";
            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();
            return table;
        }
    }
}
