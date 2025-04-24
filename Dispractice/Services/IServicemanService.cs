using Dispractice.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dispractice.Services
{
    public interface IServicemanService
    {
        IAsyncEnumerable<Serviceman> GetServicemenSortedByRankAsync();
        Task<Serviceman?> GetServicemanByIdAsync(int id);
        Task UpdateServiceman(Serviceman serviceman);
        Task<IEnumerable<Unit>> GetMilitaryUnits();
        Task<IEnumerable<Unit>> GetMilitaryUnitsList();
        void UpdateUnitWithoutSaving(Unit unit);
        void RemoveUnitWithoutSaving(Unit unit);
        void Save();
        void UpdatePositionWithoutSaving(Position position);
        void RemovePositionWithoutSaving(Position position);
        public Task RemoveServicemanAsync(Serviceman serviceman);
        public Task AddOrUpdateServicemanAsync(Serviceman serviceman);
        public Task AddOrUpdateCommendationAsync(Commendation commendation);
        public Task AddOrUpdatePenaltyAsync(Penalty penalty);
    }
}
