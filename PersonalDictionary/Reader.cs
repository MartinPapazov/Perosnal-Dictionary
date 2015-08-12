namespace PersonalDictionary
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using System.IO;
   
    public class Reader : IReader
    {
        private const string filePath = "translationDatabase.txt";
        public string GetText()
        {
            var text = string.Empty;
            using (StreamReader reader = new StreamReader(filePath))
            {
                text = reader.ReadToEnd();
            }

            return text;
        }
       
    }
}
