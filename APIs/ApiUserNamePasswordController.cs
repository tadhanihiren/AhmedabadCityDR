using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiUserNamePasswordController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApiUserNamePasswordController(IUnitOfWork iUnitOfWork)
        {
            _unitOfWork = iUnitOfWork;
        }

        [HttpGet("GetById")]
        public JsonResult GetById(int? id)
        {
            return new JsonResult(new
            {
                Content = _unitOfWork.LoginMaster.Find(x => x.LoginId == id),
            });
        }

        [HttpGet("Get")]
        public JsonResult Get()
        {
            var responseData = _unitOfWork.LoginMaster.GetLoginUsers()
                .OrderBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.LoginId,
                    x.PoliceStationName,
                    x.SectorName,
                    x.ZoneName,
                    x.DivisionName,
                    x.UserName,
                    x.ContactNo,
                    DesignationName = string.Empty,
                }); ;

            return new JsonResult(new
            {
                Success = true,
                Headers = "Login Users",
                Header_Title = "Login User",
                Content = responseData
            });
        }

        [HttpPost("Save")]
        public IActionResult Save(Post_LoginMaster postLoginMaster)
        {
            try
            {
                switch (postLoginMaster.DesignationId)
                {
                    case 1:
                        postLoginMaster.SectorId = postLoginMaster.TempId;

                        break;

                    case 2:
                        postLoginMaster.SectorId = postLoginMaster.TempId;

                        break;

                    case 3:
                        postLoginMaster.ZoneId = postLoginMaster.TempId;

                        break;

                    case 4:
                        postLoginMaster.DivisionId = postLoginMaster.TempId;

                        break;

                    case 5:
                    case 6:
                        postLoginMaster.PoliceStationId = postLoginMaster.TempId;

                        break;

                    default:
                        break;
                }

                if (postLoginMaster.LoginId == 0)
                {
                    var data = new TblLoginMasterMobile

                    {
                        UserName = postLoginMaster.UserName,
                        Password = postLoginMaster.Password,
                        ContactNo = postLoginMaster.ContactNo,
                        Name = postLoginMaster.Name,
                        DeviceId = postLoginMaster.DeviceId,
                        RoleId = int.Parse(HttpContext.GetClaimsPrincipal().RoleId),
                        SectorId = postLoginMaster.SectorId,
                        ZoneId = postLoginMaster.ZoneId,
                        DivisionId = postLoginMaster.DivisionId,
                        PoliceStationId = postLoginMaster.PoliceStationId,
                        ForTrafficCity = postLoginMaster.ForTrafficCity,
                        IsActive = true,
                        IsDelete = false,
                        IsMobileAccess = true,
                        CreatedUserId = postLoginMaster.CreatedUserId,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        ModifiedUserId = postLoginMaster.ModifiedUserId,
                        DesignationId = postLoginMaster.DesignationId,
                        FierBaseId = postLoginMaster.FierBaseId
                    };
                    _unitOfWork.LoginMaster.Add(data);
                }
                else
                {
                    var data = _unitOfWork.LoginMaster.Find(x => x.LoginId == postLoginMaster.LoginId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }
                    data.UserName = postLoginMaster.UserName;
                    data.Password = postLoginMaster.Password;
                    data.ContactNo = postLoginMaster.ContactNo;
                    data.Name = postLoginMaster.Name;
                    data.DeviceId = postLoginMaster.DeviceId;
                    data.RoleId = int.Parse(HttpContext.GetClaimsPrincipal().RoleId);
                    data.SectorId = postLoginMaster.SectorId;
                    data.ZoneId = postLoginMaster.ZoneId;
                    data.DivisionId = postLoginMaster.DivisionId;
                    data.PoliceStationId = postLoginMaster.PoliceStationId;
                    data.ForTrafficCity = postLoginMaster.ForTrafficCity;
                    data.IsActive = true;
                    data.IsDelete = false;
                    data.IsMobileAccess = true;
                    data.CreatedUserId = postLoginMaster.CreatedUserId;
                    data.CreatedDate = DateTime.Now;
                    data.ModifiedDate = DateTime.Now;
                    data.ModifiedUserId = postLoginMaster.ModifiedUserId;
                    data.DesignationId = postLoginMaster.DesignationId;
                    data.FierBaseId = postLoginMaster.FierBaseId;

                    _unitOfWork.LoginMaster.Update(data, data.LoginId);
                }
                _unitOfWork.Save();

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
    }
}