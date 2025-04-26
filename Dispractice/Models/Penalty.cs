using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;

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
        public PenaltyType Type { get; set; }

        [Required]
        public DateTime? OffenseDate { get; set; } // Когда совершен проступок

        [Required]
        public DateTime DateApplied { get; set; } // Когда применено
        
        [Required]
        public DateTime? DateExecuted { get; set; } // Когда выполнено

        public DateTime? DateRemoved { get; set; } // Когда снято (может быть null)

        [Required]
        [StringLength(100)]
        public string AppliedBy { get; set; } // Кем применено

        [ForeignKey("Commendation")]
        public int? CommendationId { get; set; } // Ссылка на поощрение-снятие (если есть)
        public virtual Commendation Commendation { get; set; }
    }

    public enum PenaltyType
    {
        Reprimand,                //Выговор
        SevereReprimand,          //Строгий выговор
        IncompetenceWarning,      //Предупреждение о неполдном служебном соответствии
        Demotion,                 //Понижение в должности
        RankDeprivation,          //Понижение в звании
    }

    public static class PenaltyRegistry
    {
        public static Dictionary<PenaltyType, string> Info = new Dictionary<PenaltyType, string>
        {
            { PenaltyType.Reprimand, "Выговор" },
            { PenaltyType.SevereReprimand, "Строгий выговор" },
            { PenaltyType.IncompetenceWarning, "Предупреждение о неполном служебном соответствии" },
            { PenaltyType.Demotion, "Понижение в должности" },
            { PenaltyType.RankDeprivation, "Понижение в звании" }
        };

        public static string GetDescription(this PenaltyType type)
        {
            return Info[type];
        }
    }
}
