using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblTraffiCategoryMaster")]
    public partial class TblTraffiCategoryMaster
    {
        public TblTraffiCategoryMaster()
        {
            TblTrafficPlaceFineDetails = new HashSet<TblTrafficPlaceFineDetail>();
            TblTrafficPlaceFineDetailsJetNulls = new HashSet<TblTrafficPlaceFineDetailsJetNull>();
            TblTrafficPlaceFineDetailsJets = new HashSet<TblTrafficPlaceFineDetailsJet>();
            TblTrafficPlaceItdetails = new HashSet<TblTrafficPlaceItdetail>();
        }

        [Key]
        public int TrafficCategoryId { get; set; }

        public string? TrafficCategoryName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        [InverseProperty("TrafficCategory")]
        public virtual ICollection<TblTrafficPlaceFineDetail> TblTrafficPlaceFineDetails { get; set; }

        [InverseProperty("TrafficCategory")]
        public virtual ICollection<TblTrafficPlaceFineDetailsJetNull> TblTrafficPlaceFineDetailsJetNulls { get; set; }

        [InverseProperty("TrafficCategory")]
        public virtual ICollection<TblTrafficPlaceFineDetailsJet> TblTrafficPlaceFineDetailsJets { get; set; }

        [InverseProperty("TrafficCategory")]
        public virtual ICollection<TblTrafficPlaceItdetail> TblTrafficPlaceItdetails { get; set; }
    }
}