using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblWardMaster")]
    public partial class TblWardMaster
    {
        public TblWardMaster()
        {
            TblTrafficPlaceFineDetailsJetNulls = new HashSet<TblTrafficPlaceFineDetailsJetNull>();
            TblTrafficPlaceFineDetailsJets = new HashSet<TblTrafficPlaceFineDetailsJet>();
            TblWardWiseJetDetails = new HashSet<TblWardWiseJetDetail>();
        }

        [Key]
        public int WardId { get; set; }

        public int? PoliceStationId { get; set; }
        public string? WardName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        [InverseProperty("Ward")]
        public virtual ICollection<TblTrafficPlaceFineDetailsJetNull> TblTrafficPlaceFineDetailsJetNulls { get; set; }

        [InverseProperty("Ward")]
        public virtual ICollection<TblTrafficPlaceFineDetailsJet> TblTrafficPlaceFineDetailsJets { get; set; }

        [InverseProperty("Ward")]
        public virtual ICollection<TblWardWiseJetDetail> TblWardWiseJetDetails { get; set; }
    }
}