using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO;
namespace demoProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            customerDAO modelcus = new customerDAO();           
            return View(modelcus.GetAllCustomers());
        }

        [HttpPost]
        public JsonResult addCustomer(string name, string address, string phone, string email, DateTime? dob)
        {
            JsonResult js_rs = new JsonResult();
            customerDAO cus = new customerDAO();
            int rs =cus.addCustomer(name, address, phone, email, dob);
            js_rs.Data = new
            {
                status = rs
            };
            return js_rs;


        }


        [HttpPost]
        public JsonResult editCustommer(int id,string name,string address, string phone,string email, DateTime? dob)
        {
            JsonResult js_rs = new JsonResult();
            customerDAO cus = new customerDAO();
            bool rs = cus.editCustomer(id, name, address, phone, email, dob);
            js_rs.Data = new
            {
                status = rs
            };
            return js_rs;

        }

        [HttpPost]
        public JsonResult deleteCustommer(int id)
        {
            customerDAO cus = new customerDAO();
            bool rs = cus.deleteCustomer(id);
            JsonResult js_rs = new JsonResult();

            js_rs.Data = new
            {
                status = rs
            };
            return js_rs;
        }




    }
}

