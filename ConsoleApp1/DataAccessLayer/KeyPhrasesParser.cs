
namespace ConsoleApp1.DataAccessLayer
{
    /// <summary>
    /// Parser of txt with keyphrases for program.
    /// </summary>
    class KeyPhrasesParser
    {

        private readonly Dictionary<string, string> _keyPhrases = new();

        public KeyPhrasesParser() 
        {
            var fileName = ChoiceOfFile();
            IEnumerable<string> keyPhrasesString = File.ReadLines(Path.Combine(Environment.CurrentDirectory, @"..\..\..\Data\", fileName));
            foreach (string keyPhrase in keyPhrasesString) 
            {
                _keyPhrases.Add(keyPhrase.Split("::")[0], keyPhrase.Split("::")[1]);   
            }
        }
        /// <summary>
        /// Choice of program language.
        /// </summary>
        /// <returns>Name of file with keyphrases</returns>
        public static string ChoiceOfFile()
        {
            Console.WriteLine("1 -- eng, 2 -- rus");
            var choice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            return choice == 1 ? "KeyPhrases.txt" : "KeyPhrasesRUS.txt";
        }
        public Dictionary<string, string> KeyPhrases => _keyPhrases;
    }
}
