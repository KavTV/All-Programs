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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Ports;



namespace EZ_Console
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach (string s in SerialPort.GetPortNames())
            {
                cBoxCOMPORT.Items.Add(s);
            }
        }
        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
        SerialPort serial = new SerialPort();
            try {
                serial.PortName = cBoxCOMPORT.Text;
                serial.BaudRate = Convert.ToInt32(cBoxBaudRate.Text);
                serial.DataBits = Convert.ToInt32(cBoxDataBits.Text);
                serial.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cBoxStopBits.Text);
                serial.Parity = (Parity)Enum.Parse(typeof(Parity), cBoxParityBits.Text);
                serial.Open();
                if (serial.IsOpen)
                {
                    Settings.PortName = cBoxCOMPORT.Text;
                    Settings.BaudRate = Convert.ToInt32(cBoxBaudRate.Text);
                    Settings.DataBit = Convert.ToInt32(cBoxDataBits.Text);
                    Settings.StopBit = cBoxStopBits.Text;
                    Settings.Parity = cBoxParityBits.Text;
                    serial.Close();
                    Terminal main = new Terminal();
                    this.Close();
                    main.Show();
                }
                }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            }
    }
}
