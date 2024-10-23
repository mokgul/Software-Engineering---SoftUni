using ArtfulAdventures.Data;
using ArtfulAdventures.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ArtfulAdventures.Web.Areas.Identity.Pages.Account.Manage;

public class ManageSkillsModel : PageModel
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ArtfulAdventuresDbContext _context;

    public ManageSkillsModel(
        UserManager<ApplicationUser> userManager,
        ArtfulAdventuresDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    [BindProperty]
    public int SelectedSkill { get; set; }

    public string? StatusMessage { get; set; }

    public IList<Skill> Skills { get; set; }

    public SelectList AvailableSkills { get; set; }

    public async Task OnGetAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        Skills = _context.ApplicationUsersSkills
            .Where(x => x.UserId == user.Id)
            .Select(x => x.Skill)
            .ToList();
        AvailableSkills = new SelectList(_context.Skills, "Id", "Type");
    }

    public async Task<IActionResult> OnPostAddSkillAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        var existingUserSkill = await _context.ApplicationUsersSkills
            .Where(x => x.UserId == user.Id && x.SkillId == SelectedSkill)
            .FirstOrDefaultAsync();
        if (existingUserSkill != null)
        {
            StatusMessage = "You already have this skill.";
            Skills = await _context.ApplicationUsersSkills
                .Where(x => x.UserId == user.Id)
                .Select(x => x.Skill)
                .ToListAsync();
            return Page();
        }

        var userSkill = new ApplicationUserSkill { UserId = user.Id, SkillId = SelectedSkill };
        _context.ApplicationUsersSkills.Add(userSkill);
        await _context.SaveChangesAsync();
        return RedirectToPage();
    }


    public async Task<IActionResult> OnPostRemoveSkillAsync(int skillId)
    {
        var user = await _userManager.GetUserAsync(User);
        var userSkill = await _context.ApplicationUsersSkills
            .Where(x => x.UserId == user.Id && x.SkillId == skillId)
            .FirstOrDefaultAsync();
        if (userSkill != null)
        {
            _context.ApplicationUsersSkills.Remove(userSkill);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage();
    }
}