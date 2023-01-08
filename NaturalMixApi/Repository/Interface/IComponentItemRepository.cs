using NaturalMixApi.Models;

namespace NaturalMixApi.Repository.Interface
{
    public interface IComponentItemRepository
    {
        Task<List<ComponentItem>> GetComponentsInfoAsync(List<string> components);
    }
}
