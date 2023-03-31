using Application.Dtos;
using Application.DTOs.Distribuitor;

namespace Application.Validations.Management
{
    public interface IDistribuitorManagement
    {
        Task Manage(DistribuitorDTO distribuitor);
    }
}