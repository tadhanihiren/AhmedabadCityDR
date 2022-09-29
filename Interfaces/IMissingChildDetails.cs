﻿using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    public interface IMissingChildDetails : IGenericRepository<TblMissingChildDetail>
    {
        IEnumerable<MissingChildDetailsViewModel> GetMissingChildDetails(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate);

        void DeleteById(int id);
    }
}
