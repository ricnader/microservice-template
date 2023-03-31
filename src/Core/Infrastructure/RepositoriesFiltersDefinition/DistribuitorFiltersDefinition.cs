using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Domain.Entities;
using Domain.Enums;

namespace Infrastructure.RepositoriesFiltersDefinition
{
    public class DistribuitorFiltersDefinition
    {
        public static FilterDefinition<Distribuitor> CreateFilters(string name = null,
            EDistribuitorType? type = null,
            string city = null,
            string state = null,
            EDistribuitorStatus? status = null,
            DateTime? createdAtBeginDate = null,
            DateTime? createdAtEndDate = null,
            DateTime? inactivatedDateBeginDate = null,
            DateTime? inactivatedDateEndDate = null)
        {
            var builder = Builders<Distribuitor>.Filter;
            var filter = builder.Empty;

            if (!string.IsNullOrEmpty(name))
            {
                filter &= builder.Regex(x => x.Name, new BsonRegularExpression($"/{name}/"));
            }

            if (type != null)
            {
                filter &= builder.Eq(x => x.Type, type);
            }

            if (!string.IsNullOrEmpty(city))
            {
                filter &= builder.Regex(x => x.City, new BsonRegularExpression($"/{city}/"));
            }

            if (!string.IsNullOrEmpty(state))
            {
                filter &= builder.Eq(x => x.State, state);
            }

            if (status != null)
            {
                filter &= builder.Eq(x => x.Status, status);
            }

            if (createdAtBeginDate != null)
            {
                filter &= builder.Gte(x => x.CreatedAt, createdAtBeginDate);
            }

            if (createdAtEndDate != null)
            {
                filter &= builder.Lte(x => x.CreatedAt, createdAtEndDate);
            }

            if (inactivatedDateBeginDate != null)
            {
                filter &= builder.Gte(x => x.InactivatedDate, inactivatedDateBeginDate);
            }

            if (inactivatedDateEndDate != null)
            {
                filter &= builder.Lte(x => x.InactivatedDate, inactivatedDateEndDate);
            }

            return filter;
        }
    }
}