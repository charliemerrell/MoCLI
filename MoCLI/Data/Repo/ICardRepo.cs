using MoCLI.Data.Models;
using MoCLI.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoCLI.Data.Repo
{
    public interface ICardRepo
    {
        Task<IEnumerable<Card>> GetAllDue();
        Task Create(CardCreateDTO card);
        Task Mark(int id, bool correct);
    }
}
