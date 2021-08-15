
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
            this.numS = new System.Windows.Forms.NumericUpDown();
            this.numM = new System.Windows.Forms.NumericUpDown();
            this.numC = new System.Windows.Forms.NumericUpDown();
            this.numA = new System.Windows.Forms.NumericUpDown();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.random = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.GroupBox1.Controls.Add(this.numS);
            this.GroupBox1.Controls.Add(this.numM);
            this.GroupBox1.Controls.Add(this.numC);
            this.GroupBox1.Controls.Add(this.numA);
            this.GroupBox1.Controls.Add(this.btnLimpiar);
            this.GroupBox1.Controls.Add(this.btnAgregar);
            this.GroupBox1.Controls.Add(this.btnGenerar);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.dgvLista);
            this.GroupBox1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GroupBox1.Location = new System.Drawing.Point(0, 2);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(788, 449);
            this.GroupBox1.TabIndex = 92;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Generador de números aleatorios-MIXTO";
            // 
            // numS
            // 
            this.numS.Location = new System.Drawing.Point(76, 298);
            this.numS.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numS.Name = "numS";
            this.numS.Size = new System.Drawing.Size(62, 26);
            this.numS.TabIndex = 901;
            // 
            // numM
            // 
            this.numM.Location = new System.Drawing.Point(76, 218);
            this.numM.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.numM.Name = "numM";
            this.numM.Size = new System.Drawing.Size(62, 26);
            this.numM.TabIndex = 900;
            // 
            // numC
            // 
            this.numC.Location = new System.Drawing.Point(76, 143);
            this.numC.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.numC.Name = "numC";
            this.numC.Size = new System.Drawing.Size(62, 26);
            this.numC.TabIndex = 899;
            // 
            // numA
            // 
            this.numA.Location = new System.Drawing.Point(76, 76);
            this.numA.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.numA.Name = "numA";
            this.numA.Size = new System.Drawing.Size(62, 26);
            this.numA.TabIndex = 898;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Enabled = false;
            this.btnLimpiar.Location = new System.Drawing.Point(618, 391);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(78, 32);
            this.btnLimpiar.TabIndex = 897;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(405, 391);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(77, 32);
            this.btnAgregar.TabIndex = 896;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(195, 391);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(77, 32);
            this.btnGenerar.TabIndex = 895;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(25, 78);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(18, 18);
            this.Label1.TabIndex = 78;
            this.Label1.Text = "A";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(25, 145);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(18, 18);
            this.Label2.TabIndex = 79;
            this.Label2.Text = "C";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(25, 218);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(21, 18);
            this.Label3.TabIndex = 288;
            this.Label3.Text = "m";
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
            this.dgvLista.BackgroundColor = System.Drawing.Color.Thistle;
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
            this.count.HeaderText = "Nº";
            this.count.Name = "count";
            this.count.ReadOnly = true;
            this.count.Width = 60;
            // 
            // random
            // 
            this.random.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Format = "N4";
            dataGridViewCellStyle2.NullValue = null;
            this.random.DefaultCellStyle = dataGridViewCellStyle2;
            this.random.HeaderText = "Aleatorio       ";
            this.random.Name = "random";
            this.random.ReadOnly = true;
            // 
            // Mixto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 448);
            this.Controls.Add(this.GroupBox1);
            this.Name = "Mixto";
            this.Text = "Mixto";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.DataGridView dgvLista;
        internal System.Windows.Forms.Button btnLimpiar;
        internal System.Windows.Forms.Button btnAgregar;
        internal System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.NumericUpDown numA;
        private System.Windows.Forms.NumericUpDown numS;
        private System.Windows.Forms.NumericUpDown numM;
        private System.Windows.Forms.NumericUpDown numC;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn random;
    }
}