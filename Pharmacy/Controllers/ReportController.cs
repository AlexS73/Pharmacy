using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Pharmacy.BL.Interfaces;
using System;
using System.Threading.Tasks;
using Pharmacy.Core.Models;

namespace Pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService reportService;

        public ReportController(IReportService reportService)
        {
            this.reportService = reportService;
        }

        [HttpGet("sale")]
        public async Task<ActionResult<SaleReportModel>> SaleReport(DateTime? from, DateTime? to, int? departmentId)
        {
            return await reportService.GenerateSaleReportAsync(from, to, departmentId);
        }

        [HttpGet("entrance")]
        public async Task<ActionResult<EntranceReportModel>> EntranceReport(DateTime? from, DateTime? to, int? departmentId)
        {
            return await reportService.GenerateEntranceReportAsync(from, to, departmentId);
        }
    }
}
