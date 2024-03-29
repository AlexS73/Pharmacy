﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Core.Models;


namespace Pharmacy.BL.Interfaces
{
    public interface IStockService
    {
        Task<IEnumerable<ProductStockModel>> Get();
        Task<IEnumerable<ProductStockModel>> GetByDepartment(int departmentId);
    }
}
