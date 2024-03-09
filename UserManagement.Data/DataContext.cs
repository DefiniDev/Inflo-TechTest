using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UserManagement.Models;


namespace UserManagement.Data;
public class DataContext : DbContext, IDataContext
{
    public DataContext() => Database.EnsureCreated();
    public DbSet<User>? Users { get; set; }
    public DbSet<ActionLog>? ActionLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseInMemoryDatabase("UserManagement.Data.DataContext");

    protected override void OnModelCreating(ModelBuilder model)
    {
        model
            .Entity<User>()
            .HasData(
                [
                    new User
                    {
                        Id = 1,
                        Forename = "Peter",
                        Surname = "Loew",
                        Email = "ploew@example.com",
                        IsActive = true,
                        DateOfBirth = new DateOnly(1980, 12, 5)
                    },
                    new User
                    {
                        Id = 2,
                        Forename = "Benjamin Franklin",
                        Surname = "Gates",
                        Email = "bfgates@example.com",
                        IsActive = true,
                        DateOfBirth = new DateOnly(1961, 2, 15)
                    },
                    new User
                    {
                        Id = 3,
                        Forename = "Castor",
                        Surname = "Troy",
                        Email = "ctroy@example.com",
                        IsActive = false,
                        DateOfBirth = new DateOnly(1980, 7, 1)
                    },
                    new User
                    {
                        Id = 4,
                        Forename = "Memphis",
                        Surname = "Raines",
                        Email = "mraines@example.com",
                        IsActive = true,
                        DateOfBirth = new DateOnly(1988, 6, 2)
                    },
                    new User
                    {
                        Id = 5,
                        Forename = "Stanley",
                        Surname = "Goodspeed",
                        Email = "sgodspeed@example.com",
                        IsActive = true,
                        DateOfBirth = new DateOnly(1980, 10, 24)
                    },
                    new User
                    {
                        Id = 6,
                        Forename = "H.I.",
                        Surname = "McDunnough",
                        Email = "himcdunnough@example.com",
                        IsActive = true,
                        DateOfBirth = new DateOnly(1950, 3, 1)
                    },
                    new User
                    {
                        Id = 7,
                        Forename = "Cameron",
                        Surname = "Poe",
                        Email = "cpoe@example.com",
                        IsActive = false,
                        DateOfBirth = new DateOnly(1970, 3, 22)
                    },
                    new User
                    {
                        Id = 8,
                        Forename = "Edward",
                        Surname = "Malus",
                        Email = "emalus@example.com",
                        IsActive = false,
                        DateOfBirth = new DateOnly(2012, 1, 5)
                    },
                    new User
                    {
                        Id = 9,
                        Forename = "Damon",
                        Surname = "Macready",
                        Email = "dmacready@example.com",
                        IsActive = false,
                        DateOfBirth = new DateOnly(1956, 11, 28)
                    },
                    new User
                    {
                        Id = 10,
                        Forename = "Johnny",
                        Surname = "Blaze",
                        Email = "jblaze@example.com",
                        IsActive = true,
                        DateOfBirth = new DateOnly(1977, 5, 6)
                    },
                    new User
                    {
                        Id = 11,
                        Forename = "Robin",
                        Surname = "Feld",
                        Email = "rfeld@example.com",
                        IsActive = true,
                        DateOfBirth = new DateOnly(1956, 8, 19)
                    },
                ]
        );

        model.Entity<ActionLog>().HasData(
            new[]
                {
                    new ActionLog
    {
        Id = 1,
        UserId = 1,
        ActionType = "Create",
        Timestamp = DateTime.Now.AddHours(1).AddMinutes(10),
        Notes = "This is a note for the first log."
    },
    new ActionLog
    {
        Id = 2,
        UserId = 2,
        ActionType = "Create",
        Timestamp = DateTime.Now.AddHours(2).AddMinutes(20),
        Notes = ""
    },
    new ActionLog
    {
        Id = 3,
        UserId = 3,
        ActionType = "Create",
        Timestamp = DateTime.Now.AddHours(3).AddMinutes(30),
        Notes = "This is a note for the third log."
    },
    new ActionLog
    {
        Id = 4,
        UserId = 4,
        ActionType = "Create",
        Timestamp = DateTime.Now.AddHours(4).AddMinutes(40),
        Notes = "This is a note for the fourth log."
    },
    new ActionLog
    {
        Id = 5,
        UserId = 5,
        ActionType = "Create",
        Timestamp = DateTime.Now.AddHours(5).AddMinutes(50),
        Notes = ""
    },
    new ActionLog
    {
        Id = 6,
        UserId = 6,
        ActionType = "Create",
        Timestamp = DateTime.Now.AddHours(6).AddMinutes(70),
        Notes = "This is a note for the sixth log."
    },
    new ActionLog
    {
        Id = 7,
        UserId = 7,
        ActionType = "Create",
        Timestamp = DateTime.Now.AddHours(7).AddMinutes(80),
        Notes = "This is a note for the seventh log."
    },
    new ActionLog
    {
        Id = 8,
        UserId = 8,
        ActionType = "Create",
        Timestamp = DateTime.Now.AddHours(8).AddMinutes(90),
        Notes = ""
    },
    new ActionLog
    {
        Id = 9,
        UserId = 9,
        ActionType = "Create",
        Timestamp = DateTime.Now.AddHours(9).AddMinutes(100),
        Notes = "This is a note for the ninth log."
    },
    new ActionLog
    {
        Id = 10,
        UserId = 10,
        ActionType = "Create",
        Timestamp = DateTime.Now.AddHours(10).AddMinutes(110),
        Notes = "This is a note for the tenth log."
    },
    new ActionLog
    {
        Id = 11,
        UserId = 11,
        ActionType = "Create",
        Timestamp = DateTime.Now.AddHours(11).AddMinutes(130),
        Notes = ""
    },
    new ActionLog
    {
        Id = 12,
        UserId = 1,
        ActionType = "Edit",
        Timestamp = DateTime.Now.AddHours(12).AddMinutes(100),
        Notes = "This is a note for the twelfth log."
    },
    new ActionLog
    {
        Id = 13,
        UserId = 2,
        ActionType = "Edit",
        Timestamp = DateTime.Now.AddHours(13).AddMinutes(110),
        Notes = ""
    },
    new ActionLog
    {
        Id = 14,
        UserId = 3,
        ActionType = "Edit",
        Timestamp = DateTime.Now.AddHours(14).AddMinutes(130),
        Notes = "This is a note for the fourteenth log."
    },
    new ActionLog
    {
        Id = 15,
        UserId = 1,
        ActionType = "Edit",
        Timestamp = DateTime.Now.AddHours(15).AddMinutes(10),
        Notes = ""
    },
    new ActionLog
    {
        Id = 16,
        UserId = 2,
        ActionType = "Edit",
        Timestamp = DateTime.Now.AddHours(16).AddMinutes(20),
        Notes = "This is a note for the sixteenth log."
    },
    new ActionLog
    {
        Id = 17,
        UserId = 3,
        ActionType = "Edit",
        Timestamp = DateTime.Now.AddHours(17).AddMinutes(30),
        Notes = "This is a note for the seventeenth log."
    },
    new ActionLog
    {
        Id = 18,
        UserId = 4,
        ActionType = "Edit",
        Timestamp = DateTime.Now.AddHours(18).AddMinutes(40),
        Notes = ""
    },
    new ActionLog
    {
        Id = 19,
        UserId = 5,
        ActionType = "Edit",
        Timestamp = DateTime.Now.AddHours(19).AddMinutes(50),
        Notes = "This is a note for the nineteenth log."
    },
    new ActionLog
    {
        Id = 20,
        UserId = 6,
        ActionType = "Edit",
        Timestamp = DateTime.Now.AddHours(20).AddMinutes(70),
        Notes = "This is a note for the twentieth log."
    },
    new ActionLog
    {
        Id = 21,
        UserId = 7,
        ActionType = "Edit",
        Timestamp = DateTime.Now.AddHours(21).AddMinutes(80),
        Notes = "This is a note for the twenty-first log."
    },
    new ActionLog
    {
        Id = 22,
        UserId = 8,
        ActionType = "Edit",
        Timestamp = DateTime.Now.AddHours(22).AddMinutes(90),
        Notes = ""
    },
    new ActionLog
    {
        Id = 23,
        UserId = 9,
        ActionType = "Edit",
        Timestamp = DateTime.Now.AddHours(23).AddMinutes(100),
        Notes = "This is a note for the twenty-third log."
    },
    new ActionLog
    {
        Id = 24,
        UserId = 10,
        ActionType = "Edit",
        Timestamp = DateTime.Now.AddHours(24).AddMinutes(110),
        Notes = "This is a note for the twenty-fourth log."
    },
    new ActionLog
    {
        Id = 25,
        UserId = 11,
        ActionType = "Edit",
        Timestamp = DateTime.Now.AddHours(25).AddMinutes(130),
        Notes = "This is a note for the twenty-fifth log."
    },
    new ActionLog
    {
        Id = 26,
        UserId = 1,
        ActionType = "Edit",
        Timestamp = DateTime.Now.AddHours(26).AddMinutes(100),
        Notes = ""
    },
    new ActionLog
    {
        Id = 27,
        UserId = 2,
        ActionType = "Edit",
        Timestamp = DateTime.Now.AddHours(27).AddMinutes(110),
        Notes = ""
    },
    new ActionLog
    {
        Id = 28,
        UserId = 3,
        ActionType = "Edit",
        Timestamp = DateTime.Now.AddHours(28).AddMinutes(130),
        Notes = ""
    }
        });
    }


    public IQueryable<TEntity> GetAll<TEntity>()
        where TEntity : class => base.Set<TEntity>();


    public void Create<TEntity>(TEntity entity)
        where TEntity : class
    {
        base.Add(entity);
        SaveChanges();
    }


    public new void Update<TEntity>(TEntity entity)
        where TEntity : class
    {
        base.Update(entity);
        SaveChanges();
    }


    public void Delete<TEntity>(TEntity entity)
        where TEntity : class
    {
        base.Remove(entity);
        SaveChanges();
    }


    public TEntity GetById<TEntity>(long id) where TEntity : class
    {
        TEntity entity = Set<TEntity>().Find(id)!;
        return entity;
    }
}
