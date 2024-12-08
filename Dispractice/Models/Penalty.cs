using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Dispractice.Models
{
    public class Penalty 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Serviceman")]
        public int ServicemanId { get; set; }
        public virtual Serviceman Serviceman { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; } // Основание применения взыскания

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        [Required]
        public DateTimeOffset OffenseDate { get; set; } // Когда совершен проступок

        [Required]
        public DateTimeOffset DateApplied { get; set; } // Когда применено
        
        [Required]
        public DateTimeOffset DateExecuted { get; set; } // Когда выполнено

        public DateTimeOffset? DateRemoved { get; set; } // Когда снято (может быть null)

        [Required]
        [StringLength(100)]
        public string AppliedBy { get; set; } // Кем применено

        [ForeignKey("Commendation")]
        public int? CommendationId { get; set; } // Ссылка на поощрение-снятие (если есть)
        public virtual Commendation Commendation { get; set; }
    }
}
