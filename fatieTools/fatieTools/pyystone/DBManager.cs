using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace fatieTools.pyystone
{
    class DBManager
    {
        private static SQLiteConnection getcoon(string sql) {
            return new SQLiteConnection(sql);
        }

        public static void DBcreate(string sqlstr){
            SQLiteConnection.CreateFile(sqlstr);
        }


        public static void DBExcute(string sqlstr , SQLiteConnection con)
        {
            SQLiteCommand cmd = new SQLiteCommand(sqlstr, con);
            cmd.ExecuteNonQuery();
        }

        public static SQLiteDataReader DBSelect(string sqlstr, SQLiteConnection con)
        {
            SQLiteCommand cmd = new SQLiteCommand(sqlstr, con);
            SQLiteDataReader read = cmd.ExecuteReader();
            return read;
        }

        public static int DBExcuteInt(string sqlstr, SQLiteConnection con)
        {
            SQLiteCommand cmd = new SQLiteCommand(sqlstr, con);
            return cmd.ExecuteNonQuery();
        }

    }
}
