namespace PersonalDictionary
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using System.IO;
   
    class Reader : IReader
    {
        private const string filePath = "translationDatabase.txt";
        public IList<ITranslationObject> Words()
        {
            var words = new List<ITranslationObject>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                    string text = reader.ReadToEnd();
                    string[] splitToWords = text.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var word in splitToWords)
                    {
                        var tansObj = GetTranslationObjects(word);
                        words.Add(tansObj);
                    }
                    
            }

            return words;
        }
        private ITranslationObject GetTranslationObjects(string text)
        {
            string[] elements = text.Split(new char[]{'$'}, StringSplitOptions.RemoveEmptyEntries);
            string word = elements[0];
            string translation = elements[1];
            return new TranslationObject(word, translation);
        }
    }
}
