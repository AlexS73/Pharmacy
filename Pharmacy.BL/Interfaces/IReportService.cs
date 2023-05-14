using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Core.Models;

namespace Pharmacy.BL.Interfaces
{
    public interface IReportService
    {
        Task<SaleReportModel> GenerateSaleReportAsync(DateTime? from, DateTime? to, int? departmentId);

        Task<EntranceReportModel> GenerateEntranceReportAsync(DateTime? from, DateTime? to, int? departmentId);
    }
}
