
namespace ConsoleApp1.DataAccessLayer
{
    class KeyPhrasesParser
    {

        private Dictionary<string, string> _keyPhrases = new();

        public KeyPhrasesParser() 
        {
            string fileName = ChoiceOfFile();
            IEnumerable<string> keyPhrasesString = File.ReadLines(Path.Combine(Environment.CurrentDirectory, @"..\..\..\Data\", fileName));
            foreach (string keyPhrase in keyPhrasesString) 
            {
                _keyPhrases.Add(keyPhrase.Split(":")[1], keyPhrase.Split(":")[2]);   
            }
        }
        /// <summary>
        /// Choice of program language
        /// </summary>
        /// <returns>Name of file with keyphrases</returns>
        static public string ChoiceOfFile()
        {
            Console.WriteLine("1 -- eng, 2 -- rus");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1) 
            {
                return "keyPhrases.txt";
            }
            else
            {
                return "keyPhrasesRUS.txt";
            }
        }
        public Dictionary<string, string> KeyPhrases { get { return _keyPhrases; } }
    }
}
