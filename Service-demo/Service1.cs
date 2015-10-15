using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Service_demo
{
    public partial class Service1 : ServiceBase
    {
        private StreamWriter _writer;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _writer = File.CreateText("service log.txt");
            WriteLine("Started at: " + DateTime.Now);
        }

        protected override void OnStop()
        {
            WriteLine("Stopped at: " + DateTime.Now);
            _writer.Close();
        }

        //async void WriteLine(string text)
        //{
        //    await _writer.WriteLineAsync(text);
        //}

        void WriteLine(string text)
        {
            _writer.WriteLine(text);
        }

        // To test the service as a console app
        internal void TestStartupAndStop(string[] args)
        {
            this.OnStart(args);
            Console.ReadLine();
            this.OnStop();
        }
    }
}
