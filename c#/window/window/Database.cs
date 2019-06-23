using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace window
{
    class Database
    {
        private static string connectionString = "server=.; database=bookManager; integrated security=true";
        public static string ConnectionString
        {
            get
            {
                return connectionString;
            }
            set
            {
                connectionString = value;
            }
        }
        private static string process(object s){
            Type t = s.GetType();
            if (t == typeof(int))
                return s.ToString();
            if (t == typeof(double))
                return s.ToString();
            if (s.ToString().Equals("null"))
                return s.ToString();
            return "'" + s.ToString() + "'";
        }
        public static Boolean haveData(string table, LinkedList<string> column, LinkedList<object> data)
        {
            Boolean first = true;
            string sql = "select top 1 * from " + table;
            LinkedListNode<string> columnName = column.First;
            LinkedListNode<object> dataName = data.First;
            while (columnName != null)
            {
                if (first) { sql += " where "; first = false; }
                else sql += " and ";
                sql += (columnName.Value + " = ");
                sql += process(dataName.Value);
                columnName = columnName.Next;
                dataName = dataName.Next;
            }
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read()) return true;
                else return false;
            }
        }
        public static void insert(string table, LinkedList<object> data)
        {
            Boolean first = true;
            string sql = "insert into " + table + " values (";
            LinkedListNode<Object> dataName = data.First;
            while (dataName != null)
            {
                if (first) first = false;
                else sql += ",";
                sql += process(dataName.Value);
                dataName = dataName.Next;
            }
            sql += ")";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
            }
        }
        public static string getCondition(LinkedList<string> column, LinkedList<object> data) {
            Boolean first = true;
            string sql = "";
            LinkedListNode<string> columnNode = column.First;
            LinkedListNode<object> dataNode = data.First;
            while (columnNode != null) {
                if (first) { sql += " where "; first = false; } else sql += " and ";
                sql += (columnNode.Value + " = ");
                sql += process(dataNode.Value);
                columnNode = columnNode.Next;
                dataNode = dataNode.Next;
            }
            return sql;
        }
        public static string getSearch(LinkedList<string> column, LinkedList<object> data) {
            Boolean first = true;
            string sql = "";
            LinkedListNode<string> columnNode = column.First;
            LinkedListNode<object> dataNode = data.First;
            while (columnNode != null) {
                if (first) { sql += " where "; first = false; } else sql += " and ";
                if(dataNode.Value.GetType() == typeof(string)) {
                    dataNode.Value = dataNode.Value.ToString().Replace(' ', '%');
                    dataNode.Value = "%" + dataNode.Value + "%";
                    sql += (columnNode.Value + " like ");
                } else {
                    sql += (columnNode.Value + " = ");
                }
                sql += process(dataNode.Value);
                columnNode = columnNode.Next;
                dataNode = dataNode.Next;
            }
            return sql;
        }
    }
}
