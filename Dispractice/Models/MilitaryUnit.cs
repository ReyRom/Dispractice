using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Dispractice.Models
{
    // Модель подразделения
    public class MilitaryUnit 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } // Название подразделения

        // Ссылка на родительское подразделение (если есть)
        [ForeignKey("ParentUnit")]
        public int? ParentUnitId { get; set; }
        public virtual MilitaryUnit? ParentUnit { get; set; }

        // Список дочерних подразделений
        public virtual ICollection<MilitaryUnit> SubUnits { get; set; }

        // Список воинских должностей в этом подразделении
        public virtual ICollection<MilitaryPosition> Positions { get; set; }
    }
}
