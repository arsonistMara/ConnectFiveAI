using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFiveAI {
    class Start {
        static void Main(string[] args) {
            try {
                Solution game = new Solution(args[0], args[1] == "X" ? 1 : 2, Convert.ToInt32(args[2]));
            }
            catch(Exception e) {
                File.WriteAllLines("Exception.txt", new string[] { e.Message, e.StackTrace });
                throw;
            }
        }
    }
}
