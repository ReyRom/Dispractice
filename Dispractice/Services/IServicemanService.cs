using Dispractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispractice.Services
{
    public interface IServicemanService
    {
        public IQueryable<Serviceman> GetServicemenSortedByRank();

        public void AddOrUpdateServiceman(Serviceman serviceman);
        public void UpdateServiceman(Serviceman serviceman);
        IQueryable<MilitaryUnit> GetMilitaryUnits();
        public void UpdateUnitWithoutSaving(MilitaryUnit unit);
        void RemoveUnitWithoutSaving(MilitaryUnit unit);
        void Save();
        void UpdatePositionWithoutSaving(MilitaryPosition position);
    }
}
