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
    
    public override async Task<User> Update(User user)
    {
        _context.Entry(user).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
        await _context.SaveChangesAsync();

        return user;
    }


    public override async Task<User> Get(long id)
    {
        var user = await _context.Users.Where<User>(u => u.Id == id).AsNoTracking().ToListAsync();
        return user.FirstOrDefault();
    }
    public override async Task<List<User>> Get()
    {
        var alluser = await _context.Users.AsNoTracking().ToListAsync();
        return alluser;
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

    public async Task<List<User>> SearchByEmail(string email)
    {
        var allUsers = await _context.Users
            .Where
            (
                x =>
                    x.Email.ToLower().Contains(email.ToLower())
            )
            .AsNoTracking()
            .ToListAsync();

        return allUsers;
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