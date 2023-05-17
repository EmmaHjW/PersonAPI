using Microsoft.EntityFrameworkCore;
using PersonAPI.Data;
using PersonAPI.Models;

namespace PersonAPI.Repositories
{
    public class LinkRepositories
    {
        internal async static Task<List<Link>> GetInterestAsync()
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.Links.Include(i => i.Interests).ToListAsync();
            }
        }
        internal async static Task<bool> CreateLinkAsync(Link linkToCreate)
        {
            using (var db = new ApplicationDbContext())
            {
                try
                {
                    await db.Links.AddAsync(linkToCreate);
                    return await db.SaveChangesAsync() <= 1;
                }
                catch (Exception)
                {

                    return false;
                }

            }
        }
    }
}
