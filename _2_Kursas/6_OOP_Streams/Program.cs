string path = "C:\\DEV_\\GitHub\\.NET_rep\\_2_Kursas\\6_OOP_Streams\\Test2.txt";
string path2 = "C:\\DEV_\\GitHub\\.NET_rep\\_2_Kursas\\6_OOP_Streams\\Test3.txt";
string path3 = "C:\\DEV_\\GitHub\\.NET_rep\\_2_Kursas\\6_OOP_Streams\\Test.bin";

//string content = File.ReadAllText(path);
//Console.WriteLine(content);

//var someText = new List<string>
//{
//    {
//        """
//         In computer science, an algorithm is a finite sequence of well-defined instructions designed to perform a specific task.
//         Efficiency is often evaluated in terms of time complexity (speed) and space complexity (memory use).
//         Let me know if you want more!
//        """
//    }
//};

//File.WriteAllText(path, someText[0]);

//File.Copy(path, path2);

IEnumerable<string> strings = File.ReadLines(path);

foreach (var item in strings)
{
    //int numberOfSimbols = item.ToCharArray().Length;
    Console.WriteLine(item.ToCharArray().Length);
}

DirectoryInfo[] cDirs = new DirectoryInfo(@"c:\").GetDirectories();

using(var writer = new StreamWriter(path2))
{
    foreach (var dir in cDirs)
    {
        writer.WriteLine(dir.Name);
    }
}

using(var bWriter = new BinaryWriter(File.Open(path3, FileMode.OpenOrCreate)))
{
    bWriter.Write(10);
    bWriter.Write(3.14);
    bWriter.Write("Hello");
}
using (var bReader = new BinaryReader(File.Open(path3, FileMode.Open)))
{
    int number = bReader.ReadInt32();
    double value = bReader.ReadDouble();
    string text = bReader.ReadString();
}