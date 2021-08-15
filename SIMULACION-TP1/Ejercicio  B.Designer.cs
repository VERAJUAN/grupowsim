
namespace SIMULACION_TP1
{
    partial class Ejercicio__B
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_resul = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.tablaanalisis = new System.Windows.Forms.DataGridView();
            this.inferior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.superior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tablaaleatorios = new System.Windows.Forms.DataGridView();
            this.Nro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aleatorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label5 = new System.Windows.Forms.Label();
            this.txt_k = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txt_m = new System.Windows.Forms.TextBox();
            this.btn_generar = new System.Windows.Forms.Button();
            this.Grafico = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cboSignificancia = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbChi = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaanalisis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaaleatorios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grafico)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.label8);
            this.GroupBox1.Controls.Add(this.tbChi);
            this.GroupBox1.Controls.Add(this.label4);
            this.GroupBox1.Controls.Add(this.label2);
            this.GroupBox1.Controls.Add(this.cboSignificancia);
            this.GroupBox1.Controls.Add(this.label1);
            this.GroupBox1.Controls.Add(this.txt_resul);
            this.GroupBox1.Controls.Add(this.Label7);
            this.GroupBox1.Controls.Add(this.tablaanalisis);
            this.GroupBox1.Controls.Add(this.tablaaleatorios);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.txt_k);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.txt_m);
            this.GroupBox1.Controls.Add(this.btn_generar);
            this.GroupBox1.Location = new System.Drawing.Point(17, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(766, 426);
            this.GroupBox1.TabIndex = 4;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Test de Chi Cuadrado: Método del Lenguaje";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 423;
            this.label1.Text = "Números Aleatorios";
            // 
            // txt_resul
            // 
            this.txt_resul.BackColor = System.Drawing.Color.White;
            this.txt_resul.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_resul.Enabled = false;
            this.txt_resul.Location = new System.Drawing.Point(352, 388);
            this.txt_resul.Name = "txt_resul";
            this.txt_resul.Size = new System.Drawing.Size(36, 20);
            this.txt_resul.TabIndex = 422;
            this.txt_resul.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(246, 392);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(105, 13);
            this.Label7.TabIndex = 421;
            this.Label7.Text = "Resultado Calculado";
            // 
            // tablaanalisis
            // 
            this.tablaanalisis.AllowUserToAddRows = false;
            this.tablaanalisis.AllowUserToDeleteRows = false;
            this.tablaanalisis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaanalisis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaanalisis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.inferior,
            this.superior,
            this.asd,
            this.Column4,
            this.Column5,
            this.Column6});
            this.tablaanalisis.Location = new System.Drawing.Point(219, 74);
            this.tablaanalisis.Name = "tablaanalisis";
            this.tablaanalisis.ReadOnly = true;
            this.tablaanalisis.Size = new System.Drawing.Size(531, 301);
            this.tablaanalisis.TabIndex = 420;
            // 
            // inferior
            // 
            this.inferior.HeaderText = "inferior";
            this.inferior.Name = "inferior";
            this.inferior.ReadOnly = true;
            // 
            // superior
            // 
            this.superior.HeaderText = "superior";
            this.superior.Name = "superior";
            this.superior.ReadOnly = true;
            // 
            // asd
            // 
            this.asd.HeaderText = "Fo";
            this.asd.Name = "asd";
            this.asd.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Fe";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "C";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "C Acumulado";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // tablaaleatorios
            // 
            this.tablaaleatorios.AllowUserToAddRows = false;
            this.tablaaleatorios.AllowUserToDeleteRows = false;
            this.tablaaleatorios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaaleatorios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaaleatorios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nro,
            this.Aleatorio});
            this.tablaaleatorios.Location = new System.Drawing.Point(18, 74);
            this.tablaaleatorios.Name = "tablaaleatorios";
            this.tablaaleatorios.ReadOnly = true;
            this.tablaaleatorios.Size = new System.Drawing.Size(171, 301);
            this.tablaaleatorios.TabIndex = 419;
            // 
            // Nro
            // 
            this.Nro.HeaderText = "Nro";
            this.Nro.Name = "Nro";
            this.Nro.ReadOnly = true;
            // 
            // Aleatorio
            // 
            this.Aleatorio.HeaderText = "Aleatorio";
            this.Aleatorio.Name = "Aleatorio";
            this.Aleatorio.ReadOnly = true;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(151, 29);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(15, 13);
            this.Label5.TabIndex = 413;
            this.Label5.Text = "m";
            // 
            // txt_k
            // 
            this.txt_k.Location = new System.Drawing.Point(242, 26);
            this.txt_k.Name = "txt_k";
            this.txt_k.Size = new System.Drawing.Size(45, 20);
            this.txt_k.TabIndex = 412;
            this.txt_k.Text = "0";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(222, 29);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(13, 13);
            this.Label6.TabIndex = 414;
            this.Label6.Text = "k";
            // 
            // txt_m
            // 
            this.txt_m.Location = new System.Drawing.Point(171, 26);
            this.txt_m.Name = "txt_m";
            this.txt_m.Size = new System.Drawing.Size(45, 20);
            this.txt_m.TabIndex = 411;
            this.txt_m.Text = "0";
            // 
            // btn_generar
            // 
            this.btn_generar.Location = new System.Drawing.Point(517, 24);
            this.btn_generar.Name = "btn_generar";
            this.btn_generar.Size = new System.Drawing.Size(78, 23);
            this.btn_generar.TabIndex = 1;
            this.btn_generar.Text = "Realizar Test";
            this.btn_generar.UseVisualStyleBackColor = true;
            this.btn_generar.Click += new System.EventHandler(this.btn_generar_Click);
            // 
            // Grafico
            // 
            chartArea4.Name = "ChartArea1";
            this.Grafico.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.Grafico.Legends.Add(legend4);
            this.Grafico.Location = new System.Drawing.Point(17, 444);
            this.Grafico.Name = "Grafico";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.Grafico.Series.Add(series4);
            this.Grafico.Size = new System.Drawing.Size(766, 350);
            this.Grafico.TabIndex = 5;
            this.Grafico.Text = "Frecuencia Observada";
            // 
            // cboSignificancia
            // 
            this.cboSignificancia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSignificancia.FormattingEnabled = true;
            this.cboSignificancia.Items.AddRange(new object[] {
            "0,95",
            "0,75",
            "0,50",
            "0,25",
            "0,05"});
            this.cboSignificancia.Location = new System.Drawing.Point(379, 26);
            this.cboSignificancia.Name = "cboSignificancia";
            this.cboSignificancia.Size = new System.Drawing.Size(121, 21);
            this.cboSignificancia.TabIndex = 424;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 425;
            this.label2.Text = "Significancia:";
            // 
            // tbChi
            // 
            this.tbChi.BackColor = System.Drawing.Color.White;
            this.tbChi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbChi.Enabled = false;
            this.tbChi.Location = new System.Drawing.Point(417, 388);
            this.tbChi.Name = "tbChi";
            this.tbChi.Size = new System.Drawing.Size(34, 20);
            this.tbChi.TabIndex = 427;
            this.tbChi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(459, 392);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 426;
            this.label4.Text = "Valor Tabla";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(393, 392);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 13);
            this.label8.TabIndex = 428;
            this.label8.Text = "Vs";
            // 
            // Ejercicio__B
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 806);
            this.Controls.Add(this.Grafico);
            this.Controls.Add(this.GroupBox1);
            this.Name = "Ejercicio__B";
            this.Text = "Ejercicio__B";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaanalisis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaaleatorios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grafico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label txt_resul;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.DataGridView tablaanalisis;
        internal System.Windows.Forms.DataGridView tablaaleatorios;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txt_k;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox txt_m;
        internal System.Windows.Forms.Button btn_generar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn inferior;
        private System.Windows.Forms.DataGridViewTextBoxColumn superior;
        private System.Windows.Forms.DataGridViewTextBoxColumn asd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aleatorio;
        private System.Windows.Forms.DataVisualization.Charting.Chart Grafico;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboSignificancia;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label tbChi;
        internal System.Windows.Forms.Label label4;
    }
}