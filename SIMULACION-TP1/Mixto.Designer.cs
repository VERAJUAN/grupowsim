
namespace SIMULACION_TP1
{
    partial class Mixto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.Label4 = new System.Windows.Forms.Label();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.random = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtS = new System.Windows.Forms.TextBox();
            this.txtC = new System.Windows.Forms.TextBox();
            this.txtM = new System.Windows.Forms.TextBox();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.PeachPuff;
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.btnLimpiar);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.btnAgregar);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.btnGenerar);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.dgvLista);
            this.GroupBox1.Controls.Add(this.txtA);
            this.GroupBox1.Controls.Add(this.txtS);
            this.GroupBox1.Controls.Add(this.txtC);
            this.GroupBox1.Controls.Add(this.txtM);
            this.GroupBox1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.Location = new System.Drawing.Point(12, 5);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(740, 441);
            this.GroupBox1.TabIndex = 91;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Generador de números aleatorios";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(6, 78);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(18, 18);
            this.Label1.TabIndex = 78;
            this.Label1.Text = "A";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Enabled = false;
            this.btnLimpiar.Location = new System.Drawing.Point(631, 402);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(78, 23);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(6, 145);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(18, 18);
            this.Label2.TabIndex = 79;
            this.Label2.Text = "C";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Enabled = false;
            this.btnAgregar.Location = new System.Drawing.Point(517, 402);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(77, 23);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(6, 218);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(21, 18);
            this.Label3.TabIndex = 288;
            this.Label3.Text = "m";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(406, 402);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(77, 23);
            this.btnGenerar.TabIndex = 5;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(6, 300);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(64, 18);
            this.Label4.TabIndex = 389;
            this.Label4.Text = "Semilla";
            // 
            // dgvLista
            // 
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.count,
            this.random});
            this.dgvLista.Location = new System.Drawing.Point(171, 70);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            this.dgvLista.Size = new System.Drawing.Size(538, 291);
            this.dgvLista.TabIndex = 894;
            // 
            // count
            // 
            this.count.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.count.HeaderText = "Nº";
            this.count.Name = "count";
            this.count.ReadOnly = true;
            this.count.Width = 40;
            // 
            // random
            // 
            this.random.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Format = "N4";
            dataGridViewCellStyle2.NullValue = null;
            this.random.DefaultCellStyle = dataGridViewCellStyle2;
            this.random.HeaderText = "Aleatorio";
            this.random.Name = "random";
            this.random.ReadOnly = true;
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(55, 70);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(45, 26);
            this.txtA.TabIndex = 1;
            this.txtA.Text = "0";
            // 
            // txtS
            // 
            this.txtS.Location = new System.Drawing.Point(55, 335);
            this.txtS.Name = "txtS";
            this.txtS.Size = new System.Drawing.Size(45, 26);
            this.txtS.TabIndex = 4;
            this.txtS.Text = "0";
            // 
            // txtC
            // 
            this.txtC.Location = new System.Drawing.Point(55, 137);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(45, 26);
            this.txtC.TabIndex = 2;
            this.txtC.Text = "0";
            // 
            // txtM
            // 
            this.txtM.Location = new System.Drawing.Point(55, 215);
            this.txtM.Name = "txtM";
            this.txtM.Size = new System.Drawing.Size(45, 26);
            this.txtM.TabIndex = 3;
            this.txtM.Text = "0";
            // 
            // Mixto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GroupBox1);
            this.Name = "Mixto";
            this.Text = "Mixto";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btnLimpiar;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button btnAgregar;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button btnGenerar;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.DataGridView dgvLista;
        internal System.Windows.Forms.DataGridViewTextBoxColumn count;
        internal System.Windows.Forms.DataGridViewTextBoxColumn random;
        internal System.Windows.Forms.TextBox txtA;
        internal System.Windows.Forms.TextBox txtS;
        internal System.Windows.Forms.TextBox txtC;
        internal System.Windows.Forms.TextBox txtM;
    }
}