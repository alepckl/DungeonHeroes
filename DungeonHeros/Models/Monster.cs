using System;
using System.Collections.Generic;
using DungeonHeros.Models.CustomValidations;

namespace DungeonHeros.Models
{
    [MonsterValidation]
    public class Monster
    {
        public int MonsterId { get; set; }
        
        public string MonsterName { set; get; }

        public string ImagePath { set; get; } =
            "https://eldenring.wiki.fextralife.com/file/Elden-Ring/rotten_stray_1_enemies_elden_ring_wiki_600px.jpg";
        
        public int RaceId { set; get; }
        
        public int Strength { set; get; }
        
        public int Stamina { set; get; }
        
        public IList<Dungeon>? Dungeons { set; get; }
    }
}