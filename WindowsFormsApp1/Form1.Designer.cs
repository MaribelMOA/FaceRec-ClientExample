namespace WindowsFormsApp1
{
    partial class Form1
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
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.lblMonto = new System.Windows.Forms.Label();
            this.lblRecibido = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rbCompra = new System.Windows.Forms.RadioButton();
            this.rbVenta = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(254, 12);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(214, 43);
            this.btnIniciar.TabIndex = 0;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(217, 227);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(99, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnTerminar
            // 
            this.btnTerminar.Location = new System.Drawing.Point(436, 227);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(96, 23);
            this.btnTerminar.TabIndex = 2;
            this.btnTerminar.Text = "Terminar";
            this.btnTerminar.UseVisualStyleBackColor = true;
            this.btnTerminar.Click += new System.EventHandler(this.btnTerminar_Click);
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(370, 132);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(98, 22);
            this.txtMonto.TabIndex = 3;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(251, 135);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(44, 16);
            this.lblMonto.TabIndex = 4;
            this.lblMonto.Text = "Monto";
            this.lblMonto.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblRecibido
            // 
            this.lblRecibido.AutoSize = true;
            this.lblRecibido.Location = new System.Drawing.Point(211, 147);
            this.lblRecibido.Name = "lblRecibido";
            this.lblRecibido.Size = new System.Drawing.Size(0, 16);
            this.lblRecibido.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 8;
            // 
            // rbCompra
            // 
            this.rbCompra.AutoSize = true;
            this.rbCompra.Location = new System.Drawing.Point(242, 86);
            this.rbCompra.Name = "rbCompra";
            this.rbCompra.Size = new System.Drawing.Size(76, 20);
            this.rbCompra.TabIndex = 9;
            this.rbCompra.TabStop = true;
            this.rbCompra.Text = "Compra";
            this.rbCompra.UseVisualStyleBackColor = true;
            this.rbCompra.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rbVenta
            // 
            this.rbVenta.AutoSize = true;
            this.rbVenta.Location = new System.Drawing.Point(388, 86);
            this.rbVenta.Name = "rbVenta";
            this.rbVenta.Size = new System.Drawing.Size(63, 20);
            this.rbVenta.TabIndex = 10;
            this.rbVenta.TabStop = true;
            this.rbVenta.Text = "Venta";
            this.rbVenta.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rbVenta);
            this.Controls.Add(this.rbCompra);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRecibido);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.btnTerminar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnIniciar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnTerminar;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Label lblRecibido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbCompra;
        private System.Windows.Forms.RadioButton rbVenta;
    }
}

