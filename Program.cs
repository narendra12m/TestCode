using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;

namespace FileData
{
    class Program
    {
       public static void Main(string[] args)
        {

//            string FilePath = @"D:\Backup";
            string FilePath =  ConfigurationSettings.AppSettings["FilePath"].ToString();
            string version = string.Empty;
            int size = 0;

            FetchDetails fetchdetails = new FetchDetails();
            FileDetails filedetails = new FileDetails();

            DataTable dt = fetchdetails.PopulateFilesDetails(FilePath);
            var filenameversion = from row in dt.AsEnumerable()
                                  where row.Field<string>("File_Name").Contains(args[1])
                                  select row.Field<string>("Version");

            if (args[0].ToUpper().Contains("V") && filenameversion.Count() != 0)
            {
                version = filedetails.Version(FilePath + "\\" + args[1]);
                Console.WriteLine("The File is " + args[1] + " Version is " + version);
            }
            var filesize = from row in dt.AsEnumerable()
                                  where row.Field<string>("File_Name").Contains(args[1])
                                  select row.Field<int>("Size");
            if (args[0].ToUpper().Contains("S") && filesize.Count() != 0)
            {
                size = filedetails.Size(FilePath + "\\" + args[1]);
                Console.WriteLine("The File is " + args[1] + " Size is " + size);
            }
            Console.Read();

        }
    }
}
