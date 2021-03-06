﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Runtime.InteropServices;
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

        private Icon[] _statusIcons = new Icon[10];

        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 10; i++)
            {
                _statusIcons[i] = Icon.ExtractAssociatedIcon(@"icons\"+(i * 10 + 10)+"p.ico");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartRefreshingMemory();
            notifyIcon1.Click += (o, args) =>
                                 {
                                     if (WindowState == FormWindowState.Minimized)
                                     {
                                         Show();
                                         WindowState = FormWindowState.Normal;
                                     }
                                 };
        }

        private void refreshRate_ValueChanged(object sender, EventArgs e)
        {
            StartRefreshingMemory();
        }

        private void StartRefreshingMemory()
        {
            _subscription?.Dispose();
            _subscription = Observable.Interval(TimeSpan.FromSeconds((double)refreshRate.Value))
                                      .ObserveOn(SynchronizationContext.Current)
                                      .Subscribe(_ => UpdateUsedMemory());
        }

        private void UpdateUsedMemory()
        {
            var totalMemory = new ComputerInfo().TotalPhysicalMemory;
            var freeMemory = new ComputerInfo().AvailablePhysicalMemory;
            var usedMemory = totalMemory - freeMemory;

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

            var usedGb = usedMemory*10e-10;
            var totalGb = totalMemory*10e-10;
            var usedPercent = (int)(usedGb / totalGb * 100f);

            usedMemoryBar.Value = usedPercent > 100 ? 100 : usedPercent;

            var usedMemoryText = string.Format("{0:0.##} / {1:0.##} GB", usedGb, totalGb);

            usedMemoryLabel.Text = usedMemoryText;

            notifyIcon1.Icon = _statusIcons[(int) Math.Ceiling(usedGb / totalGb * 10)];
            notifyIcon1.Text = usedMemoryText;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                Hide();
            }
        }
    }
}
