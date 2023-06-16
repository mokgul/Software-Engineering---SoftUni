namespace TaskBoardApp.Data;

using Microsoft.AspNetCore.Identity;

using TaskBoardApp.Data.Models;

public class Seeding
{

    private static IdentityUser GetUser()
    {
        var user = new IdentityUser()
        {
            Id = "testId",
            UserName = "test@softuni.bg",
            NormalizedUserName = "TEST@SOFTUNI.BG",
        };

        user.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(user, "softuni");
        return user;
    }
    public static IdentityUser TestUser  => GetUser();

    public class Boards
    {
        public IEnumerable<Board> BoardsList { get; set; } = new List<Board>
            {
                new Board {Id = 1, Name = "Open" },
                new Board {Id = 2, Name = "In Progress" },
                new Board {Id = 3, Name = "Done" },
            };
    }

    public class Tasks
    {
        public IEnumerable<Models.Task> TasksList { get; set; } = new List<Models.Task>()
            {
                new Models.Task {
                    Id = 1,
                    Title = "Improve CSS Styles",
                    Description = "Implement better styling for all public pages",
                    CreatedOn = DateTime.Now.AddDays(-200),
                    OwnerId = TestUser.Id,
                    BoardId = 1,
                },
                new Models.Task {
                    Id = 2, 
                    Title = "Android Client App",
                    Description = "Create Android client app for the TaskBoard RESTful API",
                    CreatedOn = DateTime.Now.AddMonths(-5),
                    OwnerId = TestUser.Id,
                    BoardId = 1,
                },
                new Models.Task {
                    Id = 3,
                    Title = "Desktop Client App",
                    Description = "Create Windows Forms desktop app client for the TaskBoard RESTful API",
                    CreatedOn = DateTime.Now.AddMonths(-1),
                    OwnerId = TestUser.Id,
                    BoardId = 2,
                },
                new Models.Task {
                    Id = 4, 
                    Title = "Create Tasks",
                    Description = "Implement [Create Task] page for adding new tasks",
                    CreatedOn = DateTime.Now.AddYears(-1),
                    OwnerId = TestUser.Id,
                    BoardId = 3, 
                },
            };
    }

}
