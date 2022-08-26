using Domain.Entities;
using Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Repositories.Specialization
{
    public interface IInventoryBeerQueryRepository : IQueryRepositoryBase<InventoryBeer>
    {
        public Task<IEnumerable<InventoryBeer>> GetBeerInfoByCondition(Expression<Func<InventoryBeer, Boolean>> condition);
    }

    public interface IInventoryBeerCommandRepository : ICommandRepositoryBase<InventoryBeer>
    {
    }
}