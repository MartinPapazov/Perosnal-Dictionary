namespace PersonalDictionary
{
    using Contracts;
    using System.IO;

    public class Writer : IWriter
    {
        private const string filePath = "translationDatabase.txt";
        public void Write(ITranslationObject translationObject)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath, true))
            {
                streamWriter.Write(translationObject.ToString());
            }
        }
    }
}
