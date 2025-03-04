using Dispractice.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Dispractice.Services
{
    public class ServicemanService : IServicemanService
    {
        private readonly MilitaryServiceContext _context;

        public ServicemanService(MilitaryServiceContext context)
        {
            _context = context;
        }

        public IQueryable<Serviceman> GetServicemenSortedByRank()
        {
            return _context.Servicemans
                .AsEnumerable()
                .OrderBy(s => RankData.Ranks[s.RankIndex].SeniorityOrder)
                .AsQueryable();
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
            return (serviceman.IsNaval ? RankData.NavalRanks : RankData.Ranks)[serviceman.RankIndex].RankName;
        }

        //public string GetRankType(Serviceman serviceman)
        //{
        //    return RankData.Ranks[serviceman.RankIndex].RankType;
        //}

        public void AddCommendation(int servicemanId, string description, DateTime dateAwarded, string awardedBy, string type)
        {
            var commendation = new Commendation
            {
                ServicemanId = servicemanId,
                Description = description,
                DateAwarded = dateAwarded,
                AwardedBy = awardedBy,
                Type = type
            };

            _context.Commendations.Add(commendation);
            _context.SaveChanges();
        }

        public void AddPenalty(int servicemanId, string basis, DateTime offenseDate, DateTime dateApplied, string appliedBy, DateTime? expirationDate = null)
        {
            var penalty = new Penalty
            {
                ServicemanId = servicemanId,
                Description = basis,
                OffenseDate = offenseDate,
                DateApplied = dateApplied,
                AppliedBy = appliedBy,
                //ExpirationDate = expirationDate
            };

            _context.Penalties.Add(penalty);
            _context.SaveChanges();
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
                    Type = "Penalty Removal"
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

        public void AddOrUpdateServiceman(Serviceman serviceman)
        {
            _context.Servicemans.Update(serviceman);
            _context.SaveChanges();
        }



        public void UpdateServiceman(Serviceman serviceman)
        {
            
        }

        public IQueryable<MilitaryUnit> GetMilitaryUnits()
        {
            var units = _context.MilitaryUnits
                .Where(u=>u.ParentUnit == null)
                .Include(u => u.SubUnits)
                .ThenInclude(u => u.SubUnits)
                .Include(u => u.Positions)
                .AsQueryable();
            return units;
        }

        public void UpdateUnitWithoutSaving(MilitaryUnit unit)
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

        public void RemoveUnitWithoutSaving(MilitaryUnit unit)
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

        public void UpdatePositionWithoutSaving(MilitaryPosition position)
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

        public void RemovePositionWithoutSaving(MilitaryPosition position)
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
