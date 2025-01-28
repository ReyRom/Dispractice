using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Dispractice.Models
{
    public class Commendation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Serviceman")]
        public int ServicemanId { get; set; }
        public virtual Serviceman Serviceman { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        public DateTime DateAwarded { get; set; }

        [Required]
        [StringLength(100)]
        public string AwardedBy { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }
    }
}
