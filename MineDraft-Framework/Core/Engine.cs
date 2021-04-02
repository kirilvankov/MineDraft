using Minedraft.Core.Contracts;
using Minedraft.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minedraft.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private DraftManager draftManager;
        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.draftManager = new DraftManager();
        }
        public void Run()
        {
            string[] input;
            while (true)
            {
                input = reader.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string cmdType = input[0];
                if (cmdType == "RegisterHarvester")
                {
                    writer.WriteLine(this.draftManager.RegisterHarvester(input.Skip(1).ToList()));
                }
                else if (cmdType == "RegisterProvider")
                {
                    writer.WriteLine(this.draftManager.RegisterProvider(input.Skip(1).ToList()));
                }
                else if (cmdType == "Day")
                {
                    writer.WriteLine(this.draftManager.Day());
                }
                else if (cmdType == "Mode")
                {
                    writer.WriteLine(this.draftManager.Mode(input.Skip(1).ToList()));
                }
                else if (cmdType == "Check")
                {
                    writer.WriteLine(this.draftManager.Check(input.Skip(1).ToList()));
                }
                else if (cmdType == "Shutdown")
                {
                    writer.WriteLine(this.draftManager.ShutDown());
                    break;
                }
            }
        }
    }
}
