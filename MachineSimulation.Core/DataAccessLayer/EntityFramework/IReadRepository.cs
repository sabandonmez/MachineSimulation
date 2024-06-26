﻿using MachineSimulation.Core.EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Core.DataAccessLayer.EntityFramework
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetByIdAsync(int id, bool tracking = true);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> method, bool tracking = true);


    }
}
