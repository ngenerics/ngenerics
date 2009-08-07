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
