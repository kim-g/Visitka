using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizitka
{
    public class VisitDB : SQLite.SQLiteDataBase
    {
        public VisitDB(string FileName) : base(FileName)
        {
            if (File.Exists(FileName))
            {
                OpenDB();
            }
            else
            {
                CreateDB(@"CREATE TABLE `Visits` (
	`id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`surname`	TEXT,
	`name`	TEXT,
	`second_name`	TEXT,
	`company`	TEXT,
	`job`	TEXT,
	`phone`	TEXT,
	`email`	TEXT,
	`instagram`	TEXT,
	`type`	INTEGER
);");
            }
        }

        public static new VisitDB Open(string FileName)
        {
            return new VisitDB(FileName);
        }

        public void Add(VisitInfo V)
        {
            Execute(@"INSERT INTO `Visits` (`surname`, `name`, `second_name`, 
`company`, `job`, `phone`, `email`, `instagram`, `type`) 
"+$"VALUES ('{V.Surname}','{V.Name}', '{V.SecondName}', '{V.Company}', " +
$"'{V.Job}', '{V.Phone}', '{V.Email}', '{V.Instagram}', {V.VisitType});");
        }

        public Visit GetVisit(int ID)
        {
            DataTable DT = ReadTable($"SELECT * FROM `Visits` WHERE `id`={ID};");
            if (DT.Rows.Count == 0) return null;

            return new Visit(Convert.ToByte( DT.Rows[0].ItemArray[9]))
            {
                PersonSurname = DT.Rows[0].ItemArray[1].ToString(),
                PersonName = DT.Rows[0].ItemArray[2].ToString(),
                PersonSecondName = DT.Rows[0].ItemArray[3].ToString(),
                PersonCompany = DT.Rows[0].ItemArray[4].ToString() != "" &&
                DT.Rows[0].ItemArray[5].ToString() != ""
                ? DT.Rows[0].ItemArray[4].ToString() + ", " + DT.Rows[0].ItemArray[5].ToString()
                : DT.Rows[0].ItemArray[4].ToString() + DT.Rows[0].ItemArray[5].ToString(),
                PersonPhone = DT.Rows[0].ItemArray[6].ToString(),
                PersonEMail = DT.Rows[0].ItemArray[7].ToString(),
                PersonInstagram = DT.Rows[0].ItemArray[8].ToString(),
            };
        }

        public List<string> GetVisitsList()
        {
            List<string> VD = new List<string>();
            DataTable DT = ReadTable($"SELECT * FROM `Visits`;");

            foreach (DataRow Row in DT.Rows)
            {
                VD.Add(Row.ItemArray[0].ToString() + " - " + Row.ItemArray[1].ToString() + " " +
                    Row.ItemArray[2].ToString() + " " + Row.ItemArray[3].ToString());
            }

            return VD;
        }
    }

    public class VisitInfo
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Company { get; set; }
        public string Job { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Instagram { get; set; }
        public int VisitType { get; set; }
    }
}
