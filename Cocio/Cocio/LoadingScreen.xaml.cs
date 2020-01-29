using GrafiskKaffekopDerVirker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        DispatcherTimer dT = new DispatcherTimer();


        public Window1()
        {
            InitializeComponent();

            dT.Tick += new EventHandler(dt_Tick);
            dT.Interval = new TimeSpan(0, 0, 3);
            dT.Start();
            loadprogressbar();
        }

        private void dt_Tick(object sender, EventArgs e)
        {
            MainWindow db = new MainWindow();
            db.Show();
            dT.Stop();
            this.Close();
        }

        private void loadprogressbar()
        {
            Duration dur = new Duration(TimeSpan.FromSeconds(5));
            DoubleAnimation dblani = new DoubleAnimation(200.0, dur);
            pb1.BeginAnimation(ProgressBar.ValueProperty, dblani);
        }
    }
}
