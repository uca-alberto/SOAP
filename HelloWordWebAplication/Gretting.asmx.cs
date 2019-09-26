using HelloWordWebAplication.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace HelloWordWebAplication
{
    /// <summary>
    /// Descripción breve de Gretting
    /// </summary>
    [WebService(Namespace = "http://uca.edu.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Gretting : System.Web.Services.WebService
    {
        private UserRepository user = new UserRepository();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod(Description = "Incrementa un monto al total acumulado")]
        public int AddProteint(int amount)
        {
            return amount;
        }
        [WebMethod(Description = "Agregar Usuario")]
        public int AddUser(string name, int goal)
        {
            var usuario = new User { Goal = goal, Name = name, Total = 0};
            user.ADD(usuario);
            return usuario.UserId;
        }
        [WebMethod(Description = "Lista de Usuario")]
        public List<User> listuser()
        {
            return new List<User>(user.GetAll());
        }
        [WebMethod(Description = "agregar un monto al total")]
        public int AddProtein(int amoun,int ID)
        {
            var user1 = user.GetById(ID);
            if (user == null)
                return -1;
            user1.Total += amoun;
            user.Save(user1);
            return user1.Total;
        }
    }
}
