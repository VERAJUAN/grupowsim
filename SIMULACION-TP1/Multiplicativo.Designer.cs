
namespace SIMULACION_TP1
{
    partial class Multiplicativo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.random = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numS = new System.Windows.Forms.NumericUpDown();
            this.numM = new System.Windows.Forms.NumericUpDown();
            this.numA = new System.Windows.Forms.NumericUpDown();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numA)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.CadetBlue;
            this.GroupBox1.Controls.Add(this.numS);
            this.GroupBox1.Controls.Add(this.numM);
            this.GroupBox1.Controls.Add(this.numA);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.btnLimpiar);
            this.GroupBox1.Controls.Add(this.btnAgregar);
            this.GroupBox1.Controls.Add(this.btnGenerar);
            this.GroupBox1.Controls.Add(this.dgvLista);
            this.GroupBox1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.Location = new System.Drawing.Point(2, 1);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(752, 449);
            this.GroupBox1.TabIndex = 91;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Generador de números aleatorios-MULTIPLICATIVO";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Enabled = false;
            this.btnLimpiar.Location = new System.Drawing.Point(616, 347);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(78, 32);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Enabled = false;
            this.btnAgregar.Location = new System.Drawing.Point(403, 347);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(77, 32);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(193, 347);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(77, 32);
            this.btnGenerar.TabIndex = 5;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            // 
            // dgvLista
            // 
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.BackgroundColor = System.Drawing.Color.Bisque;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.count,
            this.random});
            this.dgvLista.Location = new System.Drawing.Point(193, 48);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            this.dgvLista.Size = new System.Drawing.Size(501, 257);
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
            dataGridViewCellStyle7.Format = "N4";
            dataGridViewCellStyle7.NullValue = null;
            this.random.DefaultCellStyle = dataGridViewCellStyle7;
            this.random.HeaderText = "Aleatorio";
            this.random.Name = "random";
            this.random.ReadOnly = true;
            // 
            // numS
            // 
            this.numS.Location = new System.Drawing.Point(99, 257);
            this.numS.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numS.Name = "numS";
            this.numS.Size = new System.Drawing.Size(62, 26);
            this.numS.TabIndex = 907;
            // 
            // numM
            // 
            this.numM.Location = new System.Drawing.Point(99, 170);
            this.numM.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.numM.Name = "numM";
            this.numM.Size = new System.Drawing.Size(62, 26);
            this.numM.TabIndex = 906;
            // 
            // numA
            // 
            this.numA.Location = new System.Drawing.Point(99, 80);
            this.numA.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.numA.Name = "numA";
            this.numA.Size = new System.Drawing.Size(62, 26);
            this.numA.TabIndex = 905;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(36, 82);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(18, 18);
            this.Label1.TabIndex = 902;
            this.Label1.Text = "A";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(36, 172);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(21, 18);
            this.Label3.TabIndex = 903;
            this.Label3.Text = "m";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(17, 259);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(64, 18);
            this.Label4.TabIndex = 904;
            this.Label4.Text = "Semilla";
            // 
            // Multiplicativo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 442);
            this.Controls.Add(this.GroupBox1);
            this.Name = "Multiplicativo";
            this.Text = "Multiplicativo";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btnLimpiar;
        internal System.Windows.Forms.Button btnAgregar;
        internal System.Windows.Forms.Button btnGenerar;
        internal System.Windows.Forms.DataGridView dgvLista;
        internal System.Windows.Forms.DataGridViewTextBoxColumn count;
        internal System.Windows.Forms.DataGridViewTextBoxColumn random;
        private System.Windows.Forms.NumericUpDown numS;
        private System.Windows.Forms.NumericUpDown numM;
        private System.Windows.Forms.NumericUpDown numA;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label4;
    }
}