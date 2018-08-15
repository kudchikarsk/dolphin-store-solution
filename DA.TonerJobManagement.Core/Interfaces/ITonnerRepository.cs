using DA.TonerJobManagement.Core.Aggregates.Models;

namespace DA.TonerJobManagement.Core.Interfaces
{
    public interface ITonnerRepository
    {
        Toner GetTonnerByID(long id);
    }
}