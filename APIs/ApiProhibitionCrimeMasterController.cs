using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiProhibitionCrimeMasterController : ControllerBase
    {
        #region Private Members

        /// <summary>
        /// IUnitOfWork.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructors
        /// </summary>
        /// <param name="iUnitOfWork"></param>
        public ApiProhibitionCrimeMasterController(IUnitOfWork iUnitOfWork)
        {
            _unitOfWork = iUnitOfWork;
        }

        #endregion

        #region Get Methodes

        /// <summary>
        /// Gets part 6 crime by id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Returns json response</returns>
        [HttpGet("GetById")]
        public JsonResult GetById(int? id)
        {
            return new JsonResult(new
            {
                Content = _unitOfWork.ProhibitionCrime.Find(x => x.ProhibitioncrimeId == id),
            });
        }

        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                _unitOfWork.ProhibitionCrime.DeleteById(id);

                return new JsonResult(new
                {
                    IsValid = true,
                });
            }
            catch (Exception)
            {
                return new JsonResult(new
                {
                    IsValid = false,
                    Error = ConstantsData.ErrContactYourAdministrator,
                });
            }
        }

        /// <summary>
        /// Gets ProhibitionCrime
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>Returns json response</returns>
        [HttpGet("Get")]
        public JsonResult Get(DateTime? fromDate, DateTime? toDate, int? searchPoliceStationId)
        {
            if (!fromDate.HasValue)
            {
                fromDate = DateTime.Today;
            }

            if (!toDate.HasValue)
            {
                toDate = DateTime.Today;
            }

            var user = HttpContext.GetClaimsPrincipal();

            var roleId = Convert.ToInt32(user.RoleId);
            var sectorId = Convert.ToInt32(user.SectorId);
            var zoneId = Convert.ToInt32(user.ZoneId);
            var divisionId = Convert.ToInt32(user.DivisionId);
            var policeStationId = Convert.ToInt32(user.PoliceStationId);

            if (policeStationId == 0 && searchPoliceStationId.HasValue)
            {
                roleId = 0;
                policeStationId = searchPoliceStationId.Value;
            }

            var responseData = _unitOfWork.ProhibitionCrime
                .GetProhibitionCrimes(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                .OrderBy(x => x.PoliceStationId)
                .ThenBy(x => x.CreatedDate)
                .Select(x => new
                {
                    x.ProhibitioncrimeId,
                    x.PoliceStationName,
                    CreatedDate = x.CreatedDate.ToString("dd/MM/yyyy"),
                    x.Pidhela,
                    x.Kabjama,
                    x.CrimeNumber,
                    x.ArrestsNumber,
                    x.Mudamal_value,
                    x.Issue,
                    x.TotalNumberCase,
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "Prohibition Crimes",
                Header_Title = "પાર્ટ-સી ના ગુનાઓની હકિકત દર્શાવતુપત્રક",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        #endregion

        #region Post Methods

        [HttpPost("Save")]
        public JsonResult Save(Post_ProhibtionCrime model)
        {
            try
            {
                var user = HttpContext.GetClaimsPrincipal();

                var oldData = _unitOfWork.ProhibitionCrime.GetProhibitionCrimes(0,
                                                           0,
                                                           0,
                                                           0,
                                                           model.PoliceStationId.Value,
                                                           model.CreatedDate.Value,
                                                           model.CreatedDate.Value)
                                        .Where(x => x.IsActive == true && x.IsDeleted == false)
                                        .ToList();

                if (model.ProhibitioncrimeId == 0 && oldData.Count == 0)
                {
                    var data = new TblProhibitionCrimeMaster
                    {
                        PoliceStationId = model.PoliceStationId,
                        Pidhela = model.Pidhela,
                        Kabjama = model.Kabjama,
                        CrimeNumber = model.CrimeNumber,
                        ArrestsNumber = model.ArrestsNumber,
                        Issue = model.Issue,
                        MudamalValue = model.MudamalValue,
                        TotalNumberCase = model.TotalNumberCase,
                        CreatedDate = model.CreatedDate,
                        ModifiedDate = model.CreatedDate,
                        CreateduserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        IsActive = true,
                        IsDeleted = false,
                    };

                    _unitOfWork.ProhibitionCrime.Add(data);
                }
                else
                {
                    if (oldData != null)
                    {
                        model.ProhibitioncrimeId = oldData[0].ProhibitioncrimeId;
                    }

                    var data = _unitOfWork.ProhibitionCrime.Find(x => x.ProhibitioncrimeId == model.ProhibitioncrimeId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }
                    data.PoliceStationId = model.PoliceStationId;
                    data.Pidhela = model.Pidhela;
                    data.Kabjama = model.Kabjama;
                    data.CrimeNumber = model.CrimeNumber;
                    data.ArrestsNumber = model.ArrestsNumber;
                    data.Issue = model.Issue;
                    data.MudamalValue = model.MudamalValue;
                    data.TotalNumberCase = model.TotalNumberCase;
                    data.CreatedDate = model.CreatedDate;
                    data.ModifiedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);

                    _unitOfWork.ProhibitionCrime.Update(data, data.ProhibitioncrimeId);
                }
                return new JsonResult(new
                {
                    IsValid = true,
                });
            }
            catch (Exception)
            {
                return new JsonResult(new
                {
                    IsValid = false,
                    Error = ConstantsData.ErrContactYourAdministrator,
                });
            }
        }

        #endregion
    }
}