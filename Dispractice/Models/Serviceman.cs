﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dispractice.Models
{
    public class Serviceman:IMilitaryTreeNode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Surname { get; set; }

        [StringLength(100)]
        public string? Patronomic { get; set; }

        [Required]
        public int RankIndex { get; set; }

        [Required]
        public bool IsNaval { get; set; }

        [ForeignKey("MilitaryPosition")]
        public int MilitaryPositionId { get; set; }
        public virtual MilitaryPosition MilitaryPosition { get; set; }

        [Required]
        public int ServiceStartYear { get; set; }

        public virtual ICollection<Commendation> Commendations { get; set; }
        public virtual ICollection<Penalty> Penalties { get; set; }

        public override string ToString()
        {
            return $"{(IsNaval ? RankData.NavalRanks[RankIndex] : RankData.Ranks[RankIndex]).ShortName} {Surname} {Name[0]}.{(!String.IsNullOrWhiteSpace(Patronomic) ? " " + Patronomic[0] + "." : "")}";
        }

        [NotMapped]
        public IMilitaryTreeNode Element => this;
        [NotMapped]
        public IEnumerable<IMilitaryTreeNode> SubElements => null;
    }
}
