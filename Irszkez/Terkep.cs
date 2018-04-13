using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Irszkez
{
    public partial class Terkep : Form
    {
        public Terkep()
        {
            InitializeComponent();
            GMap.NET.WindowsForms.GMapControl gMapControl = new GMap.NET.WindowsForms.GMapControl();
            gMapControl.Show();
        }
    }
}
