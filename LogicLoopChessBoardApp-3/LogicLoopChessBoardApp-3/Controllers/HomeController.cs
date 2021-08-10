using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LogicLoopChessBoardApp_3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            int total;
            string values = "";
            for (int row = 1; row <= 8; row++)
            {
                values += "<tr>";
                for (int column = 1; column <= 8; column++)
                {
                    total = row + column;
                    if (total % 2 == 0)
                    {
                        values += "<td height=30px width=30px bgcolor=#FFFFFF></td>";
                    }
                    else
                    {
                        values += "<td height=30px width=30px bgcolor=#000000></td>";
                    }
                }
                values += "</tr>";
            }
            StringBuilder result = new StringBuilder();
            try
            {
                StreamReader sr = new StreamReader(Server.MapPath("~/Html/Chesshtml.html"));
                sr = System.IO.File.OpenText(Server.MapPath("~/Html/Chesshtml.html"));
                result.Append(sr.ReadToEnd());
                sr.Close();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

            result = result.Replace("<ChessBody>", values);

            string path = Server.MapPath("~/ChessHtml/Chesshtml.html");
            using (StreamWriter sw = System.IO.File.CreateText(path))
            {
                sw.WriteLine(result);
            }


            return View();
        }
    }
}