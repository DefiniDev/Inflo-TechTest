using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UserManagement.Models;

namespace UserManagement.Data;

public class DataContext : DbContext, IDataContext
{
    public DataContext() => Database.EnsureCreated();
    public DbSet<User>? Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseInMemoryDatabase("UserManagement.Data.DataContext");

    protected override void OnModelCreating(ModelBuilder model)
        => model.Entity<User>().HasData(new[]
        {
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
        });

    public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        => base.Set<TEntity>();

    public void Create<TEntity>(TEntity entity) where TEntity : class
    {
        base.Add(entity);
        SaveChanges();
    }

    public new void Update<TEntity>(TEntity entity) where TEntity : class
    {
        base.Update(entity);
        SaveChanges();
    }

    public void Delete<TEntity>(TEntity entity) where TEntity : class
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
