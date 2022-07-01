using myDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{

     
    public class customerDAO
    {
        myDb db = null;
        public customerDAO()
        {
            
            db = new myDb();
        }
        public List<customer> GetAllCustomers()
        {
            return db.customers.ToList();
        }

        public bool editCustomer(int id, string name, string address, string phone, string email, DateTime? dob)
        {
            try{
                customer cus = db.customers.Where(x => x.id == id).FirstOrDefault();
                cus.name = name;
                cus.address = address;
                cus.phone = phone;
                cus.email = email;
                cus.dob = dob;
                db.SaveChanges();
                return true;}
            catch (Exception)
            {
                return false;
            }

        }

        public bool deleteCustomer(int id)
        {
            
            
            try
            {
                customer cus = db.customers.Where(x => x.id == id).FirstOrDefault();
                db.customers.Remove(cus);
                db.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                
                return false;
            }
        }

        public int addCustomer( string name, string address, string phone, string email, DateTime? dob)
        {

                customer cus= new customer();
                cus.name = name;
                cus.address = address;
                cus.phone = phone;
                cus.email = email;
                cus.dob = dob;
                db.customers.Add(cus);
                db.SaveChanges();
                return cus.id;
                
        }
    }




}
