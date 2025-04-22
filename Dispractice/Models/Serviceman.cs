using Dispractice.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dispractice.Models
{
    public class Serviceman
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
        public MilitaryRank Rank { get; set; }

        [Required]
        public bool IsNaval { get; set; }

        [ForeignKey("MilitaryPosition")]
        public int? PositionId { get; set; }
        public virtual Position? Position { get; set; }

        public int? ServiceStartYear { get; set; }

        public virtual ICollection<Commendation> Commendations { get; set; } = new ObservableCollection<Commendation>();
        public virtual ICollection<Penalty> Penalties { get; set; } = new ObservableCollection<Penalty>();

        public override string ToString()
        {
            return ShortServicemanString;
        }



        [NotMapped]
        public string ShortServicemanString => $"{Rank.GetRankInfo(IsNaval).ShortName} {Surname} {Name[0]}.{(!String.IsNullOrWhiteSpace(Patronomic) ? " " + Patronomic[0] + "." : "")}";
        
        [NotMapped]
        public string LongServicemanString => $"{Rank.GetRankInfo(IsNaval).Name} {Surname} {Name} {Patronomic}";
    }
}
