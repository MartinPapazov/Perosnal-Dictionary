namespace PersonalDictionary
{
    using Contracts;
    using System.Collections.Generic;
    using System.IO;

    public class Writer : IWriter
    {
        private const string filePath = "translationDatabase.txt";
        public void Write(IList<ITranslationObject> translationObjects)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath, false))
            {
                foreach (var translationObject in translationObjects)
                {
                    streamWriter.Write(translationObject.ToString());
                }
            }
        }
    }
}
