using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAyudo;

namespace Infraestructure.Commands
{
    public class TutorCommand : ITutorCommand
    {
        private readonly TEAyudoContext _context;

        public TutorCommand ( TEAyudoContext context)
        {
            _context = context;
        }

        public async Task InsertTutor (Tutor tutor)
        {
            _context.Add(tutor);
            _context.SaveChangesAsync();
        }
    }
}
