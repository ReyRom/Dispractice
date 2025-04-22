using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Dispractice.Extensions;

namespace Dispractice.Models
{
    // Модель воинской должности
    public class Position
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = "Должность"; // Название должности

        [AllowNull]
        public string? ShortName { get; set; } 

        // Ссылка на подразделение, к которому относится должность
        [ForeignKey("MilitaryUnit")]
        public int UnitId { get; set; }
        public virtual Unit Unit { get; set; }


        // Ссылка на военнослужащего, занимающего должность
        public virtual Serviceman? Serviceman { get; set; }
    }
}
