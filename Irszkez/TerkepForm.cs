using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;

namespace Irszkez
{
    public partial class TerkepForm : Form
    {
        public TerkepForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Iranyitoszamok megjelolese a terkepen, markerekkel. Place formatuma: "Irszam, Orszag". City formatuma: "Varos neve".
        /// </summary>
        /// <param name="place"></param>
        /// <param name="city"></param>
        public void Terkep_Megnyitasa (string place, string city)
        {
            PointLatLng temp = new PointLatLng();
            gmap.MapProvider = OpenStreetMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gmap.ShowCenter = false;
            gmap.SetPositionByKeywords(place);
            temp = gmap.Position;

            GMapOverlay markers = new GMapOverlay("markers");
            GMapMarker marker =
                new GMarkerGoogle(
                    new PointLatLng(temp.Lat, temp.Lng),
                    GMarkerGoogleType.blue_pushpin);
            marker.ToolTipText = city;
            marker.ToolTip.Fill = Brushes.Black;
            marker.ToolTip.Foreground = Brushes.White;
            marker.ToolTip.Stroke = Pens.Black;
            marker.ToolTip.TextPadding = new Size(20, 10);
            markers.Markers.Add(marker);
            gmap.Overlays.Add(markers);
            gmap.SetPositionByKeywords("Hungary");
        }


    }
}
