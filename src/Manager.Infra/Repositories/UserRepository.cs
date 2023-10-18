using System.ComponentModel.DataAnnotations;
using Manager.Domain.Entities;
using Manager.Infra.Context;
using Manager.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infra.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly ManagerContext _context;

    public UserRepository(ManagerContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User> GetByEmail(string email)
    {
         var user = await _context.Users
             .AsNoTracking()   
             .Where
                (
                    x => x.Email.ToLower() == email.ToLower()
                )
             .ToListAsync();
        
            return user.FirstOrDefault();
    }

    public Task<List<User>> SearchByEmail(string email)
    {
        throw new NotImplementedException();
    }


    
        
    public async Task<List<User>> SearchByName(string name)
    {
        var allUsers = await _context.Users
            .Where
            (
                x => 
                    x.Name.ToLower().Contains(name.ToLower())
                    )
            .AsNoTracking()
            .ToListAsync();

        return allUsers;
    }
}
