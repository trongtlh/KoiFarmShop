﻿using BusinessObjects.Models;
using DataAccessObjects.DTOs.KoiFishDTO;
using DataAccessObjects.DTOs.KoiFishyDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IKoiFishyService
    {
        Task<IEnumerable<KoiFishy>> GetAllKoiFishes();
        Task<KoiFishy> GetKoiFishyById(int id);
        Task<KoiFishy> CreateKoiFishy(CreateKoiFishyDTO createKoiFishy);
        Task<KoiFishy> UpdateKoiFishy(int id, UpdateKoiFishyDTO updateKoiFishy);
        Task<KoiFishy> DeleteKoiFishy(int id);
        Task<KoiFishy> RestoreKoiFishy(int id);
    }
}
