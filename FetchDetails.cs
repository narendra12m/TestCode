using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Diagnostics;

namespace FileData
{
    class FetchDetails
    {
        public DataTable PopulateFilesDetails(string filepath)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("File_Name", typeof(string));
            dt.Columns.Add("Size", typeof(int));
            dt.Columns.Add("Version", typeof(string));

            DirectoryInfo di = new DirectoryInfo(filepath);
            foreach (FileInfo file in di.GetFiles())
            {
                dt.Rows.Add(file.Name, file.Length, FileVersionInfo.GetVersionInfo(filepath + "\\" + file.Name).ProductVersion);
            }
            return dt;
        }
    }
}
