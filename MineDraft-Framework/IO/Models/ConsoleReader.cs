using Minedraft.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minedraft.IO.Models
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
