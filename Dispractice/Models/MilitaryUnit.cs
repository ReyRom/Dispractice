using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace Dispractice.Models
{
    // Модель подразделения
    [ObservableObject]
    public partial class MilitaryUnit: IMilitaryTreeNode
    {
        private string name = "Подразделение";
        private string? shortName;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get ; set; }

        [Required]
        [StringLength(100)]
        public string Name { get => name; set => SetProperty(ref name ,value); }
        [AllowNull]
        public string? ShortName { get => shortName; set =>SetProperty(ref shortName,value); } // Краткое название подразделения

        // Ссылка на родительское подразделение (если есть)
        [ForeignKey("ParentUnit")]
        public int? ParentUnitId { get; set; }
        public virtual MilitaryUnit? ParentUnit { get; set; }

        // Список дочерних подразделений
        public virtual ICollection<MilitaryUnit> SubUnits { get; set; }  = new ObservableCollection<MilitaryUnit>();

        // Список воинских должностей в этом подразделении
        public virtual ICollection<MilitaryPosition> Positions { get; set; } = new ObservableCollection<MilitaryPosition>();




        [NotMapped]
        public IMilitaryTreeNode Element => this;
        [NotMapped]
        public IEnumerable<IMilitaryTreeNode> SubElements => Positions.Cast<IMilitaryTreeNode>().Union(SubUnits);



        public IEnumerable<MilitaryPosition> GetSubPositions(bool recursive = true)
        {
            List<MilitaryPosition> positions = new List<MilitaryPosition>(Positions);

            if (recursive)
            {
                foreach (MilitaryUnit unit in SubUnits)
                {
                    positions.AddRange(unit.GetSubPositions(recursive));
                }
            }
            return positions;
        }
    }
}
