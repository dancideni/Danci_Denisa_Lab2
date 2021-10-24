using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Threading;

namespace Danci_Denisa_Lab2
{
    class DoughnutMachine
    {
        public DoughnutType Flavor { get; set; }

        public delegate void DoughnutCompleteDelegate();
        public event DoughnutCompleteDelegate DoughnutComplete;
        DispatcherTimer doughnutTimer;

        private void InitializeComponent()
        {
            this.doughnutTimer = new DispatcherTimer();
            this.doughnutTimer.Tick += new System.EventHandler(this.doughnutTimer_Tick);
        }

        public DoughnutMachine()
        {
            InitializeComponent();
        }
        private void doughnutTimer_Tick(object sender, EventArgs e)
        {
            Doughnut aDoughnut = new Doughnut(this.Flavor);
            DoughnutComplete();
        }

        public bool Enabled
        {
            set
            {
                doughnutTimer.IsEnabled = value;
            }
        }
        public int Interval
        {
            set
            {
                doughnutTimer.Interval = new TimeSpan(0, 0, value);
            }
        }

        public void MakeDoughnuts(DoughnutType dFlavor)
        {

            Flavor = dFlavor;
            switch (Flavor)
            {
                case DoughnutType.Glazed: Interval = 3; break;
                case DoughnutType.Sugar: Interval = 2; break;
                case DoughnutType.Lemon: Interval = 5; break;
                case DoughnutType.Chocolate: Interval = 7; break;
                case DoughnutType.Vanilla: Interval = 4; break;
            }
            doughnutTimer.Start();
        }

    }
    public enum DoughnutType
    {
        Glazed,
        Sugar,
        Lemon,
        Chocolate,
        Vanilla
    }
    class Doughnut
    {
        public DoughnutType Flavor { get; set; }
        public DateTime TimeOfCreation { get; }
        public Doughnut(DoughnutType aFlavor) // constructor
        {
            TimeOfCreation = DateTime.Now;
            Flavor = aFlavor;
        }

    }

}
