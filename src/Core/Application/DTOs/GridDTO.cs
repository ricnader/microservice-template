namespace Application.Dtos
{
    public class GridDTO
    {
        public GridDTO()
        {
            sort = new SortDTO();
            paginate = new PaginateDTO();
        }

        public SortDTO sort { get; set; }

        public PaginateDTO paginate { get; set; }
    }
}
