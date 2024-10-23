namespace ArtfulAdventures.Web.Areas.Admin.Services;

using System.Threading.Tasks;

using Data;
using ArtfulAdventures.Data.Models;
using Models;
using Interfaces;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using static Common.GeneralApplicationConstants.Roles;

public class ManageUserService : IManageUserService
{
    private readonly ArtfulAdventuresDbContext _data;
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public ManageUserService(ArtfulAdventuresDbContext data,
        RoleManager<IdentityRole<Guid>> roleManager,
        UserManager<ApplicationUser> userManager)
    {
        _data = data;
        _roleManager = roleManager;
        _userManager = userManager;
    }

    /// <summary>
    ///   Promotes a user to admin.
    /// </summary>
    /// <param name="username"> The username <see cref="string"/>.</param>
    /// <exception cref="ArgumentException"> Thrown if user is not found, role is not found or user already has this role. </exception>
    public async Task PromoteToAdminAsync(string username)
    {
        var user = await _data.Users.FirstOrDefaultAsync(x => x.UserName == username);
        if (user == null)
        {
            throw new ArgumentException("User not found.");
        }
        var role = await _roleManager.FindByNameAsync(Administrator);
        if (role == null)
        {
            throw new ArgumentException("Role not found.");
        }
        var existingUserRole = await _data.UserRoles.FirstOrDefaultAsync(x => x.UserId == user.Id && x.RoleId == role.Id);
        if (existingUserRole != null)
        {
            throw new ArgumentException("User already has this role.");
        }
        await _data.UserRoles.AddAsync(new IdentityUserRole<Guid>
        {
            RoleId = role.Id,
            UserId = user.Id
        });
        await _data.SaveChangesAsync();
    }
    
    /// <summary>
    ///  Demotes a user from admin.
    /// </summary>
    /// <param name="username"> The username <see cref="string"/>.</param>
    /// <exception cref="ArgumentException"> Thrown if user is not found, role is not found or user does not have this role. </exception>
    public async Task DemoteAdminAsync(string username)
    {
        var user = await _data.Users.FirstOrDefaultAsync(x => x.UserName == username);
        if (user == null)
        {
            throw new ArgumentException("User not found.");
        }
        var role = await _roleManager.FindByNameAsync(Administrator);
        if (role == null)
        {
            throw new ArgumentException("Role not found.");
        }
        var userRole = await _data.UserRoles.FirstOrDefaultAsync(x => x.UserId == user.Id && x.RoleId == role.Id);
        if (userRole == null)
        {
            throw new ArgumentException("User role not found.");
        }
        _data.UserRoles.Remove(userRole);

        await _data.SaveChangesAsync();      
    }
    
    /// <summary>
    ///  Sets the default role for a user.
    /// </summary>
    /// <param name="username"> The username <see cref="string"/>.</param>
    /// <exception cref="ArgumentException"> Thrown if user is not found, role is not found or user already has this role. </exception>
    public async Task SetDefaultRoleAsync(string username)
    {
        var user = await _data.Users.FirstOrDefaultAsync(x => x.UserName == username);
        if (user == null)
        {
            throw new ArgumentException("User not found.");
        }
        var newRole = await _roleManager.FindByNameAsync(User);
        if (newRole == null)
        {
            throw new ArgumentException("Role not found.");
        }
        var existingUserRole = await _data.UserRoles.FirstOrDefaultAsync(x => x.UserId == user.Id && x.RoleId == newRole.Id);
        if (existingUserRole == null)
        {
            await _data.UserRoles.AddAsync(new IdentityUserRole<Guid>
            {
                RoleId = newRole.Id,
                UserId = user.Id
            });
            await _data.SaveChangesAsync();
        }
    }
    
