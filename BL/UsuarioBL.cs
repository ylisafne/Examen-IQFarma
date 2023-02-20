using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;

namespace BL
{
    
    public class UsuarioBL
    {
        UsuarioDAO dao = new UsuarioDAO();
        public DataSet ListUsuario() {
            return dao.ListUsuario();
        }
        public int InsertUsuario(UsuarioBE e) {
            return dao.InsertUsuario(e);
        }
    }
}
