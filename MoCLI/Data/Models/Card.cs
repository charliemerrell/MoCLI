using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoCLI.Data.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Prompt { get; set; } = null!;
        public string Answer { get; set; } = null!;
        public DateTime Due { get; set; }
        public int LastWaitDays { get; set; }
    }
}
