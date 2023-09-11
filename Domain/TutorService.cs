using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain
{
    public class TutorService
    {
        private readonly ITutorRepository _tutorRepository;

        public TutorService(ITutorRepository tutorRepository)
        {
            _tutorRepository = tutorRepository;
        }

        public async Task<Tutor> GetTutorByIdAsync(int tutorId)
        {
            return await _tutorRepository.GetByIdAsync(tutorId);
        }

        public async Task<IEnumerable<Tutor>> GetAllTutorsAsync()
        {
            return await _tutorRepository.GetAllAsync();
        }

        public async Task AddTutorAsync(Tutor tutor)
        {
            await _tutorRepository.AddAsync(tutor);
        }

        public async Task UpdateTutorAsync(Tutor tutor)
        {
            await _tutorRepository.UpdateAsync(tutor);
        }

        public async Task DeleteTutorAsync(int tutorId)
        {
            await _tutorRepository.DeleteAsync(tutorId);
        }
    }
}
