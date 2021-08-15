
namespace SIMULACION_TP1
{
    partial class EjercicioA
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMixto = new System.Windows.Forms.Button();
            this.btnMultiplicativo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMixto
            // 
            this.btnMixto.BackColor = System.Drawing.Color.Silver;
            this.btnMixto.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMixto.Location = new System.Drawing.Point(205, 95);
            this.btnMixto.Name = "btnMixto";
            this.btnMixto.Size = new System.Drawing.Size(412, 71);
            this.btnMixto.TabIndex = 0;
            this.btnMixto.Text = "CONGRUENCIAL MIXTO";
            this.btnMixto.UseVisualStyleBackColor = false;
            this.btnMixto.Click += new System.EventHandler(this.btnMixto_Click);
            // 
            // btnMultiplicativo
            // 
            this.btnMultiplicativo.BackColor = System.Drawing.Color.Silver;
            this.btnMultiplicativo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMultiplicativo.Location = new System.Drawing.Point(205, 218);
            this.btnMultiplicativo.Name = "btnMultiplicativo";
            this.btnMultiplicativo.Size = new System.Drawing.Size(412, 71);
            this.btnMultiplicativo.TabIndex = 1;
            this.btnMultiplicativo.Text = "CONGRUENCIAL MULTIPLICATIVO";
            this.btnMultiplicativo.UseVisualStyleBackColor = false;
            this.btnMultiplicativo.Click += new System.EventHandler(this.btnMultiplicativo_Click);
            // 
            // EjercicioA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMultiplicativo);
            this.Controls.Add(this.btnMixto);
            this.Name = "EjercicioA";
            this.Text = "EjercicioA";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMixto;
        private System.Windows.Forms.Button btnMultiplicativo;
    }
}