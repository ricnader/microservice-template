using Domain.Enums;

namespace Application.DTOs.Distribuitor
{
    public class DistribuitorFilterDTO
    {
        public string name { get; set; }
        public EDistribuitorType? type { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public EDistribuitorStatus? status { get; set; }
        public DateTime? createdAtBeginDate { get; set; }
        public DateTime? createdAtEndDate { get; set; }
        public DateTime? inactivatedDateBeginDate { get; set; }
        public DateTime? inactivatedDateEndDate { get; set; }
    }
}
