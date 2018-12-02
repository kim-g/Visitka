using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;

namespace SQLite
{
    public class SQLiteDataBase
    {
        protected String dbFileName;
        protected SQLiteConnection Connection;
        protected SQLiteCommand Command;

        public string ErrorMsg;

        public SQLiteDataBase(string FileName = "")
        {
            dbFileName = FileName;
            Connection = new SQLiteConnection();
            Command = new SQLiteCommand();
        }

        static public SQLiteDataBase Create(string FileName, string Query)
        {
            SQLiteDataBase NewBase = new SQLiteDataBase(FileName);

            if (NewBase.CreateDB(Query))
                return NewBase;
            else
                return null;
        }

        static public SQLiteDataBase Open(string FileName)
        {
            if (File.Exists(FileName))
            {
                SQLiteDataBase NewBase = new SQLiteDataBase(FileName);

                if (NewBase.OpenDB())
                    return NewBase;
                else
                    return null;
            }
            return null;
        }

        protected bool OpenDB()
        {
            if (!File.Exists(dbFileName))
            {
                ErrorMsg = "Database file not found";
                return false;
            }

            try
            {
                Connection = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
                Connection.Open();
                Command.Connection = Connection;
            }
            catch (SQLiteException ex)
            {
                ErrorMsg = ex.Message;
                return false;
            }
            return true;
        }

        protected bool CreateDB(string Query)
        {
            if (!File.Exists(dbFileName))
                SQLiteConnection.CreateFile(dbFileName);

            try
            {
                Connection = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
                Connection.Open();
                Command.Connection = Connection;

                Command.CommandText = Query;
                Command.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                ErrorMsg = ex.Message;
                return false;
            }
            return true;
        }

        public DataTable ReadTable(string Query)
        {
            DataTable dTable = new DataTable();

            if (Connection.State != ConnectionState.Open)
            {
                ErrorMsg = "Open Database";
                return null;
            }

            try
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(Query, Connection);
                adapter.Fill(dTable);
            }
            catch (SQLiteException ex)
            {
                ErrorMsg = ex.Message;
                return null;
            }

            return dTable;
        }

        public int GetCount(string Table, string Where = null)
        {
            DataTable dTable = new DataTable();

            if (Connection.State != ConnectionState.Open)
            {
                ErrorMsg = "Open Database";
                return 0;
            }

            try
            {
                string Query = Where == null ? "SELECT COUNT() AS 'C' FROM `" + Table + ";" : "SELECT COUNT() AS 'C' FROM `" + Table + "` WHERE " + Where + ";";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(Query, Connection);
                adapter.Fill(dTable);
            }
            catch (SQLiteException ex)
            {
                ErrorMsg = ex.Message;
                return 0;
            }

            return Convert.ToInt32(dTable.Rows[0].ItemArray[0].ToString());
        }

        public bool Execute(string Query)
        {
            if (Connection.State != ConnectionState.Open)
            {
                ErrorMsg = "Open connection with database";
                return false;
            }

            try
            {
                Command.CommandText = Query;
                Command.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                ErrorMsg = ex.Message;
                return false;
            }
            return true;
        }

    }

    public class SQLiteConfig : SQLiteDataBase
    {
        public SQLiteConfig(string FileName) : base (FileName)
        {
            if (File.Exists(FileName))
            {
                OpenDB();
            }
            else
            {
                CreateDB("CREATE TABLE `config` (`id` INTEGER PRIMARY KEY AUTOINCREMENT, `name`	TEXT NOT NULL, `value` TEXT); ");
            }
        }

        public static new SQLiteConfig Open(string FileName)
        {
            return new SQLiteConfig(FileName);
        }

        //Работа с конфигом, получение значения

        public string GetConfigValue(string name)
        {
            DataTable Conf = ReadTable("SELECT `value` FROM `config` WHERE `name`='" + name + "' LIMIT 1");
            if (Conf.Rows.Count == 0) return "";
            return Conf.Rows[0].ItemArray[0].ToString();
        }

        public int GetConfigValueInt(string name)
        {
            DataTable Conf = ReadTable("SELECT `value` FROM `config` WHERE `name`='" + name + "' LIMIT 1");
            if (Conf.Rows.Count == 0) return 0;
            return Convert.ToInt32(Conf.Rows[0].ItemArray[0].ToString());
        }

        public bool GetConfigValueBool(string name)
        {
            DataTable Conf = ReadTable("SELECT `value` FROM `config` WHERE `name`='" + name + "' LIMIT 1");
            if (Conf.Rows.Count == 0) return false;
            return Conf.Rows[0].ItemArray[0].ToString() == "1";
        }


        //Работа с конфигом, установка значения

        public bool SetConfigValue(string name, string value)
        {
            if (GetCount("config", "`name`='" + name + "'") > 0)
                return Execute("UPDATE `config` SET `value`='" + value + "' WHERE `name`='" + name + "';");
            else
                return Execute("INSERT INTO `config` (`name`, `value`) VALUES ('" + name + "','" + value + "');");
        }

        public bool SetConfigValue(string name, int value)
        {
            if (GetCount("config", "`name`='" + name + "'") > 0)
                return Execute("UPDATE `config` SET `value`='" + value.ToString() + "' WHERE `name`='" + name + "'");
            else
                return Execute("INSERT INTO `config` (`name`, `value`) VALUES ('" + name + "','" + value.ToString() + "');");
        }

        public bool SetConfigValue(string name, bool value)
        {
            string val = value ? "1" : "0";
            if (GetCount("config", "`name`='" + name + "'") > 0)
                return Execute("UPDATE `config` SET `value`='" + val + "' WHERE `name`='" + name + "'");
            else
                return Execute("INSERT INTO `config` (`name`, `value`) VALUES ('" + name + "','" + val + "');");
        }
    }

    public class SQLiteLanguage : SQLiteDataBase
    {
        string Language = "ru";

        public SQLiteLanguage(string FileName)
        {
            dbFileName = FileName;
            Connection = new SQLiteConnection();
            Command = new SQLiteCommand();
        }

        public static new SQLiteLanguage Open(string FileName, string Lang="ru")
        {
            if (File.Exists(FileName))
            {
                SQLiteLanguage NewConf = new SQLiteLanguage(FileName)
                { Language = Lang };

                if (NewConf.OpenDB())
                    return NewConf;
                else
                    return null;
            }
            else
            {
                SQLiteLanguage NewConf = new SQLiteLanguage(FileName)
                { Language = Lang == "" ? "ru" : Lang };
                if (NewConf.CreateDB("CREATE TABLE `texts` (`id` INTEGER PRIMARY KEY AUTOINCREMENT, `class` TEXT NOT NULL, `name` TEXT NOT NULL, `text_" + Lang + "` TEXT); "))
                    return NewConf;
                else
                    return null;
            }
        }

        public void AddLanguage(string LanguageName)
        {
            this.Execute("ALTER TABLE `texts` ADD COLUMN `text_" + LanguageName + "` TEXT;");
        }

        public string GetText(string Class, string TextName)
        {
            DataTable Conf = ReadTable("SELECT `text_" + Language + "` AS 'text' FROM `texts` WHERE `class`='" + Class + "' AND `name`='" + TextName + "' LIMIT 1");
            return Conf == null ? "ERROR" : Conf.Rows[0].ItemArray[Conf.Columns.IndexOf("text")].ToString();
        }
    }
}
