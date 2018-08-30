using DA.TonerJobManagement.Core.Aggregates.Models;

namespace DA.TonerJobManagement.Core.Interfaces
{
    public interface ITonerRepository
    {
        Toner GetTonerById(long id);
    }
}