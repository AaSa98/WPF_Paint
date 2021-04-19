using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp5
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void schwarz_Click(object sender, RoutedEventArgs e)
        {
            canvas.DefaultDrawingAttributes.Color = Color.FromRgb(0, 0, 0);
        }
        private void blau_Click(object sender, RoutedEventArgs e)
        {
            canvas.DefaultDrawingAttributes.Color = Color.FromRgb(0, 0, 255);
        }

        private void rot_Click(object sender, RoutedEventArgs e)
        {
            canvas.DefaultDrawingAttributes.Color = Color.FromRgb(255, 0, 0);
        }

        private void grün_Click(object sender, RoutedEventArgs e)
        {
            canvas.DefaultDrawingAttributes.Color = Color.FromRgb(0, 255, 0);
        }

        private void p1_Selected(object sender, RoutedEventArgs e)
        {
            canvas.DefaultDrawingAttributes.Width = 5.00;
        }

        private void p2_Selected(object sender, RoutedEventArgs e)
        {
            canvas.DefaultDrawingAttributes.Width = 10.00;
        }

        private void p3_Selected(object sender, RoutedEventArgs e)
        {
            canvas.DefaultDrawingAttributes.Width = 25.00;
        }

        private void stift_Checked(object sender, RoutedEventArgs e)
        {
            canvas.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void radierer_Checked(object sender, RoutedEventArgs e)
        {
            canvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
        }

        private void speichern_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Image"; // Default Dateiname 
            dlg.DefaultExt = ".png"; // Default Dateierweiterung 
            dlg.Filter = "Image Files (.png)|*.png"; // Typfilter für Dateispeicherdialog 

            // Zeige den Dateispeicherdialog 
            Nullable<bool> result = dlg.ShowDialog();

            // Verarbeite Ergebnis. Nur wenn “OK” geklickt wird, wird auch gespeichert! 
            if (result == true)
            {
                // Speichere die Bilddaten in die Datei 
                string filename = dlg.FileName;

                MemoryStream ms = new MemoryStream();
                FileStream fs = new FileStream(filename, FileMode.Create);

                RenderTargetBitmap rtb = new
            RenderTargetBitmap((int)canvas.ActualWidth, (int)canvas.ActualHeight,
            96d, 96d, PixelFormats.Default);
                rtb.Render(canvas);
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(rtb));

                encoder.Save(fs);
                fs.Close();
            }
        }
    }
}
