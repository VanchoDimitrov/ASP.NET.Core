using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDReactJSEntityFramework.Models;

namespace CRUDReactJSEntityFramework.Controllers
{
    public class EmployeesController : Controller
    {
        //Added by Vancho. Instentiate Employee Data Access Layer
        EmployeesDAL objEmployee = new EmployeesDAL();

        [HttpGet]
        [Route("api/Employee/Index")]
        public IEnumerable<TblEmployees> Index()
        {
            return objEmployee.GetAllEmployees();
        }

        [HttpPost]
        [Route("api/Employee/Create")]
        public int Create(TblEmployees employee)
        {
            return objEmployee.AddEmployee(employee);
        }

        [HttpGet]
        [Route("api/Employee/Details/{id}")]
        public TblEmployees Details(int id)
        {
            return objEmployee.GetEmployeeData(id);
        }

        [HttpPut]
        [Route("api/Employee/Edit")]
        public int Edit(TblEmployees employee)
        {
            return objEmployee.UpdateEmployee(employee);
        }

        [HttpDelete]
        [Route("api/Employee/Delete/{id}")]
        public int Delete(int id)
        {
            return objEmployee.DeleteEmployee(id);
        }

        [HttpGet]
        [Route("api/Employee/GetCityList")]
        public IEnumerable<TblCities> Details()
        {
            return objEmployee.GetCities();
        }
    }
}