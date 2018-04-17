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

        TerkepForm tF = new TerkepForm();

        Stopwatch sw = new Stopwatch();
        
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
            label1.Visible = true;
            label1.Text = Eredm.Count().ToString();
            if (Eredm.Count() == 0)
            {
                MessageBox.Show("Nincs találat!");
            }
        }

        private void Btn_OpenMap_Click(object sender, EventArgs e)
        {


            if (Eredm == null)
            {
                tF.Show();
                MessageBox.Show("Térkép nincs betöltve! :D\nNem végeztél keresést!", "Próbáld újra!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                tF.Close();
                tF = new TerkepForm();
            }
            else if (Eredm.Count == 0)
            {
                tF.Show();
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
                    tF = new TerkepForm();
                }
            }

            else
            {
                tF = new TerkepForm();
                sw.Start();
                tF.Show();
                
                tF.Pb_Terkep_Betoltes.Maximum = Eredm.Count;
                tF.Pb_Terkep_Betoltes.Minimum = 0;

                int jElozo = 0, holTart = 0;
                bool tempBool = false;
                string temp = null;
                string tempVaros = null;
                double j = 0, i =0, maxSzam = Eredm.Count;

                tF.Terkep_Beallitas();

                foreach (Irszam item in Eredm)
                {
                    temp = item.Irsz + ", Hungary";
                    tempVaros = item.Varos;
                    tF.Terkep_MegnyitasaIranyitoszam(temp, tempVaros);
                    temp = null;
                    tempVaros = null;

                    tF.Pb_Terkep_Betoltes.Value = holTart;
                    holTart++;
                    i++;
                    j = (i/maxSzam);

                    tempBool = int.TryParse(
                        tF.Text.Substring(
                            0, tF.Text.Count(
                                x => Char.IsDigit(x)
                            )), out jElozo);
                    System.Threading.Thread.Sleep(10);
                    tF.Text = "Terkép   Load: " + j + "%";

                    if (j != jElozo)
                    {
                        tF.Text =(string.Format("Terkép   Load: {0}", j.ToString("P3")));
                    }
                }
                sw.Stop();

                tF.Terkep_Beallitas();

                RajzolUzenet(sw, tF);
                tF.Text = "Térkép";
            }
        }

        public void RajzolUzenet(Stopwatch sw, TerkepForm form)
        {
            TimeSpan ts = sw.Elapsed;
            MessageBox.Show(
                        "Térkép betöltve! :D\nÖsszesen " +
                        Eredm.Count.ToString() +
                        " város lett megjelölve!" +
                        "\n\nIdőtartam: " +
                        String.Format("{0}:{1}",
                                Math.Floor(ts.TotalMinutes),
                                ts.ToString("ss\\.fff")),
                        "Értesítés",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1
                );
            form.Pb_Terkep_Betoltes.Visible = false;
        }
    }
}
