using Assessmentselect.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Assessmentselect.Controllers
{
    public class HomeController : Controller
    {
        private SqlCommand command;
        private SqlDataReader dataReader;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Selectoptions(string all)
        {
            Selectoption selectoption = null;
            List<Selectoption> dist = null;
            List<string> arealist = new List<string>();
            List<string> section = new List<string>();
            List<string> subsection= new List<string>();
            if (all == "all")
            {
                
                string connetionString;
                SqlConnection connection;
                connetionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=Assessmentselect";
                connection = new SqlConnection(connetionString);
                string sql = "Select Distinct area,section,subsection from [dbo].[table]";
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                dist= new List<Selectoption>();
                while (dataReader.Read())
                {
                    selectoption = new Selectoption();
                    selectoption.area = Convert.ToString(dataReader[0]);
                    selectoption.section = Convert.ToString(dataReader[1]);
                    selectoption.subsection = Convert.ToString(dataReader[2]);
                    dist.Add(selectoption);

                }
                connection.Close();
            }
            
            foreach(var i in dist)
            {
                arealist.Add(i.area);
                section.Add(i.section);
                subsection.Add(i.subsection);
            }
            ViewBag.arealist = arealist.Distinct();
            ViewBag.section = section.Distinct();
            ViewBag.subsection = subsection.Distinct();
            return View();
        }
        public string Questions(string question)
        {
                string connetionString;
                Selectoption selectoption = null;
                SqlConnection connection;
                connetionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=Assessmentselect";
                connection = new SqlConnection(connetionString);
                string sql = "Select * from [dbo].[table] where id="+question;
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                List<Selectoption> rec = new List<Selectoption>();
                while (dataReader.Read())
                {
                    selectoption = new Selectoption();
                    selectoption.id = Convert.ToInt32(dataReader[0]);
                    selectoption.area = Convert.ToString(dataReader[1]);
                    selectoption.section = Convert.ToString(dataReader[2]);
                    selectoption.subsection = Convert.ToString(dataReader[3]);
                    selectoption.question = Convert.ToString(dataReader[4]);
                    rec.Add(selectoption);

                }
                connection.Close();
            string strserialize = JsonConvert.SerializeObject(rec);
            return strserialize;
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}