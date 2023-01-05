using Microsoft.EntityFrameworkCore;
using NaturalMixApi.DB;
using NaturalMixApi.Models;
using NaturalMixApi.Repository.Interface;

namespace NaturalMixApi.Repository.Implementation
{
    public class ComponentItemRepository : IComponentItemRepository
    {
        private readonly NaturalMixDbContext context;

        public ComponentItemRepository(NaturalMixDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<ComponentItem>> GetComponentsInfoAsync(List<string> components)
        {
            List<ComponentItem> result = new();
            foreach (var component in components)
            {
                try
                {
                    var item = await context.ComponentItems.FirstOrDefaultAsync(i => i.Name == component);
                    if (item == null)
                        item = new ComponentItem(component, null, null, null);
                    result.Add(item);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }
            return result;
        }
    }
}
