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
            FileStream stream = new FileStream("Propiedades.txt", OpenOrCreate);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek()>-1)
            {
                Propietario propiedad = new Propietario();
                propiedad
            }
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

            for (int i=0; i< propiedades.Count; i++)
            {
                for (int j = 0; j< propietarios.Count; j++)
                {
                    if (propiedades[i].dpi == propietarios[j].dpi)
                    {
                        Resumen dataResumen = new Resumen();
                        dataResumen.nombre = propietarios[j].nombre;
                        dataResumen.apellido = propietarios[j].apellido;
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
            labelNombre.Text = resumen[cuantos -1].nombre + ", " + 
        }
    }
}
