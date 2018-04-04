using System;
using System.Windows.Forms;
using Vueling.Business.Logic;
using Vueling.Common.Logic.Model;
using static Vueling.Common.Logic.Enums.Enums;


namespace Vueling.Presentation.WinSite
{
    public partial class AlumnoForm : Form
    {
        private Alumno alumno;
        private IAlumnoBL alumnoBL;

        public AlumnoForm()
        {
            //Metdo que esta en la classe parcial que crea los componentes.
            InitializeComponent();
            alumno = new Alumno();
            alumnoBL = new AlumnoBL();
        }

        //La mayoria de eventos son void.
        //object sender = boton (el que envia el evento)
        //EvevntArgs e = argumentos//parametros del evento
        private void btnTxt_Click(object sender, EventArgs e)
        {
            //Sender tienes que decirle que el objeto es un boton. 
            //MessageBox.Show(((Button)sender).Text)
            //Log.Debug("Inicio de la función btnTxt_Click")
            this.LoadAlumnoData();
            alumnoBL.Add(alumno, TipoDocumento.Texto);
            MessageBox.Show("El alumno se ha guardado correctamente!");
            //Log.Debug("Fin de la función btnTxt_Click")
        }
        
        private void btnJson_Click(object sender, EventArgs e)
        {
            this.LoadAlumnoData();
            alumnoBL.Add(alumno, TipoDocumento.Json);
            MessageBox.Show("El alumno se ha guardado correctamente!");
        }

        private void btnXml_Click(object sender, EventArgs e)
        {
            this.LoadAlumnoData();
            alumnoBL.Add(alumno, TipoDocumento.Xml);
            MessageBox.Show("El alumno se ha guardado correctamente!");
        }

        private void LoadAlumnoData()
        {
            alumno.Id = Convert.ToInt32(txtId.Text);
            alumno.Nombre = txtNombre.Text;
            alumno.Apellido = txtApellidos.Text;
            alumno.Dni = txtDni.Text;
            alumno.FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
        }
    }
}
