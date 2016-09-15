using System;
using System.Windows.Forms;
using System.Windows.Threading;

namespace WpfApplication5
{
    public class Project
    {
        public bool IsRunning = false;

        public bool IsPrivate;

        DispatcherTimer myDispatcherTimer = new DispatcherTimer();

        public Project(bool isPrivate = false)
        {
            IsPrivate = isPrivate;

            myDispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000); // 1000 Milliseconds 
            myDispatcherTimer.Tick += new EventHandler(Each_Tick);
        }

        Timer stopwatch = new Timer();

        public TimeSpan Time { get; set; }

        public string ProjectName { get; set; }

        public string Element { get; set; }

        public string MyMonday { get; set; }

        public string MyTuesday { get; set; }

        public string MyWednesday { get; set; }

        public string MyThursday { get; set; }

        public string MyFriday { get; set; }

        public string MySaturday { get; set; }

        public string MySunday { get; set; }

        public event EventHandler TimeChanged;

        public void OnTimeChanged(EventArgs e)
        {
            TimeChanged?.Invoke(this, e);
        }

        //foreach(var project in Projects.Where(p => !p.IsPrivate))
        //{
        //}

        public void Start()
        {
            if (!IsRunning)
            {
                IsRunning = true;
                myDispatcherTimer.Start();
            }
        }
        private int i = 0;

        private void Each_Tick(object sender, EventArgs e)
        {
            i++.ToString();
            var tijd = WpfApplication5.Time.ConvertTime(i);
            OnTimeChanged(e);
            Case(tijd.ToString());
        }

        public void Stop()
        {
           myDispatcherTimer.Stop();
           IsRunning = false;
        }

        private void Case(string K)
        {
            int d = (int)DateTime.Now.DayOfWeek;

            switch (d)
            {
                case 1:
                    MyMonday = K.ToString();
                    break;
                case 2:
                    MyTuesday= K.ToString();
                    break;
                case 3:
                    MyWednesday = K.ToString();
                    break;
                case 4:
                    MyThursday = K.ToString();
                    break;
                case 5:
                    MyFriday = K.ToString();
                    break;
                case 6:
                    MySaturday = K.ToString();
                    break;
                case 7:
                    MySunday = K.ToString();
                    break;
                default:
                     MyMonday = K.ToString();
                    break;
            }
        }
    }
}