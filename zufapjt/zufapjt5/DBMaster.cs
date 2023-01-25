using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zufapjt5
{
    class DBMaster
    {
        OleDbConnection conn = null;
        OleDbCommand comm = null;
        OleDbDataReader reader = null;

        string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../../Students.accdb";

        public DBMaster()
        {
            DisplayStudents();
        }

        private void DisplayStudents()
        {
            ConnectionOpen();

            string sql = "SELECT * FROM StudentTable";

            // 명령어를 실행
            comm = new OleDbCommand(sql, conn);

            // DB에서 읽을 때는 여러개의 값이 나올 수 있다
            ReadToList();

            ConnectionClose();
        }

        private void ReadToList()
        {

            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                string x = "";
                x += reader["ID"] + "\t";
                x += reader["SID"] + "\t";
                x += reader["SName"] + "\t";
                x += reader["Phone"];

                Console.WriteLine(x);
            }
        }
        private void ConnectionOpen()
        {
            if (conn == null)
            {
                conn = new OleDbConnection(connStr);
                conn.Open();
            }
        }

        private void ConnectionClose()
        {
            conn.Close();
            conn = null;
        }

        public void DB_Inser(string ID, string Name, string PhoneNumber)
        {
            ConnectionOpen();

            string sql = string.Format("insert into StudentTable(SId, SName, Phone) " + "" +
              "VALUES({0}, '{1}', '{2}')", ID, Name, PhoneNumber);
            Console.WriteLine(sql);

            comm = new OleDbCommand(sql, conn);
            int x = comm.ExecuteNonQuery();
            if (x == 1)
                Console.WriteLine ("Insert Success!");

            ConnectionClose();

            DisplayStudents();
        }

        public void DB_Read()
        {
            DisplayStudents();
        }

        public void DB_Update(string ID, string Name, string PhoneNumber)
        {
            ConnectionOpen();

            string sql = string.Format("UPDATE StudentTable SET SID={0}, SName='{1}', Phone='{2}'",
              ID, Name, PhoneNumber, ID);
            Console.WriteLine(sql);

            comm = new OleDbCommand(sql, conn);

            if (comm.ExecuteNonQuery() == 1)
                Console.WriteLine("Update Success!");

            ConnectionClose();

            DisplayStudents();

        }
        public void DB_Delete(string ID)
        {
            ConnectionOpen();

            string sql = string.Format("DELETE FROM StudentTable WHERE SID={0}", ID);
            Console.WriteLine(sql);

            comm = new OleDbCommand(sql, conn);
            if (comm.ExecuteNonQuery() == 1)
                Console.WriteLine("삭제 성공!");

            ConnectionClose();
            
            DisplayStudents();

        }
    }
}