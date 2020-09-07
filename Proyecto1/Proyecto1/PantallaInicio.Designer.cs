namespace Proyecto1
{
    partial class PantallaInicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.abrirButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.crearButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // abrirButton
            // 
            this.abrirButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.abrirButton.Image = global::Proyecto1.Properties.Resources.importar;
            this.abrirButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.abrirButton.Location = new System.Drawing.Point(377, 172);
            this.abrirButton.Name = "abrirButton";
            this.abrirButton.Size = new System.Drawing.Size(250, 150);
            this.abrirButton.TabIndex = 3;
            this.abrirButton.Text = "Abrir";
            this.abrirButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.abrirButton.UseVisualStyleBackColor = true;
            // 
            // closeButton
            // 
            this.closeButton.Image = global::Proyecto1.Properties.Resources.cerrar__1_;
            this.closeButton.Location = new System.Drawing.Point(595, 410);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(90, 90);
            this.closeButton.TabIndex = 2;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // crearButton
            // 
            this.crearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crearButton.Image = global::Proyecto1.Properties.Resources.crear;
            this.crearButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.crearButton.Location = new System.Drawing.Point(58, 172);
            this.crearButton.Name = "crearButton";
            this.crearButton.Size = new System.Drawing.Size(250, 150);
            this.crearButton.TabIndex = 0;
            this.crearButton.Text = "Crear";
            this.crearButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.crearButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(296, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "IDE GREEN";
            // 
            // PantallaInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 503);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.abrirButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.crearButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PantallaInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button crearButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button abrirButton;
        private System.Windows.Forms.Label label1;
    }
}

