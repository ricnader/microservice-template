using MongoDB.Bson;
using Domain.Enums;

namespace Domain.Entities
{
    public class Distribuitor : Entity
    {
        public string Name { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public EDistribuitorType Type { get; set; }
        public ObjectId? DistribuitorHeadQuartersId { get; set; }
        public EDistribuitorStatus Status { get; set; }
        public DateTime? InactivatedDate { get; set; }

        private void Activate()
        {
            Status = EDistribuitorStatus.A;
        }

        private void Inactivate()
        {
            Status = EDistribuitorStatus.I;
            InactivatedDate = DateTime.Now;
        }

        public void AlterStatus(EDistribuitorStatus newDistribuitorSatus)
        {
            if (newDistribuitorSatus == EDistribuitorStatus.A) Activate();
            else if (newDistribuitorSatus == EDistribuitorStatus.I) Inactivate();
        }
    }
}
