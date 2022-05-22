using System;
using System.Collections;
using System.Collections.Generic;
using DungeonHeros.Models.ManyToMany;
using Microsoft.AspNetCore.Identity;

namespace DungeonHeros.Models
{
    public class User : IdentityUser
    {
        public Hero Hero { set; get; }
        public int HeroForeignKey { set; get; }

        public string HeroName { set; get; }

        public DateTime DateOfBirth { set; get; }
    }
}