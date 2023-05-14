using Microsoft.EntityFrameworkCore;
using PersonAPI.Data;
using PersonAPI.Models;
using System;

namespace PersonAPI.Repositories
{
    internal static class PersonRepositories
    {
        internal async static Task<List<Person>> GetPeopleAsync()
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.Persons.ToListAsync();
            }
        }
        internal async static Task<Person> GetPeopleByIdAsync(int personId)
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.Persons.FirstOrDefaultAsync(per=>per.PersonId == personId);
            }
        }
        internal async static Task<bool> CreatePeopleAsync(Person personToCreate)
        {
            using (var db = new ApplicationDbContext())
            {
                try
                {
                    await db.Persons.AddAsync(personToCreate);
                    return await db.SaveChangesAsync() <= 1;
                }
                catch (Exception)
                {

                    return false;
                }
                
            }
        }
        internal static async Task<bool> UpdatePeopleAsync(Person personToUpdate)
        {
            using (var db = new ApplicationDbContext())
            {
                try
                {
                    db.Persons.Update(personToUpdate);
                    return await db.SaveChangesAsync() <= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        internal static async Task<bool> DeletePeopleAsync(int personId)
        {
            using (var db = new ApplicationDbContext())
            {
                try
                {
                    Person personToDelete = await GetPeopleByIdAsync(personId);
                    db.Remove(personToDelete);
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
