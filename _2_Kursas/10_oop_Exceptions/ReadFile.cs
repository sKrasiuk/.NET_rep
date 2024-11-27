namespace _10_oop_Exceptions
{
    public static class ReadFile
    {
        private static string path = "someFile.txt";

        public static void ReadF()
        {
            try
            {
                File.ReadAllText(path);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found: " + e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("No access: " + e.Message);
            }
            catch (PathTooLongException e)
            {
                Console.WriteLine("Path or filename is too long: " + e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine("File in use by another application or process: " + e.Message);
            }
        }
    }
}
