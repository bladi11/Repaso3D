using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repaso3D
{
    public partial class Form1 : Form
    {
        List<Propiedad> propiedades = new List<Propiedad>();
        List<Propietario> propietarios = new List<Propietario>();
        List<Resumen> resumen = new List<Resumen>();
        public Form1()
        {
            InitializeComponent();
        }
        
        private void CargarPropiedades()  
        {
            FileStream stream = new FileStream("Propiedades.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek()>-1)
            {
                //carga la lista de propiedades en el orden que se agregaron a la clase y como esta en el txt
                Propiedad propiedad = new Propiedad();
                propiedad.numeroCasa = reader.ReadLine();
                propiedad.dpi = reader.ReadLine();
                propiedad.cuota = Convert.ToDecimal(reader.ReadLine());

                propiedades.Add(propiedad);
            }
            reader.Close();
        }
        private void CargarPropietarios()
        {
            FileStream stream = new FileStream("Propietarios.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                //carga la lista de propietarios en el orden que se agregaron a la clase y como esta en el txt
                Propietario propietario = new Propietario();
                propietario.dpi = reader.ReadLine();
                propietario.nombre = reader.ReadLine();
                propietario.apellido = reader.ReadLine();

                propietarios.Add(propietario);
            }
            reader.Close();
        }
        private void CargarGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = resumen;
            dataGridView1.Refresh();
        }
        private void buttonResumen_Click(object sender, EventArgs e)
        {
            CargarPropiedades();
            CargarPropietarios();

            for (int i=0; i< propiedades.Count; i++)                          //mira cuantas propiedades hay
            {
                for (int j = 0; j< propietarios.Count; j++)
                {
                    if (propiedades[i].dpi == propietarios[j].dpi)           //busca el dpi de la lista propiedades y lista de propietarios 
                    {                                                        //si son iguales con nombreresumen saca el nombre apellido  
                        Resumen dataResumen = new Resumen();                 // numerocasa y cuota
                        dataResumen.nombre = propietarios[j].nombre;
                        dataResumen.apellido = propietarios[j].apellido;
                        //datoresumen.apellido = de donde lo va a obtener
                        dataResumen.numeroCasa = propiedades[i].numeroCasa;
                        dataResumen.cuota = propiedades[i].cuota;

                        resumen.Add(dataResumen);
                    }
                }
            }

            dataGridView1.DataSource = resumen;
            dataGridView1.Refresh();

        }

        private void buttonOrdenar_Click(object sender, EventArgs e)
        {
            resumen = resumen.OrderBy(c => c.cuota).ToList();
            dataGridView1.DataSource = resumen;
            dataGridView1.Refresh();

        }

        private void buttonMayormenor_Click(object sender, EventArgs e)
        {
            labelMenor.Text = resumen[0].cuota.ToString();

            int cuantos = resumen.Count();
            labelMayor.Text = resumen[cuantos-1].cuota.ToString();
            labelNombre.Text = resumen[cuantos - 1].nombre + ", " + resumen[cuantos - 1].apellido;
        }
    }
}
