
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.btnListar = new System.Windows.Forms.Button();
            this.txtHasta = new System.Windows.Forms.TextBox();
            this.txtDesde = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnListarFinal = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.Label4 = new System.Windows.Forms.Label();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtS = new System.Windows.Forms.TextBox();
            this.txtC = new System.Windows.Forms.TextBox();
            this.txtM = new System.Windows.Forms.TextBox();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.random = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.PeachPuff;
            this.GroupBox1.Controls.Add(this.radioButton2);
            this.GroupBox1.Controls.Add(this.radioButton1);
            this.GroupBox1.Controls.Add(this.button1);
            this.GroupBox1.Controls.Add(this.btnListar);
            this.GroupBox1.Controls.Add(this.txtHasta);
            this.GroupBox1.Controls.Add(this.txtDesde);
            this.GroupBox1.Controls.Add(this.label6);
            this.GroupBox1.Controls.Add(this.label5);
            this.GroupBox1.Controls.Add(this.btnListarFinal);
            this.GroupBox1.Controls.Add(this.Label1);
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
            this.GroupBox1.Size = new System.Drawing.Size(787, 441);
            this.GroupBox1.TabIndex = 91;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Generador de números aleatorios";
            // 
            // btnListar
            // 
            this.btnListar.Enabled = false;
            this.btnListar.Location = new System.Drawing.Point(477, 408);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(107, 30);
            this.btnListar.TabIndex = 900;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtHasta
            // 
            this.txtHasta.Enabled = false;
            this.txtHasta.Location = new System.Drawing.Point(412, 411);
            this.txtHasta.Name = "txtHasta";
            this.txtHasta.Size = new System.Drawing.Size(59, 26);
            this.txtHasta.TabIndex = 899;
            this.txtHasta.Text = "0";
            this.txtHasta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHasta_KeyPress);
            // 
            // txtDesde
            // 
            this.txtDesde.Enabled = false;
            this.txtDesde.Location = new System.Drawing.Point(284, 411);
            this.txtDesde.Name = "txtDesde";
            this.txtDesde.Size = new System.Drawing.Size(59, 26);
            this.txtDesde.TabIndex = 898;
            this.txtDesde.Text = "0";
            this.txtDesde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDesde_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(350, 414);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 18);
            this.label6.TabIndex = 897;
            this.label6.Text = "Hasta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.label5.Location = new System.Drawing.Point(173, 414);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 18);
            this.label5.TabIndex = 896;
            this.label5.Text = "Listar desde:";
            // 
            // btnListarFinal
            // 
            this.btnListarFinal.Enabled = false;
            this.btnListarFinal.Location = new System.Drawing.Point(172, 373);
            this.btnListarFinal.Name = "btnListarFinal";
            this.btnListarFinal.Size = new System.Drawing.Size(176, 31);
            this.btnListarFinal.TabIndex = 895;
            this.btnListarFinal.Text = "Listar hasta el final";
            this.btnListarFinal.UseVisualStyleBackColor = true;
            this.btnListarFinal.Click += new System.EventHandler(this.button1_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(18, 113);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(18, 18);
            this.Label1.TabIndex = 78;
            this.Label1.Text = "A";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(18, 156);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(18, 18);
            this.Label2.TabIndex = 79;
            this.Label2.Text = "C";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Enabled = false;
            this.btnAgregar.Location = new System.Drawing.Point(255, 338);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(265, 31);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "Continuar con los próximos 20";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(15, 198);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(21, 18);
            this.Label3.TabIndex = 288;
            this.Label3.Text = "m";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(172, 338);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(77, 31);
            this.btnGenerar.TabIndex = 5;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click_1);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(5, 242);
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
            this.dgvLista.Location = new System.Drawing.Point(171, 27);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            this.dgvLista.Size = new System.Drawing.Size(538, 291);
            this.dgvLista.TabIndex = 894;
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(51, 110);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(45, 26);
            this.txtA.TabIndex = 1;
            this.txtA.Text = "0";
            this.txtA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtA_KeyPress);
            // 
            // txtS
            // 
            this.txtS.Location = new System.Drawing.Point(51, 263);
            this.txtS.Name = "txtS";
            this.txtS.Size = new System.Drawing.Size(45, 26);
            this.txtS.TabIndex = 4;
            this.txtS.Text = "0";
            this.txtS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtS_KeyPress);
            // 
            // txtC
            // 
            this.txtC.Enabled = false;
            this.txtC.Location = new System.Drawing.Point(51, 153);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(45, 26);
            this.txtC.TabIndex = 2;
            this.txtC.Text = "0";
            this.txtC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtC_KeyPress);
            // 
            // txtM
            // 
            this.txtM.Location = new System.Drawing.Point(51, 195);
            this.txtM.Name = "txtM";
            this.txtM.Size = new System.Drawing.Size(45, 26);
            this.txtM.TabIndex = 3;
            this.txtM.Text = "2";
            this.txtM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtM_KeyPress);
            // 
            // count
            // 
            this.count.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.count.HeaderText = "Nº";
            this.count.Name = "count";
            this.count.ReadOnly = true;
            this.count.Width = 90;
            // 
            // random
            // 
            this.random.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle8.Format = "N4";
            dataGridViewCellStyle8.NullValue = null;
            this.random.DefaultCellStyle = dataGridViewCellStyle8;
            this.random.HeaderText = "Aleatorio";
            this.random.Name = "random";
            this.random.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(570, 338);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 59);
            this.button1.TabIndex = 901;
            this.button1.Text = "Salir al menú";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(8, 63);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(68, 22);
            this.radioButton1.TabIndex = 902;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Mixto";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(8, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(129, 22);
            this.radioButton2.TabIndex = 903;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Multiplicativo";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
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
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button btnAgregar;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button btnGenerar;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.DataGridView dgvLista;
        internal System.Windows.Forms.TextBox txtA;
        internal System.Windows.Forms.TextBox txtS;
        internal System.Windows.Forms.TextBox txtC;
        internal System.Windows.Forms.TextBox txtM;
        private System.Windows.Forms.TextBox txtHasta;
        private System.Windows.Forms.TextBox txtDesde;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnListarFinal;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn random;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}