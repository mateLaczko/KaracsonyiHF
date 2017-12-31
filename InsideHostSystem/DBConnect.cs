using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;

namespace InsideHostSystem
{
    public class DBConnect
    {
        private SqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public DBConnect()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "159.89.26.25,1433";
            database = "TestDB";
            uid = "SA";
            password = "R4nt0ttHus";
            string connectionString;
            connectionString = "Data Source=" + server + ";" + "Initial Catalog=" +
            database + ";" + "User id=" + uid + ";" + "Password=" + password + ";";

            connection = new SqlConnection(connectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //hozzáadás Member táblához
        public string BuildInsertQuery(string table, params string[] values)
        {
            string insertQuery = null;

            if (table == "Member")
            {
                insertQuery = "INSERT INTO Member ( MemberName, MemberPass) VALUES( '" + values[0] + "', '" + values[1] + "')";
            }
            return insertQuery;
        }
        //hozzáadás Message táblához
        public string BuildInsertQuery(string table, DateTime date, params string[] values)
        {
            string insertQuery = null;
            string sqlFormattedDate = date.ToString("yyyy-MM-dd HH:mm:ss.fff");
            insertQuery = "INSERT INTO " + table + " (MessageSeen, MessageDate, MessageContent, MessageFrom, MessageTo) SELECT 0, CAST ('" + sqlFormattedDate + "' AS datetime), '" + values[2] + "', (SELECT MemberId FROM Member WHERE MemberName = '" + values[0] + "') AS MessageFrom, (SELECT MemberId FROM Member WHERE MemberName = '" + values[1] + "') AS MessageTo";
            return insertQuery;
        }
        //hozzáadás Connections táblához
        public string BuildInsertQuery(string table, int confirmed, params string[] values)
        {
            string insertQuery = null;
            insertQuery = "INSERT INTO " + table + " ( This, Other, Confirmed) SELECT  (SELECT MemberId FROM Member WHERE MemberName = '" + values[0] + "') AS This, (SELECT MemberId FROM Member WHERE MemberName = '" + values[1] + "') AS Other, " + confirmed;
            return insertQuery;
        }


        //megerősítés Connections táblán
        public string BuildUpdateQuery(string table, params string[] values)
        {
            string updateQuery = null;
            updateQuery = "UPDATE " + table + " SET Confirmed= 1 WHERE This IN (SELECT MemberId FROM Member WHERE MemberName= '" + values[1] + "') AND Other IN (SELECT MemberId FROM Member WHERE MemberName= '" + values[0] + "') ";
            return updateQuery;
        }

        //üzenet olvasottként való megjelölése
        public string BuildUpdateQuery(string table, DateTime date, params string[] values)
        {
            string updateQuery = null;
            string sqlFormattedDate = date.ToString("yyyy-MM-dd HH:mm:ss.fff");
            updateQuery = "UPDATE " + table + " SET MessageSeen= 1 WHERE MessageTo IN (SELECT MemberId FROM Member WHERE MemberName= '" + values[1] + "') AND MessageFrom IN (SELECT MemberId FROM Member WHERE MemberName= '" + values[0] + "') AND MessageDate = CAST('" + sqlFormattedDate + "' AS datetime)";
            return updateQuery;
        }

        // Contacts vagy Requests lista feltöltése
        public string BuildSelectQuery(string name, int confirmed)
        {
            string selectQuery = null;
            if (confirmed == 1) //Contacts
            {
                selectQuery = "SELECT MemberName, MemberPass FROM Member INNER JOIN Connections ON Member.MemberId = Connections.Other WHERE Confirmed=1 AND This IN (SELECT MemberId FROM Member WHERE MemberName= '" + name + "')";
            }
            else //nem visszaigazolt => Requests
            {
                selectQuery = "SELECT MemberName, MemberPass FROM Member INNER JOIN Connections ON Member.MemberId = Connections.This WHERE Confirmed=0 AND Other IN (SELECT MemberId FROM Member WHERE MemberName= '" + name + "')";
            }
            return selectQuery;
        }

        //Messages stack feltöltése
        public string BuildSelectQuery(string name)
        {
            string selectQuery = null;
            selectQuery = "SELECT MemberName, MemberPass, MessageDate, MessageContent, MessageSeen FROM Message INNER JOIN Member ON Member.MemberId = Message.MessageFrom WHERE  MessageTo IN (SELECT MemberId FROM Member WHERE MemberName= '" + name + "') ORDER BY MessageDate ";
            return selectQuery;
        }

        //AllMembers lista feltöltése
        public string BuildSelectQuery()
        {
            string selectQuery = null;
            selectQuery = "SELECT MemberName, MemberPass FROM Member";
            return selectQuery;
        }

        //Hozzáadás
        public void Insert(string insertQuery)
        {
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(insertQuery, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Adatok frissítése
        public void Update(string updateQuery)
        {
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = updateQuery;
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Member vagy Connections tábla kiíratása listába
        public List<Member> ListMembers(string query)
        {
            List<Member> list = new List<Member>();

            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    list.Add(new Member(dataReader[0].ToString(), dataReader[1].ToString()));
                }

                dataReader.Close();
                this.CloseConnection();
                return list;
            }
            else
            {
                return list;
            }
        }

        //üzenetek tábla kiíratása stack-be
        public Stack<Message> ListMessages(string query)
        {
            Stack<Message> stack = new Stack<Message>();

            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    stack.Push(new Message(new Member(dataReader[0].ToString(), dataReader[1].ToString()), dataReader.GetDateTime(2), dataReader[3].ToString()));
                    if ((bool)(dataReader[4]))
                        stack.Peek().Seen = true;
                    else
                        stack.Peek().Seen = false;
                }

                dataReader.Close();
                this.CloseConnection();
                return stack;
            }
            else
            {
                return stack;
            }
        }

        //Majd ha szükség lesz rá, megírom a query-t ehhez is
        public void Delete(string query)
        {
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
    }
}
