using System;
using System.Linq;
using LibGit2Sharp;

namespace prune
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Deleting test branch...");
            DeleteLocalBranch("test");
        }

        static void DeleteLocalBranch(string branchName)
        {
            using var repo = new Repository(Environment.CurrentDirectory);
            var branch = repo.Branches.FirstOrDefault(b => b.FriendlyName == branchName);
            repo.Branches.Remove(branch);
        }
    }
}