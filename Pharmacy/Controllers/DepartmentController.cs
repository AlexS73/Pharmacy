using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmacy.BL.Interfaces;
using Pharmacy.Core.Models;
using Pharmacy.Entity;

namespace Pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentModel>>> GetDepartments()
        {
            var result = await departmentService.GetDepartmentsAsync();
            
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentModel>> GetDepartment(int id)
        {

            var department = await departmentService.GetDepartmentByIdAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        [HttpPost]
        public async Task<ActionResult<DepartmentModel>> SaveDepartment(DepartmentModel department)
        {
            var updatedDepartment = await departmentService.SaveDepartmentAsync(department);
            return updatedDepartment;
        }

    }
}
