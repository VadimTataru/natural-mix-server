using Microsoft.EntityFrameworkCore;
using NaturalMixApi.DB;
using NaturalMixApi.Models;
using NaturalMixApi.Repository.Interface;
using System.Diagnostics;

namespace NaturalMixApi.Repository.Implementation
{
    public class ComponentItemRepository : IComponentItemRepository
    {
        private readonly NaturalMixDbContext context;

        public ComponentItemRepository(NaturalMixDbContext context)
        {
            this.context = context;
        }

        public async Task<List<ComponentItem>> GetComponentsInfoAsync(List<string> components)
        {
            List<ComponentItem> result = new();
            for(int i = 0; i < components.Count; i++)
            {
                try
                {
                    components[i] = components[i].Trim(new char[] { ',', ' ', '!' }).ToLower();
                    var item = await context.ComponentItems.FirstOrDefaultAsync(j => j.Name == components[i]);
                    if (item != null)
                        result.Add(item);

                }
                catch (Exception e)
                {
                    Trace.TraceError(e.ToString());
                    Console.WriteLine("Unexpected Error: " + e.Message);
                    Console.WriteLine("Details: ");
                    Console.WriteLine(e.ToString());
                }
            }
            return result;
        }
    }
}
