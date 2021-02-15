using System;
using System.Collections.Generic;
using System.IO;

namespace Dicts
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> candidates = new Dictionary<string, int>();

            Console.Write("Enter file full path: ");
            string path = Console.ReadLine();

            try
            {
                using StreamReader sr = File.OpenText(path);
                while (!sr.EndOfStream)
                {
                    string[] votingRecord = sr.ReadLine().Split(',');
                    string name = votingRecord[0];
                    int votes = int.Parse(votingRecord[1]);

                    if (candidates.ContainsKey(name))
                    {
                        candidates[name] += votes;
                    }
                    else
                    {
                        candidates[name] = votes;
                    }
                }
            }
            catch(IOException e)
            {
                Console.WriteLine("An error occured");
                Console.WriteLine(e.Message);
            }

            foreach(KeyValuePair<string, int> candidate in candidates)
            {
                Console.WriteLine($"{candidate.Key}: {candidate.Value}");
            }
        }
    }
}
