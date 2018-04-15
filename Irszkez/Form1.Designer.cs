namespace Irszkez
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
            this.btnLoad = new System.Windows.Forms.Button();
            this.lbEredmeny = new System.Windows.Forms.ListBox();
            this.pnFunkcio = new System.Windows.Forms.Panel();
            this.rbMegye = new System.Windows.Forms.RadioButton();
            this.rbVaros = new System.Windows.Forms.RadioButton();
            this.rbIrszam = new System.Windows.Forms.RadioButton();
            this.tbKeres = new System.Windows.Forms.TextBox();
            this.btKereses = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_OpenMap = new System.Windows.Forms.Button();
            this.pnFunkcio.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(134, 23);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Adatbázis megnyitása";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lbEredmeny
            // 
            this.lbEredmeny.FormattingEnabled = true;
            this.lbEredmeny.Location = new System.Drawing.Point(152, 12);
            this.lbEredmeny.Name = "lbEredmeny";
            this.lbEredmeny.Size = new System.Drawing.Size(289, 381);
            this.lbEredmeny.TabIndex = 1;
            this.lbEredmeny.SelectedIndexChanged += new System.EventHandler(this.lbEredmeny_SelectedIndexChanged);
            // 
            // pnFunkcio
            // 
            this.pnFunkcio.Controls.Add(this.rbMegye);
            this.pnFunkcio.Controls.Add(this.rbVaros);
            this.pnFunkcio.Controls.Add(this.rbIrszam);
            this.pnFunkcio.Location = new System.Drawing.Point(12, 41);
            this.pnFunkcio.Name = "pnFunkcio";
            this.pnFunkcio.Size = new System.Drawing.Size(134, 90);
            this.pnFunkcio.TabIndex = 2;
            // 
            // rbMegye
            // 
            this.rbMegye.AutoSize = true;
            this.rbMegye.Location = new System.Drawing.Point(3, 49);
            this.rbMegye.Name = "rbMegye";
            this.rbMegye.Size = new System.Drawing.Size(57, 17);
            this.rbMegye.TabIndex = 2;
            this.rbMegye.TabStop = true;
            this.rbMegye.Text = "Megye";
            this.rbMegye.UseVisualStyleBackColor = true;
            // 
            // rbVaros
            // 
            this.rbVaros.AutoSize = true;
            this.rbVaros.Location = new System.Drawing.Point(3, 26);
            this.rbVaros.Name = "rbVaros";
            this.rbVaros.Size = new System.Drawing.Size(98, 17);
            this.rbVaros.TabIndex = 1;
            this.rbVaros.TabStop = true;
            this.rbVaros.Text = "Település neve";
            this.rbVaros.UseVisualStyleBackColor = true;
            // 
            // rbIrszam
            // 
            this.rbIrszam.AutoSize = true;
            this.rbIrszam.Location = new System.Drawing.Point(3, 3);
            this.rbIrszam.Name = "rbIrszam";
            this.rbIrszam.Size = new System.Drawing.Size(85, 17);
            this.rbIrszam.TabIndex = 0;
            this.rbIrszam.TabStop = true;
            this.rbIrszam.Text = "Irányítószám";
            this.rbIrszam.UseVisualStyleBackColor = true;
            // 
            // tbKeres
            // 
            this.tbKeres.Location = new System.Drawing.Point(12, 137);
            this.tbKeres.Name = "tbKeres";
            this.tbKeres.Size = new System.Drawing.Size(134, 20);
            this.tbKeres.TabIndex = 3;
            // 
            // btKereses
            // 
            this.btKereses.Enabled = false;
            this.btKereses.Location = new System.Drawing.Point(12, 163);
            this.btKereses.Name = "btKereses";
            this.btKereses.Size = new System.Drawing.Size(134, 23);
            this.btKereses.TabIndex = 4;
            this.btKereses.Text = "Keresés";
            this.btKereses.UseVisualStyleBackColor = true;
            this.btKereses.Click += new System.EventHandler(this.btKereses_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 380);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // Btn_OpenMap
            // 
            this.Btn_OpenMap.Location = new System.Drawing.Point(12, 192);
            this.Btn_OpenMap.Name = "Btn_OpenMap";
            this.Btn_OpenMap.Size = new System.Drawing.Size(134, 23);
            this.Btn_OpenMap.TabIndex = 7;
            this.Btn_OpenMap.Text = "Megjelenítés térképen";
            this.Btn_OpenMap.UseVisualStyleBackColor = true;
            this.Btn_OpenMap.Click += new System.EventHandler(this.Btn_OpenMap_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 410);
            this.Controls.Add(this.Btn_OpenMap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbKeres);
            this.Controls.Add(this.btKereses);
            this.Controls.Add(this.pnFunkcio);
            this.Controls.Add(this.lbEredmeny);
            this.Controls.Add(this.btnLoad);
            this.Name = "Form1";
            this.Text = "Form1";
            this.pnFunkcio.ResumeLayout(false);
            this.pnFunkcio.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ListBox lbEredmeny;
        private System.Windows.Forms.Panel pnFunkcio;
        private System.Windows.Forms.RadioButton rbMegye;
        private System.Windows.Forms.RadioButton rbVaros;
        private System.Windows.Forms.RadioButton rbIrszam;
        private System.Windows.Forms.TextBox tbKeres;
        private System.Windows.Forms.Button btKereses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_OpenMap;
    }
}

