using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private IDisposable _subscription;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartRefreshingMemory();
        }

        private void refreshRate_ValueChanged(object sender, EventArgs e)
        {
            StartRefreshingMemory();
        }

        private void StartRefreshingMemory()
        {
            _subscription?.Dispose();
            _subscription = Observable.Interval(TimeSpan.FromSeconds((double)refreshRate.Value))
                                      .ObserveOn(Scheduler.Default)
                                      .Subscribe(_ => UpdateUsedMemory());
        }

        private void UpdateUsedMemory()
        {
            var totalMemory = new ComputerInfo().TotalPhysicalMemory;

            long memory = 0;
            Process[] processes;
            processes = Process.GetProcesses();

            foreach (var process in processes)
            {
                memory += process.PrivateMemorySize64;
            }

            Console.WriteLine("Bytes: {0}.", memory);
            Console.WriteLine("KiloBytes: {0}.", memory * 10e-4);
            Console.WriteLine("MegaBytes: {0}.", memory * 10e-7);
            Console.WriteLine("GigaBytes: {0}.", memory * 10e-10);

            var usedGb = memory*10e-10;
            var totalGb = totalMemory*10e-10;
            usedMemoryBar.Value = (int) (usedGb / totalGb * 100f);

            usedMemoryLabel.Text =
                string.Format("{0:0.##} / {1:0.##} GB", usedGb, totalGb);
        }
    }
}
