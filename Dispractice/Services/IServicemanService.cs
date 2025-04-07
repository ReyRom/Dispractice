using Dispractice.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dispractice.Services
{
    public interface IServicemanService
    {
        IAsyncEnumerable<Serviceman> GetServicemenSortedByRankAsync();
        void UpdateServiceman(Serviceman serviceman);
        Task<IEnumerable<MilitaryUnit>> GetMilitaryUnits();
        Task<IEnumerable<MilitaryUnit>> GetMilitaryUnitsList();
        void UpdateUnitWithoutSaving(MilitaryUnit unit);
        void RemoveUnitWithoutSaving(MilitaryUnit unit);
        void Save();
        void UpdatePositionWithoutSaving(MilitaryPosition position);
        void RemovePositionWithoutSaving(MilitaryPosition position);
        public Task RemoveServicemanAsync(Serviceman serviceman);
        public Task AddOrUpdateServicemanAsync(Serviceman serviceman);
        public Task AddOrUpdateCommendationAsync(Commendation commendation);
        public Task AddOrUpdatePenaltyAsync(Penalty penalty);
    }
}
