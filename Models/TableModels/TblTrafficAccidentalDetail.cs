﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblTrafficAccidentalDetails")]
    public partial class TblTrafficAccidentalDetail
    {
        [Key]
        public int TrafficAccidentalId { get; set; }

        public int? PoliceStationId { get; set; }
        public string? PoliceCrimeNo { get; set; }
        public string? CrimesDateTime { get; set; }
        public string? CrimeLocation { get; set; }

        [Column(TypeName = "decimal(18, 7)")]
        public decimal? Latitude { get; set; }

        [Column(TypeName = "decimal(18, 7)")]
        public decimal? Longitude { get; set; }

        public string? CrimeDeclaredDateTime { get; set; }
        public string? ComplainerNameAddress { get; set; }
        public string? AccusedNameAddress { get; set; }

        [Column("Death_Injured_Personname")]
        public string? DeathInjuredPersonname { get; set; }

        public string? InvestigationOfficer { get; set; }
        public string? ShortDetails { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public int? SubCategoryId { get; set; }
    }
}