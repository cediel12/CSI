using CSI.Models;
using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSI.Menu
{
    public partial class ListaBicicletas : System.Web.UI.Page
    {
        Usuario u = new Usuario();
        public DataTable dt, todo, consulcant, descripcionbici, codigoalquiler, dtmodibici, obteneridalquiler;
        public DataRow dr, drtodo, consucan, dtdescripcionbici, drmodibici, idalquilerbd;
        int id, canti;

        protected void button4_Click(object sender, EventArgs e)
        {
            dt = u.maximodealquileres(Session["IDCliente"].ToString());
            dr = dt.Rows[0];
            int max = Convert.ToInt32(dr["reserva"].ToString());
            if (max < 5)
            {
                string fechainic = fechainicio.Text.ToString();
                string fechafi = fechafin.Text.ToString();
                int diasalquiler = 1 + Convert.ToInt32(calculardiasalquier(fechainic, fechafi));
                int alquiladas = Convert.ToInt32(cantidadalqui.SelectedValue.ToString());
                if (verificaralquiler(fechainic, fechafi, Convert.ToInt32(Session["idbicialquiler"]), alquiladas, Convert.ToInt32(Session["cantibicisdispo"])))
                {

                    int cantidadfinal = Convert.ToInt32(Session["cantibicisdispo"].ToString()) - alquiladas;
                    Random r = new Random();
                    int valoruni = diasalquiler * Convert.ToInt32(Session["valorbiciunitaria"].ToString());
                    int nAleatorio3;
                    int valorpagar = valoruni * alquiladas;
                    while (true)
                    {
                        nAleatorio3 = r.Next(10000, 99990);
                        codigoalquiler = u.consultarcodigoallquiler(nAleatorio3);
                        if (codigoalquiler.Rows.Count == 0)
                        {
                            break;
                        }
                    }
                    if (u.alquilarbicicleta(fechainic, fechafi, nAleatorio3, alquiladas, valorpagar, Convert.ToInt32(Session["IDCliente"]), Convert.ToInt32(Session["idbicialquiler"])))
                    {
                        DataTable uni = u.consultarunibici(Convert.ToInt32(Session["idbicialquiler"]));
                        DataRow uniid;
                        int suma = 0;
                        for (int i = 0; i < uni.Rows.Count; i++)
                        {
                            uniid = uni.Rows[i];
                            int id = Convert.ToInt32(uniid["idbici_unidades"].ToString());
                            if (verificaralquilerunitaria(fechainic, fechafi, id))
                            {
                                //falta obtener el id del alquiler con el numero aleatoreo y realizar la incersion
                                obteneridalquiler = u.consultaridalquiler(nAleatorio3);
                                idalquilerbd = obteneridalquiler.Rows[0];
                                int idalqui = Convert.ToInt32(idalquilerbd["id_alquiler"].ToString());
                                if (u.unidad_alquilerinset(id, idalqui))
                                {
                                    suma += 1;
                                }
                                if (suma == alquiladas)
                                {
                                    break;
                                }
                            }
                        }
                        confirmaralquiler(Session["correo"].ToString(), Session["nombre_bicicletamensaje"].ToString(), alquiladas, valorpagar, nAleatorio3, fechainic);
                        ClientScript.RegisterStartupScript(this.GetType(), "randontext", "alquilerrealizado()", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('No se realizo el alquiler');", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randontext", "erroralquilar()", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randontext", "alertme()", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["direccion"] = "Bicicletas / Lista de Bicicletas";
                Session["entrada"] = "1";
                if (Session["Estado"].ToString() != "OK")
                {
                    Response.Redirect("../Home/Login.aspx");
                }
                //if (!IsPostBack)
                //{
                if (Session["rol"].ToString() == "Empresa")
                {
                    todo = u.ConsultarBicicletasempresa(Convert.ToInt32(Session["IDEMPRESA"].ToString()));
                }
                else
                {
                    todo = u.ConsultarBicicletas();

                }
                //}
                rep.DataSource = todo;
                rep.DataBind();
            }
            catch
            {
                Response.Redirect("../Home/Login.aspx");
            }


        }

        protected void button1_Click(object sender, EventArgs e)
        {
            string nommod = nombremod.Text.ToString();
            string tallmod = tallamod.Text.ToString();
            int valmod = Convert.ToInt32(valormod.Text.ToString());
            int cantmod = Convert.ToInt32(cantidadmod.Text.ToString());
            int idtipo = Convert.ToInt32(evento.SelectedValue.ToString());
            if (u.modificarbici(nommod, tallmod, valmod, cantmod, Convert.ToInt32(Session["idbicimodifi"].ToString()), idtipo))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randontext", "modificabici()", true);
            }

        }
        public void Unnamed_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName.Equals("editar"))
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                Session["idbiciuni"] = id;
                Response.Redirect("UnidadesBicicleta.aspx");

            }
            if (e.CommandName.Equals("Eliminar"))
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                if (u.eliminarbicicleta(id))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "eliminarbicicleta();", true);
                }
                Response.Redirect("ListaBicicletas.aspx");
            }
            if (e.CommandName.Equals("registrar"))
            {
                id = Convert.ToInt32(e.CommandArgument.ToString());
                consulcant = u.consulcantidad(id);
                Session["idbicialquiler"] = id;
                consucan = consulcant.Rows[0];
                canti = Convert.ToInt32(consucan["cantidad"]);
                Session["nombre_bicicletamensaje"] = consucan["nombre_bicicleta"];
                Session["valorbiciunitaria"] = consucan["valor_bicicleta"];
                Session["cantibicisdispo"] = canti;
                cantidadalqui.Items.Clear();
                cantidadalqui.DataSource = CreateDataSource();
                cantidadalqui.DataTextField = "Cantidad";
                cantidadalqui.DataValueField = "Valor";
                cantidadalqui.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);

            }
            if (e.CommandName.Equals("modificar"))
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                Session["idbicimodifi"] = id;
                dtmodibici = u.consulcantidad(id);
                drmodibici = dtmodibici.Rows[0];
                nombremod.Text = drmodibici["nombre_bicicleta"].ToString();
                tallamod.Text = drmodibici["talla"].ToString();
                valormod.Text = drmodibici["valor_bicicleta"].ToString();
                cantidadmod.Text = drmodibici["cantidad"].ToString();
                evento.DataSource = u.TipoBicicletas();
                evento.DataTextField = "nombre_tipo_bicicleta";
                evento.DataValueField = "id_tipo_bicicleta";
                evento.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "modibici();", true);
            }
            if (e.CommandName.Equals("descripcion"))
            {
                string descrip = e.CommandArgument.ToString();
                descripcionbici = u.descripcionbicicleta(descrip);
                dtdescripcionbici = descripcionbici.Rows[0];
                TextBox1.Text = dtdescripcionbici["descripcion_tipo_bicleta"].ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "opendescripcionbici();", true);
            }
        }
        ICollection CreateDataSource()
        {
            DataTable dt = null;
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Valor", typeof(int)));
            dt.Columns.Add(new DataColumn("Cantidad", typeof(int)));
            DataView dv = null;
            for (int a = 1; a <= canti; a++)
            {
                dt.Rows.Add(CreateRow(a, a, dt));
                dv = new DataView(dt);
            }
            return dv;

        }
        DataRow CreateRow(int Text, int Value, DataTable dt)
        {
            DataRow dr = null;
            dr = dt.NewRow();
            dr[0] = Text;
            dr[1] = Value;

            return dr;

        }
        public void confirmaralquiler(string correo, string nombrebici, int cantidad, int valor, int codigoalquiler, string fecha)
        {
            /*-------------------------MENSAJE DE CORREO----------------------*/

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            mmsg.To.Add(correo);

            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            //Asunto
            mmsg.Subject = "Su alquiler fue Exitosa";
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            //mmsg.Bcc.Add("destinatariocopia@servidordominio.com"); //Opcional

            //Cuerpo del Mensaje
            mmsg.Body = "Su alquiler fue exitoso, se solicita ir a la empresa y cancelar la reserva de la(s) bicicletas en un plazo maximo de 6 horas laborales" + System.Environment.NewLine
                + System.Environment.NewLine +
                "Bicicleta: " + nombrebici + System.Environment.NewLine +
                "Cantidades: " + cantidad + System.Environment.NewLine +
                "Valor total: " + valor + System.Environment.NewLine +
                "Codigo alquiler: " + codigoalquiler + System.Environment.NewLine +
                "Fecha de alquiler: " + fecha;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = false; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress("victorcediel87@gmail.com");


            /*-------------------------CLIENTE DE CORREO----------------------*/

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.Credentials =
                new System.Net.NetworkCredential("victorcediel87@gmail.com", "3125196614");

            //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail

            cliente.Port = 587;
            cliente.EnableSsl = true;


            cliente.Host = "smtp.gmail.com"; //Para Gmail "smtp.gmail.com";


            /*-------------------------ENVIO DE CORREO----------------------*/

            try
            {

                cliente.Send(mmsg);
            }
            catch (System.Net.Mail.SmtpException)
            {
            }
        }
        public string calculardiasalquier(string fechainicio, string fechafin)
        {
            DateTime startdate;
            DateTime enddate;
            TimeSpan remaindate;

            startdate = DateTime.Parse(fechainicio).Date;
            enddate = DateTime.Parse(fechafin).Date;

            remaindate = enddate - startdate;
            string dias;
            if (remaindate != null)
            {
                dias = "" + remaindate.TotalDays;
                return dias;
            }
            else
            {
                return null;
            }
        }
        public bool verificaralquiler(string fechainicio, string fechafin, int bici, int cantidadalquiladas, int cantidadtotal)
        {
            DataTable dtculsualq = u.consultarfechasalquiler(fechainicio, fechafin, bici);
            if (dtculsualq.Rows.Count > 0)
            {
                DataRow drconsualq = dtculsualq.Rows[0];
                int alquiladas = Convert.ToInt32(drconsualq["alquiladas"].ToString());
                int libres = cantidadtotal - alquiladas;
                if (libres >= cantidadalquiladas)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return true;
            }
        }
        public bool verificaralquilerunitaria(string fechainicio, string fechafin, int biciunitario)
        {
            DataTable dtculsualq = u.consultarfechasalquilerunitaria(fechainicio, fechafin, biciunitario);
            if (dtculsualq.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}