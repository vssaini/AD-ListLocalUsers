using System;
using System.DirectoryServices;
using System.Linq;

namespace ListLocalUsers
{
    class Program
    {
        static void Main()
        {
            ListUser();

            Console.ReadKey();
        }

        private static void ListUser()
        {
           var winNtPath = string.Format("WinNT://{0}", "W2K8SRV1");

            using (var computerEntry = new DirectoryEntry(winNtPath,"Administrator","Pass99"))
            {
                var userNames = from DirectoryEntry childEntry in computerEntry.Children
                                where childEntry.SchemaClassName == "Group"
                                select childEntry.Name;

                foreach (var name in userNames)
                    Console.WriteLine(name);
            }      
        }
    }
}
