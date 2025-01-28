using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;

namespace Dispractice.Models
{
    // Модель воинской должности
    public class MilitaryPosition: IMilitaryTreeNode
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


        // Ссылка на военнослужащего, занимающего должность
        [ForeignKey("Serviceman")]
        public int? ServicemanId { get; set; }
        public virtual Serviceman? Serviceman { get; set; }



        [NotMapped]
        public IMilitaryTreeNode Element => this;
        [NotMapped]
        public IEnumerable<IMilitaryTreeNode> SubElements => null;
    }
}
