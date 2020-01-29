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
using System.Windows.Shapes;
using System.IO.Ports;
using System.Threading;
using System.Windows.Threading;
using System.IO;

namespace EZ_Console
{
    /// <summary>
    /// Interaction logic for Terminal.xaml
    /// </summary>
    public partial class Terminal : Window
    {
        SerialPort serial = new SerialPort();
        string dataIN;
        FlowDocument mcFlowDoc = new FlowDocument();
        Paragraph para = new Paragraph();
        string secretCode;
        string secretCodeCD = Environment.CurrentDirectory + @"/ahjdv.pdf";
        public Terminal()
        {
            InitializeComponent();
            ConnectSerial();
            if (File.Exists(secretCodeCD))
            {
                secretCode = File.ReadAllText(secretCodeCD);
            }
        }

        private void CreateFile()
        {
            if (!File.Exists(secretCodeCD))
            {
                using (FileStream fs = File.Create(secretCodeCD))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(secretCode);
                    fs.Write(info, 0, info.Length);
                }
            }
        }

        private void ConnectSerial()
        {
            try
            {
                serial.PortName = Settings.PortName;
                serial.BaudRate = Settings.BaudRate;
                serial.DataBits = Settings.DataBit;
                serial.StopBits = (StopBits)Enum.Parse(typeof(StopBits), Settings.StopBit);
                serial.Parity = (Parity)Enum.Parse(typeof(Parity), Settings.Parity);
                serial.ReadTimeout = 200;
                serial.WriteTimeout = 50;
                serial.Open();
                serial.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(serial_DataReceived);

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private delegate void UpdateUiTextDelegate(string text);
        private void serial_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            dataIN = serial.ReadExisting();
            Dispatcher.Invoke(DispatcherPriority.Send, new UpdateUiTextDelegate(ShowData), dataIN);

        }
        private void ShowData(string text)
        {
            para.Inlines.Add(text);
            mcFlowDoc.Blocks.Add(para);
            tBoxReceivedData.Document = mcFlowDoc;
            tBoxReceivedData.ScrollToEnd();
        }

        private void tBoxSendText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                if (tBoxSendText.Text.Length == 0)
                {
                    serial.Write(sendReturn.Text);
                }
                else
                {
                    serial.WriteLine(tBoxSendText.Text);
                    tBoxSendText.Clear();
                }
            }
        }

        private void setPasswordBTN_Click(object sender, RoutedEventArgs e)
        {
            serial.WriteLine("enable");
            Thread.Sleep(100);
            serial.WriteLine(secretCode);
            serial.WriteLine("conf t");
            serial.WriteLine("username " + setUsernameBox.Text + " password " + setPasswordBox.Text);
        }

        private void setSecretBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                secretCode = setSecretBox.Text;
                serial.WriteLine("enable");
                serial.WriteLine("conf t");
                serial.WriteLine("enable secret "+ secretCode);
                serial.WriteLine("service password-encryption");
                if (!File.Exists(secretCodeCD))
                {
                    CreateFile();
                }
                else
                {
                    File.WriteAllText(secretCodeCD, secretCode);
                    secretCode = File.ReadAllText(secretCodeCD);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void setSSBTN_Click(object sender, RoutedEventArgs e)
        {
            serial.WriteLine("conf t");
            serial.WriteLine("hostname "+setHosnameBox.Text);
            serial.WriteLine("ip domain-name " +setDomainNameBox.Text);
            serial.WriteLine("ip ssh version 2");
            serial.WriteLine("crypto key generate rsa");
            Thread.Sleep(100);
            serial.WriteLine("2048");
            serial.WriteLine("ip ssh time-out 60");
            serial.WriteLine("ip ssh authentication-retries 3");
            serial.WriteLine("line vty 0 15");
            serial.WriteLine("login local");
        }
    }
}
