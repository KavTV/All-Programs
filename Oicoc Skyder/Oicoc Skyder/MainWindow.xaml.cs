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
using System.Windows.Threading;
using System.IO;
using System.Windows.Media.Animation;

namespace Oicoc_Skyder
{
    
    public partial class MainWindow : Window
    {

        int Score = 0;
        bool EnableClick = false;
        DispatcherTimer _timer;
        TimeSpan _time;
        string HighScore = Environment.CurrentDirectory + @"/ahjdv.pdf";
        string HighScore2 = Environment.CurrentDirectory + @"/fd13.pdf";
        string HighScore3 = Environment.CurrentDirectory + @"/images.pdf";
        int HighScoreInt;
        int Diff;
        

        public MainWindow(int diff)
        {
            InitializeComponent();
            SetStartPosition();
            this.Top = 120;
            this.Left = 260;
            if (diff == 1)
            {
                Target.Width = 90;
                Target.Height = 90;
                Diff = 1;
                DifficultyText.Text = "Nemt";
                Console.WriteLine("Nemt");
            }
            if (diff == 2)
            {
                Target.Width = 55;
                Target.Height = 55;
                Diff = 2;
                DifficultyText.Text = "Lidt svær";
                Console.WriteLine("Medium");
            }
            if (diff == 3)
            {
                Target.Width = 40;
                Target.Height = 40;
                Diff = 3;
                DifficultyText.Text = "Faktisk svært";
                Console.WriteLine("Svær");
            }
            CreateFiles();
            Read();
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        private void CreateFiles()
        {
            if (File.Exists(HighScore))
            {

            }
            else
            {
                using (FileStream fs = File.Create(HighScore))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("0");
                    fs.Write(info, 0, info.Length);
                }
            }
            if (File.Exists(HighScore2))
            {

            }
            else
            {
                using (FileStream fs = File.Create(HighScore2))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("0");
                    fs.Write(info, 0, info.Length);
                }
            }
            if (File.Exists(HighScore3))
            {

            }
            else
            {
                using (FileStream fs = File.Create(HighScore3))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("0");
                    fs.Write(info, 0, info.Length);
                }
            }
        }
        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                OpenMenu();
        }
        private void StopTimer()
        {
            
            _time = TimeSpan.FromSeconds(59);
            Score = 0;
            ScoreCount.Content = Score;
            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                tbTime.Text = _time.ToString("ss");
                if (_time == TimeSpan.FromSeconds(59)) EnableClick = true;
                if (_time == TimeSpan.Zero) _timer.Stop();
                if (_time == TimeSpan.Zero) EnableClick = false;
                if (_time == TimeSpan.Zero) SetStartPosition();
                if (HighScoreInt < Score)
                {
                if (_time == TimeSpan.Zero && Diff == 1) File.WriteAllText(HighScore, Score.ToString());
                    else if (_time == TimeSpan.Zero && Diff == 2) File.WriteAllText(HighScore2, Score.ToString());
                    if (_time == TimeSpan.Zero && Diff == 3) File.WriteAllText(HighScore3, Score.ToString());
                }
                if (_time == TimeSpan.Zero) Read();
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);
            
            _timer.Start();
        }
        private void SetStartPosition()
        {
            Canvas.SetTop(Target, 121);
            Canvas.SetLeft(Target, 409);
            
            Target.Source = new BitmapImage(new Uri(@"pack://application:,,,/Oicoc Skyder;component/Oicoc_logo.png"));
        }

        private void RectangleMouseEnter(object sender, MouseEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Released && EnableClick == true)
            {
                Random random = new Random();
                int SetTopRnd = random.Next(41, 225);
                int SetLeftRnd = random.Next(62, 810);
                Canvas.SetTop(Target, SetTopRnd);
                Console.WriteLine("top"+SetTopRnd);
                Canvas.SetLeft(Target, SetLeftRnd);
                Console.WriteLine("Left"+ SetLeftRnd);
                Target.Source = new BitmapImage(new Uri(@"pack://application:,,,/Oicoc Skyder;component/OicocOne.png"));
                Score += 2;
                ScoreCount.Content = Score;
            }
        }
       
        void Read()
        {
            if (Diff == 1)
            {
            int.TryParse(File.ReadAllText(HighScore), out HighScoreInt);
            HighScoreLabel.Content = "HighScore: " + HighScoreInt;
            }
            else if (Diff ==2)
            {
            int.TryParse(File.ReadAllText(HighScore2), out HighScoreInt);
            HighScoreLabel.Content = "HighScore: " + HighScoreInt;
            }
            else if (Diff == 3)
            {
            int.TryParse(File.ReadAllText(HighScore3), out HighScoreInt);
            HighScoreLabel.Content = "HighScore: " + HighScoreInt;
            }
            else
            {
                HighScoreLabel.Content = "Kan ikke finde HighScore";
            }
        }
        

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            OpenMenu();
        }

        private void OpenMenu()
        {
            Menu db = new Menu();
            db.Show();
            this.Close();
        }

        private void StartTimer_Click(object sender, RoutedEventArgs e)
        {
            StopTimer();
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Released && EnableClick == true)
            {
                Score--;
                if (Score<0)
                {
                    Score++;
                }
                ScoreCount.Content = Score;
            }
        }

        private void MouseMoveHandler(object sender, MouseEventArgs e)
        {
            // Get the x and y coordinates of the mouse pointer.
            System.Windows.Point position = e.GetPosition(this);
            double pX = position.X;
            double pY = position.Y;
            //if (pX > 750)
            //{
            //    pX = pX - 50;
            //}
            if (pY < 35 && pX < 320 && pX > 100)
            {
                pX = pX + 400;
            }
            pY = pY/6;
            DoubleAnimation da = new DoubleAnimation();
            //da.From = pX - 50;
            da.To = pX/6;
            da.Duration = new Duration(TimeSpan.FromSeconds(0));
            RotateTransform rt = new RotateTransform();
            Weapon.RenderTransform = rt;
            rt.BeginAnimation(RotateTransform.AngleProperty, da);
        }
    }
}
