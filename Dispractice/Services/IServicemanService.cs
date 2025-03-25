using Dispractice.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dispractice.Services
{
    public interface IServicemanService
    {
        Task<IEnumerable<Serviceman>> GetServicemenSortedByRankAsync();

        void AddOrUpdateServiceman(Serviceman serviceman);
        void UpdateServiceman(Serviceman serviceman);
        IQueryable<MilitaryUnit> GetMilitaryUnits();
        IQueryable<MilitaryUnit> GetMilitaryUnitsList();
        void UpdateUnitWithoutSaving(MilitaryUnit unit);
        void RemoveUnitWithoutSaving(MilitaryUnit unit);
        void Save();
        void UpdatePositionWithoutSaving(MilitaryPosition position);
        void RemovePositionWithoutSaving(MilitaryPosition position);
        void RemoveServiceman(Serviceman serviceman);
    }
}
