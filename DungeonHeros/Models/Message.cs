using System.Collections;
using System.Collections.Generic;

namespace DungeonHeros.Models
{
    public class Message
    {
        public int MessageId { set; get; }
        
        public string MessageTitle { set; get; }
        
        public string MessageContent { set; get; }
        
        public IList<Hero> Heroes { set; get; }
    }
}