/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html. 
*/

using System;
using ProjectSynchronizer.Core.Parsing;

namespace ProjectSynchronizer {
    class Program {
        
        static int Main(string[] args) {

            try {
                if (args.Length < 2) {
                    ShowUsage();
                } else {
                    Synchronize(args[0], args[1]);
                    Console.WriteLine("Done.");
                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught : " + ex);
                return -1;
            }

            return 0;
        }
        

        private static void Synchronize(string from, string to)
        {
            var synchronizer = new VS2008Synchronizer();
            synchronizer.Synchronize(from, to);
        } 

        private static void ShowUsage() {
            Console.WriteLine("ProjectSynchronizer [fromProject] [toProject]");
            Console.WriteLine();
        }
    }
}
