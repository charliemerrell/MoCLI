using Microsoft.EntityFrameworkCore;
using MoCLI.Data.DTOs;
using MoCLI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoCLI.Data.Repo
{
    internal class CardRepo : ICardRepo
    {
        private readonly MoCLIContext _ctx = new MoCLIContext { Connection = "Data Source=HP-ENVY; Initial Catalog=MoCLI; Integrated Security=True" };

        public async Task Create(CardCreateDTO cardDTO)
        {
            var card = new Card();
            card.Prompt = cardDTO.Prompt;
            card.Answer = cardDTO.Answer;
            card.LastWaitDays = 2;
            card.Due = DateTime.Now.AddDays(card.LastWaitDays);
            await _ctx.Cards.AddAsync(card);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<Card>> GetAllDue()
        {
            return await _ctx.Cards.Where(c => c.Due <= DateTime.Now).ToListAsync();
        }

        public async Task Mark(int id, bool correct)
        {
            var card = await _ctx.Cards.SingleOrDefaultAsync(c => c.Id == id);
            if (card != null)
            {
                var nextWait = correct ? card.LastWaitDays * 5 : card.LastWaitDays / 2;
                var nextDue = DateTime.Now.AddDays(nextWait);
                card.Due = nextDue;
                card.LastWaitDays = nextWait;
                await _ctx.SaveChangesAsync();
            }
        }
    }
}
