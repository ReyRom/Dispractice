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
    }
}
