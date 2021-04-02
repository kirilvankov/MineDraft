using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Minedraft.Core;
using Minedraft.Core.Contracts;
using Minedraft.IO.Contracts;
using Minedraft.IO.Models;
namespace MineDraft
{
    public class Startup
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
