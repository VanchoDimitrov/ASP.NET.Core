using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDReactJSEntityFramework.Models
{
    public class EmployeesDAL
    {
        TrainingDatabaseContext db = new TrainingDatabaseContext();

        //To Get the list of Cities    
        public List<TblCities> GetCities()
        {
            List<TblCities> lstCity = new List<TblCities>();
            lstCity = (from CityList in db.TblCities select CityList).ToList();

            return lstCity;
        }

        //return list of employees
        public IEnumerable<TblEmployees> GetAllEmployees()
        {
            try
            {
                return db.TblEmployees.ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Add new employee record     
        public int AddEmployee(TblEmployees employee)
        {
            try
            {
                db.TblEmployees.Add(employee);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar employee    
        public int UpdateEmployee(TblEmployees employee)
        {
            try
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();

                return 1;
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular employee    
        public TblEmployees GetEmployeeData(int id)
        {
            try
            {
                TblEmployees employee = db.TblEmployees.Find(id);
                return employee;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular employee    
        public int DeleteEmployee(int id)
        {
            try
            {
                TblEmployees emp = db.TblEmployees.Find(id);
                db.TblEmployees.Remove(emp);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}
