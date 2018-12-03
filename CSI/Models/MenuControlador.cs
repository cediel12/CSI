using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;


namespace CSI.Models
{
    public class MenuControlador
    {
        public void CargarMenu(string Login, HtmlGenericControl MenuGeneral)
        {
            Usuario u = new Usuario();
            Usuario Usuari = new Usuario();
            DataTable Data = Usuari.menu(Login);

            List<Menu> Nivel = new List<Menu>();
            //CREAR MENUS GENERALES
            DataTable First_Level = Data.AsEnumerable().Select(row =>
            {
                DataRow newRow = Data.NewRow();
                newRow["titulo"] = row.Field<string>("titulo");
                newRow["icono"] = row.Field<string>("icono");
                newRow["id_vista_aplicativo"] = row.Field<Int32>("id_vista_aplicativo");
                return newRow;
            }).Distinct(DataRowComparer.Default).CopyToDataTable();

            foreach (DataRow it in First_Level.Rows)
                Nivel.Add(new Menu(it));
            int index;
            //ASIGNAR VISTAS A MENUS
            foreach (DataRow it in Data.Rows)
            {

                index = IsMenu(it, Nivel, "vista_id_vista_aplicativo");
                Nivel[index].vistas.Add(new vista(it));

            }
            //CREAR MENU
            HtmlGenericControl ULMENU = new HtmlGenericControl("ul");

            ULMENU.Attributes.Add("class", "list-unstyled");
            MenuGeneral.Controls.Add(ULMENU);

            foreach (Menu it in Nivel)
            {
                ULMENU.Controls.Add(it.CrearMenu());
            }
        }
        public bool IsCero(DataRow it, string Name)
        {
            if (it[Name].ToString().Equals("0"))
                return true;
            else return false;
        }


        public int IsMenu(DataRow row, List<Menu> menus, string Name)
        {
            int index = 0, ID = Convert.ToInt32(row[Name].ToString());
            foreach (Menu it in menus)
            {
                if (it.id == ID)
                    return index;
                index++;
            }
            return -1;
        }
    }

    public class Menu
    {
        public int id;
        public string Nombre;
        public string Icono;

        public List<vista> vistas = new List<vista>();

        public Menu(DataRow it)
        {
            this.id = Convert.ToInt32(it["id_vista_aplicativo"].ToString());
            this.Nombre = it["titulo"].ToString();
            this.Icono = it["icono"].ToString();
        }

        public HtmlGenericControl CrearMenu()
        {
            HtmlGenericControl li = new HtmlGenericControl("li");
            HtmlGenericControl a = new HtmlGenericControl("a");
            HtmlGenericControl ul = new HtmlGenericControl("ul");



            a.InnerHtml = "<i class='" + Icono + "'></i>" + Nombre;
            a.Attributes.Add("href", "#" + id);
            a.Attributes.Add("class", "collapsed");
            a.Attributes.Add("aria-expanded", "fasle");
            a.Attributes.Add("data-toggle", "collapse");

            ul.Attributes.Add("class", "list-unstyled collapse");
            ul.Attributes.Add("id", "" + id);

            //li.Attributes.Add("class", "nav - item");
            //li.Attributes.Add("data-toggle", "tooltip");
            //li.Attributes.Add("data-placement", "right");
            //li.Attributes.Add("title", Nombre);


            //a.Attributes.Add("href", "#" + id.ToString());
            //a.Attributes.Add("class", "nav-link nav-link-collapse collapsed");
            //a.Attributes.Add("data-toggle", "collapse");
            //a.Attributes.Add("data-parent", "#exampleAccordion");
            //a.InnerHtml = "<i class='fa fa-fw fa-wrench'></i>" + Nombre + "<span class='nav-link-text'></span>";


            //ul.Attributes.Add("class", "sidenav-second-level collapse");
            ////ul.Attributes.Add("style", "display: none;");
            //ul.Attributes.Add("id", id.ToString());


            foreach (vista it in vistas)
            {
                ul.Controls.Add(it.CrearVista());
            }

            li.Controls.Add(a);
            li.Controls.Add(ul);
            return li;
        }
    }



    public class vista
    {
        public int padre;
        public string nombre;
        public string icono;
        public string url;
        public string id;

        public vista(DataRow it)
        {
            this.padre = Convert.ToInt32(it["vista_id_vista_aplicativo"].ToString());
            this.nombre = it["title"].ToString();
            this.icono = it["icon"].ToString();
            this.url = it["url"].ToString();
            this.id = it["id_vista_aplicativo"].ToString();
        }
        public HtmlGenericControl CrearVista()
        {
            HtmlGenericControl li = new HtmlGenericControl("li");
            //HtmlGenericControl a = new HtmlGenericControl("a");

            li.InnerHtml = "<a href='" + Convert.ToString(url) + "'>" + nombre + "</a>";
            //a.InnerHtml = "<i class='" + icono + "'></i>" + nombre;
            //a.Attributes.Add("href", Convert.ToString(url));

            //li.Controls.Add(a);
            return li;
        }
    }
}