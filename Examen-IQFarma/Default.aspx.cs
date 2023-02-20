using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BL;


namespace Examen_IQFarma
{
    public partial class _Default : Page
    {
        UsuarioBE userBE = new UsuarioBE();
        UsuarioBL userBL = new UsuarioBL(); 

        AreaBE areaBE = new AreaBE();   
        AreaBL areaBL = new AreaBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GvLoad();
                DdlLoad();
            }


        }
        private void GvLoad() {

            DataSet dt = userBL.ListUsuario();
            GvList.DataSource = dt.Tables[0];
            GvList.DataBind();
        }
        private void DdlLoad() {
            ddlArea.DataSource = areaBL.LisArea();
            ddlArea.DataValueField = "Codigo";
            ddlArea.DataTextField = "Nombre";
            ddlArea.DataBind();
            this.ddlArea.Items.Insert(0, new ListItem("Seleccione", "0"));
        }
        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            UsuarioBE usr = new UsuarioBE();
            usr.Usuari = txtUsuario.Text;
            usr.Contrasena = txtcontrasena.Text;
            usr.CodigoArea = Convert.ToInt32(ddlArea.SelectedValue.ToString());
            int a = userBL.InsertUsuario(usr);
            GvLoad();
        }
    }
}