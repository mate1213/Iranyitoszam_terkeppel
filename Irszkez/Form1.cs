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
using System.Diagnostics;

namespace Irszkez
{
    public partial class Form1 : Form
    {
        Adatbazis ab = new Adatbazis();

        private List<Irszam> eredm = new List<Irszam>();

        internal List<Irszam> Eredm { get => eredm; set => eredm = value; }

        public Form1()
        {
            InitializeComponent();
            Eredm = null;

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
            if (rbIrszam.Checked)
            {
                try
                {
                    Eredm = ab.KeresIrsz(int.Parse(tbKeres.Text));
                }
                catch (FormatException)
                {
                    MessageBox.Show("Betű nem elfogadott!");
                }
            }
            if (rbMegye.Checked)
            {
                Eredm = ab.KeresMegye(tbKeres.Text);
            }
            if (rbVaros.Checked)
            {
                Eredm = ab.KeresVaros(tbKeres.Text);
            }
            lbEredmeny.Items.Clear();
            foreach (Irszam item in Eredm)
            {
                lbEredmeny.Items.Add(item);
            }
            label1.Text = Eredm.Count().ToString();
            if (Eredm.Count() == 0)
            {
                MessageBox.Show("Nincs találat!");
            }

        }

        private void Btn_OpenMap_Click(object sender, EventArgs e)
        {
            TerkepForm tF = new TerkepForm();
            tF.Show();

            if (Eredm == null)
            {
                MessageBox.Show("Térkép nincs betöltve! :D\nNem végeztél keresést!", "Próbáld újra!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                tF.Close();
            }
            else if (Eredm.Count == 0)
            {
                tF.Terkep_Megnyitasa("Hungary", "Magyarország");
                DialogResult result = MessageBox.Show(
                                            "Térkép betöltve!\nÖsszesen " +
                                            Eredm.Count.ToString() +
                                            " város lett megjelölve! :(\n\nPróbáld újra! " +
                                            "(Retry)\nVagy térj vissza a térképhez! (Cancel)",
                                            "Próbáld újra!",
                                            MessageBoxButtons.RetryCancel,
                                            MessageBoxIcon.Warning,
                                            MessageBoxDefaultButton.Button2
                                            );
                if (result == DialogResult.Retry)
                {
                    tF.Close();
                }
            }

            else
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                tF.Iranyitoszamokdb = Eredm.Count;
                Rajzol(tF);
                sw.Stop();
                RajzolUzenet(sw);
            }
        }

        public void Rajzol(TerkepForm tF)
        {
            //TerkepForm tF = new TerkepForm();
            string temp = null;
            string tempVaros = null;
            foreach (Irszam item in Eredm)
            {
                temp = item.Irsz + ", Hungary";
                tempVaros = item.Varos;
                tF.Terkep_Megnyitasa(temp, tempVaros);
                temp = null;
                tempVaros = null;
            }
            
        }

        public void RajzolUzenet (Stopwatch sw)
        {
            TimeSpan ts = sw.Elapsed;
            MessageBox.Show(
                "Térkép betöltve! :D\nÖsszesen " +
                Eredm.Count.ToString() +
                " város lett megjelölve!" +
                "\n\nIdőtartam: " + 
                String.Format("{0}:{1}",
                    Math.Floor(ts.TotalMinutes),
                    ts.ToString("ss\\.ff")),
                "Értesítés",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1
                );
        }
    }
}
