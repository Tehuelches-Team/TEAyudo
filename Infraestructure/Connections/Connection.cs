using FireSharp.Config;
using FireSharp.Interfaces;

namespace Infraestructure.Connections
{
    public class Connection
    {

        //firebase connection Settings
        public IFirebaseConfig fc = new FirebaseConfig()
        {
            AuthSecret = "7MmbftosmnXSyLCzx30M64oeVn1MStnOjQy24PVk",
            BasePath = "https://chatteayudo-default-rtdb.firebaseio.com/"
        };

        public IFirebaseClient client;
        //Code to warn console if class cannot connect when called.
        public Connection()
        {
            try
            {
                client = new FireSharp.FirebaseClient(fc);
            }
            catch (Exception)
            {
                Console.WriteLine("No se pudo conectar al servicio Firebase");
            }
        }

    }
}
