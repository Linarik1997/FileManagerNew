using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerL.Core.cmnd
{
    public class OrCommandLinePattern: CommandLinePattern
    {
        private readonly CommandLinePattern left;
        private readonly CommandLinePattern right;

        public OrCommandLinePattern(CommandLinePattern left, CommandLinePattern right)
        {
            this.left = left;
            this.right = right;
        }

        public override bool TryParse(string[] args, out ICommand result)
        {
            if (left.TryParse(args, out result))
                return true;

            return right.TryParse(args, out result);
        }
    }
}
