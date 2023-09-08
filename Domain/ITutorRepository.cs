using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAyudo;

namespace Domain
{
    public interface ITutorRepository
    {
        Task<Tutor> GetByIdAsync(int tutorId);
        Task<IEnumerable<Tutor>> GetAllAsync();
        Task AddAsync(Tutor tutor);
        Task UpdateAsync(Tutor tutor);
        Task DeleteAsync(int tutorId);
    }
}
