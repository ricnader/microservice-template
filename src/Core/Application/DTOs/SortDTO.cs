using Domain.Enums;

namespace Application.Dtos
{
    public class SortDTO
    {
        public SortDTO()
        {
            sortby = "_id";
            direction = ESortDirection.Asc;
        }

        public string sortby { get; set; }

        public ESortDirection direction { get; set; }
    }
}
