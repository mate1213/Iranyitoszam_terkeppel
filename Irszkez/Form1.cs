using GuigleAPI;
using GuigleAPI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gmap.net;
using Gmap;
using GMap;
using GMap.NET.WindowsForms;

namespace Irszkez
{
    public partial class Form1 : Form
    {
        Adatbazis ab = new Adatbazis();

        public Form1()
        {
            InitializeComponent();
            
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (!(ofd.ShowDialog() == DialogResult.OK))
            {
                MessageBox.Show("Hiba a fájl megnyitásakor");
            }
            else
            {
                if (!ab.Beolvas(ofd.FileName))
                {
                    MessageBox.Show("Hiba a beolvasás közben!");
                }
                else
                {
                    btKereses.Enabled = true;
                    foreach (Irszam irsz in ab.IrSzamok)
                    {
                        lbEredmeny.Items.Add(irsz);
                    }
                }
            }
        }

        private void btKereses_Click(object sender, EventArgs e)
        {
            List<Irszam> eredm = new List<Irszam>();
            if (rbIrszam.Checked)
            {
                try
                {
                    eredm = ab.KeresIrsz(int.Parse(tbKeres.Text));
                }
                catch (FormatException)
                {
                    MessageBox.Show("Betű nem elfogadott!");
                }
            }
            if (rbMegye.Checked)
            {
                eredm = ab.KeresMegye(tbKeres.Text);
            }
            if (rbVaros.Checked)
            {
                eredm = ab.KeresVaros(tbKeres.Text);
            }
            lbEredmeny.Items.Clear();
            foreach (Irszam item in eredm)
            {
                lbEredmeny.Items.Add(item);
            }
            label1.Text = eredm.Count().ToString();
            if (eredm.Count() == 0)
            {
                MessageBox.Show("Nincs találat!");
            }

        }

        private void lbEredmeny_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Btn_OpenMap_Click(object sender, EventArgs e)
        {
            Terkep t = new Terkep();
            t.Show();
        }
    }
}
