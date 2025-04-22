using Dispractice.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dispractice.Services
{
    public class ServicemanService : IServicemanService
    {
        private readonly MilitaryServiceContext _context;

        public ServicemanService(MilitaryServiceContext context)
        {
            _context = context;
        }

        public IAsyncEnumerable<Serviceman> GetServicemenSortedByRankAsync()
        {
            return _context.Servicemans
                .AsAsyncEnumerable()
                .OrderByDescending(s => s.Rank.GetRank().SeniorityOrder); 
        } 

        //public IMilitaryTreeNode GetMilitaryTree()
        //{
        //    MilitaryUnit rootUnit = _context.MilitaryUnits
        //        .Where(u => u.ParentUnit == null)
        //        .Include(u => u.SubUnits)
        //        .ThenInclude(u => u.SubUnits)
        //        .Include(u => u.Positions)
        //        .ThenInclude(u => u.)



        //}

        public string GetRankName(Serviceman serviceman)
        {
            return serviceman.Rank.GetRankInfo(serviceman.IsNaval).Name;
        }

        //public string GetRankType(Serviceman serviceman)
        //{
        //    return RankData.Ranks[serviceman.RankIndex].RankType;
        //}

        public async Task AddOrUpdateCommendationAsync(Commendation commendation)
        {
            if (commendation.Id == 0)
            {
                await _context.Commendations.AddAsync(commendation);
            }
            else
            {
                _context.Commendations.Update(commendation);
            }

            await _context.SaveChangesAsync();
        }

        public async Task AddOrUpdatePenaltyAsync(Penalty penalty)
        {
            if (penalty.Id == 0)
            {
                await _context.Penalties.AddAsync(penalty);
            }
            else
            {
                _context.Penalties.Update(penalty);
            }
            await _context.SaveChangesAsync();
        }

        public void RemovePenalty(int penaltyId, string removedBy, DateTime dateRemoved)
        {
            var penalty = _context.Penalties.Find(penaltyId);
            if (penalty != null)
            {
                var commendation = new Commendation
                {
                    ServicemanId = penalty.ServicemanId,
                    Description = $"Penalty removed: {penalty.Description}",
                    DateAwarded = dateRemoved,
                    AwardedBy = removedBy,
                    //Type = "Penalty Removal"
                };

                _context.Commendations.Add(commendation);
                _context.SaveChanges();

                penalty.CommendationId = commendation.Id;
                _context.SaveChanges();
            }
        }

        public void CheckAndRemoveExpiredPenalties()
        {
            /*var penalties = _context.Penalties
                .Where(p => p.ExpirationDate.HasValue && p.ExpirationDate.Value <= DateTime.Now && !p.CommendationId.HasValue)
                .ToList();

            foreach (var penalty in penalties)
            {
                penalty.DateRemoved = penalty.ExpirationDate;
                _context.SaveChanges();
            }*/
        }

        public async Task AddOrUpdateServicemanAsync(Serviceman serviceman)
        {
            if (serviceman.Id == 0)
            {
                await _context.Servicemans.AddAsync(serviceman);
            }
            else
            {
                _context.Servicemans.Update(serviceman);
            }
            await _context.SaveChangesAsync();
        }

        public async Task RemoveServicemanAsync(Serviceman serviceman)
        {
            if (serviceman.Id != 0)
            {
                _context.Remove(serviceman);
            }
            else
            {
                _context.Entry(serviceman).State = EntityState.Detached;
            }
            await _context.SaveChangesAsync();
        }





        public void UpdateServiceman(Serviceman serviceman)
        {
            
        }

        public async Task<IEnumerable<Unit>> GetMilitaryUnits()
        {
            var units = await _context.Units
                .Where(u=>u.ParentUnit == null)
                .Include(u => u.SubUnits)
                .ThenInclude(u => u.SubUnits)
                .Include(u => u.Positions)
                .ToListAsync();
            return units;
        }

        public async Task<IEnumerable<Unit>> GetMilitaryUnitsList()
        {
            var units = await _context.Units
                .ToListAsync();
            return units;
        }

        public void UpdateUnitWithoutSaving(Unit unit)
        {
            if (unit.Id != 0)
            {
                _context.Update(unit);
            }
            else
            {
                _context.Add(unit);
            }
        }

        public void RemoveUnitWithoutSaving(Unit unit)
        {
            if (unit.Id != 0)
            {
                _context.Remove(unit);
            }
            else
            {
                _context.Entry(unit).State = EntityState.Detached;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdatePositionWithoutSaving(Position position)
        {
            if (position.Id != 0)
            {
                _context.Update(position);
            }
            else
            {
                _context.Add(position);
            }
        }

        public void RemovePositionWithoutSaving(Position position)
        {
            if (position.Id != 0)
            {
                _context.Remove(position);
            }
            else
            {
                _context.Entry(position).State = EntityState.Detached;
            }
        }

        
    }
}
