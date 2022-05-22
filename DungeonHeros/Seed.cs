using System;
using System.Collections.Generic;
using System.Linq;
using DungeonHeros.Models;
using DungeonHeros.Models.DataInjector;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DungeonHeros
{
    public class Seed
    {
        public static void AddDefaultRole(RoleManager<IdentityRole> rm)
        {
            IdentityRole role = rm.FindByIdAsync("1").Result;
            if (role == null)
            {
                var add = rm.CreateAsync(new IdentityRole("Admin")).Result;
                add = rm.CreateAsync(new IdentityRole("Player")).Result;
            }
        }

        public static void AddDefaultUser(UserManager<User> um, DbContext db)
        {
            User user = um.FindByIdAsync("1").Result;
            if (user != null) return;

            var race = db.Races.FirstOrDefault();
            var classe = db.Classes.FirstOrDefault();
            var hero = new Hero
            {
                Race = race, Class = classe, Level = 10, Strength = 2, Stamina = 5, HeroName = "DarkLord",
                Teams = new List<Team>()
            };
            var secondHero = new Hero
            {
                Race = race, Class = classe, Level = 2, Strength = 4, Stamina = 3, HeroName = "SkaaveTestSeed",
                Teams = new List<Team>()
            };
            var thirdHero = new Hero
            {
                Race = race, Class = classe, Level = 3, Strength = 3, Stamina = 4, HeroName = "AlexandreSeed2",
                Teams = new List<Team>()
            };

            User myAdmin = new()
            {
                Email = "darklord@test.helmo.com", UserName = "DarkLord", DateOfBirth = DateTime.Now,
                HeroName = "DarkLord", Hero = hero
            };
            User basicUser = new()
            {
                Email = "a.pickel@studentTest.helmo.be", DateOfBirth = DateTime.Now, HeroName = "SkaaveTestSeed",
                Hero = secondHero
            };
            User basicUser2 = new()
            {
                Email = "a.pickel@studentTest2.helmo.be", DateOfBirth = DateTime.Now, HeroName = "AlexandreSeed2",
                Hero = thirdHero
            };
            var add = um.CreateAsync(myAdmin, "iamyourfather").Result;
            add = um.CreateAsync(basicUser, "password12345").Result;
            add = um.CreateAsync(basicUser2, "password1234").Result;

            if (add != null)
            {
                var up = um.AddToRoleAsync(myAdmin, "Admin").Result;
                up = um.AddToRoleAsync(basicUser, "Player").Result;
                up = um.AddToRoleAsync(basicUser2, "Player").Result;
            }
        }
    }
}