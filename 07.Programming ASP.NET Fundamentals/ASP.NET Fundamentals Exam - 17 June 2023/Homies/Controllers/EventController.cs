namespace Homies.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

using Homies.Data;
using Homies.Data.Entities;
using Homies.Models.Event;
using Homies.Models.Type;

[Authorize]
public class EventController : Controller
{
    private readonly HomiesDbContext _data;

    public EventController(HomiesDbContext _context)
    {
        _data = _context;
    }
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> All()
    {
        var events = await _data.Events
            .Select(e => new EventViewModel()
            {
                Id = e.Id,
                Name = e.Name,
                Start = e.Start,
                Type = e.Type.Name,
                Organiser = e.Organiser
            })
            .ToListAsync();

        return View(events);
    }

    public async Task<IActionResult> Joined()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var events = await _data.Events
            .Where(e => e.EventsParticipants.Any(ep => ep.HelperId == userId))
            .Select(e => new EventViewModel()
            {
                Id = e.Id,
                Name = e.Name,
                Start = e.Start,
                Type = e.Type.Name,
                Organiser = e.Organiser
            })
            .ToListAsync();

        return View(events);
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var types = await _data.Types
            .Select(t => new TypeViewModel()
            {
                Id = t.Id,
                Name = t.Name
            })
            .ToListAsync();
        EventAddFormModel model = new EventAddFormModel()
        {
            Types = types
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(EventAddFormModel model)
    {
        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _data.Users.FirstOrDefaultAsync(u => u.Id == userId);

        try
        {
            if (ModelState.IsValid)
            {
                Event newEvent = new Event()
                {
                    Name = model.Name,
                    Description = model.Description,
                    OrganiserId = userId,
                    Organiser = user,
                    CreatedOn = DateTime.Now,
                    Start = model.Start,
                    End = model.End,
                    TypeId = model.TypeId,
                };
                await _data.Events.AddAsync(newEvent);
                await _data.SaveChangesAsync();

                return View(model);
            }
        }
        catch
        {
            BadRequest();
        }

        return RedirectToAction("All", "Event");
    }

    [HttpPost]
    public async Task<IActionResult> Join(int id)
    {
        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var currentEvent = await _data.Events.FindAsync(id);

        try
        {
            if (!currentEvent!.EventsParticipants.Any(ep => ep.HelperId == userId))
            {
                var eventParticipant = new EventParticipant()
                {
                    EventId = id,
                    HelperId = userId
                };
                await _data.EventsParticipants.AddAsync(eventParticipant);
                await _data.SaveChangesAsync();
            }
        }
        catch
        {
            BadRequest();
        }
        return RedirectToAction("Joined", "Event");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var types = await _data.Types
            .Select(t => new TypeViewModel()
            {
                Id = t.Id,
                Name = t.Name
            })
            .ToListAsync();
        var eventToEdit = await _data.Events.FindAsync(id);

        if (eventToEdit.OrganiserId != userId)
        {
            return RedirectToAction("All", "Event");
        }

        if (eventToEdit != null)
        {
            EventEditFormModel model = new EventEditFormModel()
            {
                Name = eventToEdit.Name,
                Description = eventToEdit.Description,
                Start = eventToEdit.Start,
                End = eventToEdit.End,
                Types = types
            };
            return View(model);
        }
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, EventEditFormModel model)
    {
        var eventToEdit = await _data.Events.FindAsync(id);
        try
        {
            if (eventToEdit != null && ModelState.IsValid)
            {
                eventToEdit.Name = model.Name;
                eventToEdit.Description = model.Description;
                eventToEdit.Start = model.Start;
                eventToEdit.End = model.End;
                eventToEdit.TypeId = model.TypeId;
            }
            await _data.SaveChangesAsync();
        }
        catch
        {
            BadRequest();
        }
        return RedirectToAction("All", "Event");
    }

    [HttpPost]
    public async Task<IActionResult> Leave(int id)
    {
        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var eventToRemove = await _data.Events.FirstOrDefaultAsync(u => u.Id == id);
        try
        {
            if (eventToRemove != null)
            {
                var eventParticipant = await _data.EventsParticipants
                    .FirstOrDefaultAsync(ep => ep.EventId == id && ep.HelperId == userId);
                _data.EventsParticipants.Remove(eventParticipant!);
            }
        }
        catch
        {
            BadRequest();
        }
        await _data.SaveChangesAsync();
        return RedirectToAction("All", "Event");
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {

        var currentEvent = await _data.Events.FindAsync(id);

        var user = await _data.Users.FindAsync(currentEvent.OrganiserId);
        var type = await _data.Types.FindAsync(currentEvent.TypeId);

        if (currentEvent != null)
        {
            EventDetailsViewModel model = new EventDetailsViewModel()
            {
                Id = currentEvent.Id,
                Name = currentEvent.Name,
                Description = currentEvent.Description,
                Start = currentEvent.Start,
                End = currentEvent.End,
                Organiser = user.UserName,
                Type = type.Name,
                CreatedOn = currentEvent.CreatedOn
            };
            return View(model);
        }
        return NotFound();
    }
}

