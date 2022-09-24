using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblWheelerType")]
    public partial class TblWheelerType
    {
        public TblWheelerType()
        {
            TblTrafficPlaceFineDetailsJetNulls = new HashSet<TblTrafficPlaceFineDetailsJetNull>();
            TblTrafficPlaceFineDetailsJets = new HashSet<TblTrafficPlaceFineDetailsJet>();
            TblTrafficPlaceItdetails = new HashSet<TblTrafficPlaceItdetail>();
        }

        [Key]
        public int WheelerTypeId { get; set; }

        public string? WheelerTypeName { get; set; }

        [InverseProperty("WheelerType")]
        public virtual ICollection<TblTrafficPlaceFineDetailsJetNull> TblTrafficPlaceFineDetailsJetNulls { get; set; }

        [InverseProperty("WheelerType")]
        public virtual ICollection<TblTrafficPlaceFineDetailsJet> TblTrafficPlaceFineDetailsJets { get; set; }

        [InverseProperty("WheelerType")]
        public virtual ICollection<TblTrafficPlaceItdetail> TblTrafficPlaceItdetails { get; set; }
    }
}