    /// <summary>
    ///  Gets all admins.
    /// </summary>
    /// <returns> A collection of <see cref="UserViewModel"/>. </returns>
    public async Task<ICollection<UserViewModel>> GetAllAdminsAsync()
    {
        var users = await _data.Users.ToListAsync();
        var model = new List<UserViewModel>();
        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault();
            if (role == Administrator)
            {
                model.Add(new UserViewModel
                {
                    Id = user.Id.ToString(),
                    UserName = user.UserName,
                    Role = role,
                });
            }
        }
        return model;
    }

    /// <summary>
    ///  Gets all Muted users.
    /// </summary>
    /// <returns> A collection of <see cref="UserViewModel"/>. </returns>
    public async Task<ICollection<UserViewModel>> GetAllMutedUsersAsync()
    {
        var users =  await _data.Users.Where(x => x.MuteUntil > DateTime.Now).ToListAsync();
        var model = new List<UserViewModel>();
        foreach (var user in users)
        {
            var roles = _userManager.GetRolesAsync(user).Result;
            var role = roles.FirstOrDefault();
            model.Add(new UserViewModel
            {
                Id = user.Id.ToString(),
                UserName = user.UserName,
                Role = role ?? "no role",
            });
        }
        model = model.OrderBy(x => x.Role).ToList();
        return model;
    }

    /// <summary>
    ///  Gets all Banned users.
    /// </summary>
    /// <returns> A collection of <see cref="UserViewModel"/>. </returns>
    public async Task<ICollection<UserViewModel>> GetAllBannedUsersAsync()
    {
        var users = await _data.Users.Where(x => x.LockoutEnd != null).ToListAsync();
        var model = new List<UserViewModel>();
        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault();
            model.Add(new UserViewModel
            {
                Id = user.Id.ToString(),
                UserName = user.UserName,
                Role = role ?? "no role",
            });
        }
        model = model.OrderBy(x => x.Role).ToList();
        return model;
    }

    /// <summary>
    ///  Gets all users.
    /// </summary>
    /// <param name="page"> The page <see cref="int"/>.</param>
    /// <returns> A collection of <see cref="UserViewModel"/>. </returns>
    public async Task<ICollection<UserViewModel>> GetAllUsersAsync(int page = 1)
    {
        int pageSize = 10;
        int skip = (page - 1) * pageSize;
        var users = await _data.Users.Skip(skip).Take(pageSize).ToListAsync();
        var model = new List<UserViewModel>();
        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault();
            model.Add(new UserViewModel
            {
                Id = user.Id.ToString(),
                UserName = user.UserName,
                Role = role ?? "no role",
            });
        }
        model = model.OrderBy(x => x.Role).ToList();
        return model;
    }

    /// <summary>
    ///  Mutes a user.
    /// </summary>
    /// <param name="username"> The username <see cref="string"/> of the muted user.</param>
    /// <param name="days"> The duration of the mute <see cref="int"/>.</param>
    /// <param name="admin"> The admin username <see cref="string"/>.</param>
    /// <exception cref="ArgumentException"> Thrown if user is not found or admin is not found. </exception>
    public async Task MuteUserAsync(string username, int days, string admin)
    {
        var user = await _data.Users.FirstOrDefaultAsync(x => x.UserName == username);
        var adminUser = await _data.Users.FirstOrDefaultAsync(x => x.UserName == admin);
        if (adminUser == null)
        {
            throw new ArgumentException("Admin not found.");
        }
        if (user == null)
        {
            throw new ArgumentException("User not found.");
        }

        var today = DateTime.Now;
        var muteUntil = today.AddDays(days);
        user.MuteUntil = muteUntil;
        user.ReceivedMessages.Add(new Message()
        {
            Sender = adminUser,
            SenderId = adminUser.Id,
            Subject = "Warning",
            Content = $"You have been muted for {days} days.",
            Receiver = user,
            ReceiverId = user.Id,
            Timestamp = DateTime.UtcNow,
        });
        await _data.SaveChangesAsync();
    }

    /// <summary>
    ///  Removes a mute from a user.
    /// </summary>
    /// <param name="username"> The username <see cref="string"/> of the muted user.</param>
    /// <exception cref="ArgumentException"> Thrown if user is not found. </exception>
    public async Task UnmuteUserAsync(string username)
    {
        var user = await _data.Users.FirstOrDefaultAsync(x => x.UserName == username);
        if (user == null)
        {
            throw new ArgumentException("User not found.");
        }
        user.MuteUntil = null;
        await _data.SaveChangesAsync();
    }

    /// <summary>
    ///  Bans a user.
    /// </summary>
    /// <param name="username"> The username <see cref="string"/> of the banned user.</param>
    /// <exception cref="ArgumentException"> Thrown if user is not found. </exception>
    public async Task BanUserAsync(string username)
    {
        var user = await _data.Users.FirstOrDefaultAsync(x => x.UserName == username);
        if (user == null)
        {
            throw new ArgumentException("User not found.");
        }
        user.LockoutEnabled = true;
        user.LockoutEnd = DateTime.Now.AddYears(100);
        await _data.SaveChangesAsync();
    }

    /// <summary>
    ///  Removes a ban from a user.
    /// </summary>
    /// <param name="username"> The username <see cref="string"/> of the banned user.</param>
    /// <exception cref="ArgumentException"> Thrown if user is not found. </exception>
    public async Task UnbanUserAsync(string username)
    {
        var user = await _data.Users.FirstOrDefaultAsync(x => x.UserName == username);
        if (user == null)
        {
            throw new ArgumentException("User not found.");
        }
        user.LockoutEnd = null;
        await _data.SaveChangesAsync();
    }

    /// <summary>
    ///  Gets a user by username.
    /// </summary>
    /// <param name="username"> The username <see cref="string"/> of the user.</param>
    /// <returns> A <see cref="UserViewModel"/>. </returns>
    public async Task<ICollection<UserViewModel>> GetUserAsync(string username)
    {
        var user = await _data.Users.Where(x => x.UserName.Contains(username)).ToListAsync();  
        var model = new List<UserViewModel>();
        foreach(var item in user)
        {
            var roles = await _userManager.GetRolesAsync(item);
            var role = roles.FirstOrDefault();
            model.Add(new UserViewModel
            {
                Id = item.Id.ToString(),
                UserName = item.UserName,
                Role = role ?? "no role",
            });
        }
        model = model.OrderBy(x => x.Role).ToList();
        return model;
    }



}

