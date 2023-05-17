using Microsoft.EntityFrameworkCore;
using PersonAPI.Data;
using PersonAPI.Models;
using System;

namespace PersonAPI.Repositories
{
    internal static class InterestRepositories
    {
        internal async static Task<List<Interest>> GetInterestAsync()
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.Interests.Include(i => i.Links).ToListAsync();
            }
        }
        internal async static Task<Interest> GetInterestByIdAsync(int interestId)
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.Interests.FirstOrDefaultAsync(inter => inter.InterestId == interestId);
            }
        }
        internal async static Task<bool> CreateInterestAsync(Interest interest)
        {
            using (var db = new ApplicationDbContext())
            {
                try
                {
                    await db.Interests.AddAsync(interest);
                    return await db.SaveChangesAsync() <= 1;
                }
                catch (Exception)
                {

                    return false;
                }

            }
        }
        internal static async Task<bool> UpdateInterestAsync(Interest interestToUpdate)
        {
            using (var db = new ApplicationDbContext())
            {
                try
                {
                    db.Interests.Update(interestToUpdate);
                    return await db.SaveChangesAsync() <= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        internal static async Task<bool> DeleteInterestAsync(int interestId)
        {
            using (var db = new ApplicationDbContext())
            {
                try
                {
                    Interest interestToDelete = await GetInterestByIdAsync(interestId);
                    db.Remove(interestToDelete);
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
