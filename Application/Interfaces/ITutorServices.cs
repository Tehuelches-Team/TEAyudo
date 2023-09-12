using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITutorServices
    {
        Task<Tutor> CreateTutor();
        Task<Tutor> DeleteTutor(int TutorId);

        Task<List<Tutor>> GetTutorList();

        Task<Tutor> GetById(int TutorId);
    }
}
