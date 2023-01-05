using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NaturalMixApi.DB;
using NaturalMixApi.Models;

namespace NaturalMixApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentItemController : ControllerBase
    {
        private readonly NaturalMixDbContext context;

        public ComponentItemController(NaturalMixDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<IEnumerable<ComponentItem>> GetComponentsInfo(List<string> components)
        {
            List<ComponentItem> result = new();
            foreach (var component in components)
            {
                try
                {
                    var item = await context.ComponentItems.FirstOrDefaultAsync(i => i.Name == component);
                    if(item == null)
                        item = new ComponentItem(component, null, null);
                    result.Add(item);
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }            
            return result;
        }
    }
}
