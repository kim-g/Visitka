using System;
using System.Collections.Generic;
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
