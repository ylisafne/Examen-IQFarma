using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AreaBL
    {
        AreaDAO dao = new AreaDAO();
        public DataSet LisArea()
        {
            return dao.ListArea();
        }
    }
}
