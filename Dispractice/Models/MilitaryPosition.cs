using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Dispractice.Models
{
    // Модель воинской должности
    public class MilitaryPosition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } // Название должности

        // Ссылка на подразделение, к которому относится должность
        [ForeignKey("MilitaryUnit")]
        public int MilitaryUnitId { get; set; }
        public virtual MilitaryUnit MilitaryUnit { get; set; }
    }
}
