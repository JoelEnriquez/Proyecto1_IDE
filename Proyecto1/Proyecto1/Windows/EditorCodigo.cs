using Proyecto1.ObjetosCodigo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;

namespace Proyecto1
{
    public partial class EditorCodigo : Form
    {
        private Boolean codigoGuardado = false;
        private Proyecto proyecto;
        private PantallaInicio inicio;

        public EditorCodigo(PantallaInicio inicio)
        {
            InitializeComponent();
            this.inicio = inicio;
        }

        public void getPositionCurse()
        {
            int caretPos = editorCodigoRichText.SelectionStart;
        }

        private void EditorCodigo_Load(object sender, EventArgs e)
        {

        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void noseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!codigoGuardado)
            {
                DialogResult result = MessageBox.Show("No se ha guardado el proyecto. ¿Deseas guardarlo?","Alerta",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (result==DialogResult.Yes)
                {

                }

            }
            else
            {
                this.Close();
                inicio.Show();
            }

        }
    }
}
