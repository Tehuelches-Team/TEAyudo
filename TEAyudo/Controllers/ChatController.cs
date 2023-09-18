using Infraestructure.Connections;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace TEAyudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : Controller
    {
        Connection conection = new Connection();
        [HttpPost]
        public void setData()
        {
            
           var data = new userChatDTO
            {
                userChatID = 1,
                FotoPerfil = "foto1.jpg",
                NombreUsuario = "Matias"
            
            };
            try 
            {
                var SetData = conection.client.Set("Usuarios/" + "Nombre", data);
            }
            catch (Exception ex) 
            {

            }
        }
        

    }

    
}
