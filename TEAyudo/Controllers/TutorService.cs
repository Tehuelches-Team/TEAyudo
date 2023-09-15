
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using TEAyudo.DTO;
using Microsoft.AspNetCore.Mvc;

namespace TEAyudo.API.Services
{
    public class TutorService
    {
        private readonly TEAyudoContext _context;

        public TutorService(TEAyudoContext context)
        {
            _context = context;
        }

        public async Task<TutorDTO> CreateTutorAsync(TutorCreateDTO tutorCreateDTO)
        {
            try
            {
                // Validar si el usuario ya existe en la tabla Usuario (por ejemplo, usando el correo electrónico)
                var existingUser = await _context.Usuarios.FirstOrDefaultAsync(u => u.CorreoElectronico == tutorCreateDTO.CorreoElectronico);

                if (existingUser != null)
                {
                    // El usuario ya existe, puedes manejar este caso según tus requisitos (por ejemplo, devolver un error)
                    return null;
                }

                // Crear una nueva instancia de Usuario a partir de los datos proporcionados
                var nuevoUsuario = new Usuario
                {
                    Nombre = tutorCreateDTO.Nombre,
                    Apellido = tutorCreateDTO.Apellido,
                    CorreoElectronico = tutorCreateDTO.CorreoElectronico,
                    Contrasena = tutorCreateDTO.Contrasena
                    // Otros campos del usuario
                };

                // Agregar el nuevo usuario a la base de datos
                _context.Usuarios.Add(nuevoUsuario);
                await _context.SaveChangesAsync();

                // Ahora que el usuario ha sido creado, puedes crear el tutor asociado
                var nuevoTutor = new Tutor
                {
                    UsuarioId = nuevoUsuario.UsuarioId,
                    // Otros campos del tutor
                };

                // Agregar el nuevo tutor a la base de datos
                _context.Tutores.Add(nuevoTutor);
                await _context.SaveChangesAsync();

                // Crear un DTO para el tutor creado y devolverlo
                var tutorDTO = new TutorDTO
                {
                    TutorId = nuevoTutor.TutorId,
                    // Otros campos del tutor que desees incluir en el DTO
                };

                return tutorDTO;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante el proceso de creación
                // Por ejemplo, puedes registrar el error en un registro de errores
                return null; // Devolver null para indicar un error
            }
        }


        public async Task<TutorDTO> GetTutorAsync(int tutorId)
        {
            try
            {
                // Obtener el tutor por su ID, incluyendo la relación con el usuario
                var tutor = await _context.Tutores
                    .Include(t => t.Usuario)
                    .FirstOrDefaultAsync(t => t.TutorId == tutorId);

                if (tutor == null)
                {
                    // El tutor no fue encontrado, puedes manejar este caso según tus requisitos (por ejemplo, devolver un error)
                    return null;
                }

                // Crear un DTO a partir de los datos del tutor y el usuario
                var tutorDTO = new TutorDTO
                {
                    TutorId = tutor.TutorId,
                    Nombre = tutor.Usuario.Nombre,
                    Apellido = tutor.Usuario.Apellido,
                    CorreoElectronico = tutor.Usuario.CorreoElectronico,
                    // Otros campos del tutor que desees incluir en el DTO
                };

                return tutorDTO;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante la operación
                // Por ejemplo, puedes registrar el error en un registro de errores
                return null; // Devolver null para indicar un error
            }
        }
    }
}

