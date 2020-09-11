using Proyecto1.ObjetosCodigo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1
{
    public partial class PantallaInicio : Form
    {
        LeerGuardarProyecto leerGuardar = new LeerGuardarProyecto();
        EditorCodigo editor;
        public PantallaInicio()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void crearButton_Click(object sender, EventArgs e)
        {
            
            //Application.Run(new EditorCodigo(this,proyecto));
            if (saveFile.ShowDialog()==DialogResult.OK)
            {
                String path = saveFile.FileName+".gt";
                Proyecto proyecto = new Proyecto();
                leerGuardar.guardarProyecto(path, proyecto);
            }
        }

        private void abrirButton_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                String path = openFile.FileName;
                leerGuardar.leerProyecto(path);
                editor = new EditorCodigo(this);
                editor.Show();
                this.Close();               
            }
            
        }
    }
}