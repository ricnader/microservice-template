using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Application.Dtos
{
    public class PaginateDTO
    {
        public PaginateDTO()
        {
            pageIndex = 0;
            pageSize = 10;
        }

        public int pageIndex { get; set; }

        public int pageSize { get; set; }
    }
}
