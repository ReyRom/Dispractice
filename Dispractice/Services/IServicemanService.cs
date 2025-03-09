using Dispractice.Models;
using System.Linq;

namespace Dispractice.Services
{
    public interface IServicemanService
    {
        IQueryable<Serviceman> GetServicemenSortedByRank();

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
