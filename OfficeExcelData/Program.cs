using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeExcelData
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = @"E:\Applications\Test Solutions\ConsoleAppsTest\OfficeExcelData\performance.xlsx";
            string constring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=\"Excel 12.0;HDR=No;IMEX=1\";";
            string sqlquery = "Select * From [Sheet1$]";
            DataSet ds = new DataSet();
            OleDbConnection con = new OleDbConnection(constring);
            OleDbDataAdapter da = new OleDbDataAdapter(sqlquery, con);
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            Console.ReadLine();
        }

        //static void Main(string[] args)
        //{
        //    var fileName = @"E:\Applications\Test Solutions\ConsoleAppsTest\OfficeExcelData\performance.xlsx";
        //    string constring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=\"Excel 12.0;HDR=No;IMEX=1\";";
        //    using (var connection = new OleDbConnection(constring))
        //    {
        //        connection.Open();
        //        var command = new OleDbCommand("select * from [Sheet1$]", connection);
        //        var date = new List<string>();
        //        var value1 = new List<double>();
        //        var value2 = new List<double>();
        //        using (var dr = command.ExecuteReader())
        //        {
        //            DataSet aaa;
        //            while (dr != null && dr.Read())
        //            {
        //                try
        //                {
        //                    var dateVal = dr[0].ToString();
        //                    var value1Val = Convert.ToDouble(dr[1]) * 100;
        //                    var value2Val = Convert.ToDouble(dr[1]) * 100;
        //                    date.Add(dateVal);
        //                    value1.Add(value1Val);
        //                    value2.Add(value2Val);
        //                }
        //                catch (Exception)
        //                {
        //                    // ignored
        //                }
        //            }
        //            Console.WriteLine(dr.);
        //        }
        //        Console.WriteLine($"date count : {date.Count}");
        //        Console.WriteLine($"fund count : {value1.Count}");
        //        Console.WriteLine($"index count : {value2.Count}");
        //        Console.ReadLine();
        //        for (var i = 0; i < date.Count; i++)
        //        {
        //            Console.WriteLine($"{date[i]} : {value1[i]}%  {value2[i]}%");
        //        }
        //    }
        //}
    }
}
