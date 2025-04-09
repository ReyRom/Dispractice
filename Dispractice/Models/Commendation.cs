using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;

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

    public enum CommendationType
    {
        Removal,                //Снятие взыскания
        Gratitude,              //Благодарность           
        Certificate,            //Награждение грамотой
        Gift,                   //Награждение ценным подарком
        Medal                   //Награждение медалью
    }

    public static class CommendationRegistry
    {
        public static Dictionary<CommendationType, string> Info = new Dictionary<CommendationType, string>
        {
            { CommendationType.Removal, "Снятие взыскания" },
            { CommendationType.Gratitude, "Благодарность" },
            { CommendationType.Certificate, "Награждение грамотой" },
            { CommendationType.Gift, "Награждение ценным подарком" },
            { CommendationType.Medal, "Награждение медалью" }
        };
    }
}
