using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Tutores
{
    public class TutorServices : ITutorServices
    {
        public Task<Tutor> CreateTutor()
        {
            throw new NotImplementedException();
        }

        public Task<Tutor> DeleteTutor(int TutorId)
        {
            throw new NotImplementedException();
        }

        public Task<Tutor> GetById(int TutorId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tutor>> GetTutorList()
        {
            throw new NotImplementedException();
        }
    }
}
