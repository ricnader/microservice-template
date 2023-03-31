using Domain.Enums;

namespace Application.DTOs.Distribuitor
{
    public class DistribuitorUpdateStatusDTO
    {
        public string Id { get; set; }
        public EDistribuitorStatus Status { get; set; }
    }
}
