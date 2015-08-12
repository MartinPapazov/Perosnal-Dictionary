namespace PersonalDictionary.Factory
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    public class TranslationObjectsFactory : ITranslationObjectsFactory
    {
        private IReader reader;
        private IWriter writer;
        private static TranslationObjectsFactory instance;

        protected TranslationObjectsFactory()
        {
            this.reader = new Reader();
            this.writer = new Writer();
        }

        public static TranslationObjectsFactory GetFactoryInstance()
        {
            if (instance == null)
            {
                instance = new TranslationObjectsFactory();
            }

            return instance;
        }

        /// <summary>
        /// Get text from the Reader. Make the text to TranslationObjects and add them to List.
        /// </summary>
        /// <returns>IList<ITranslationObject></returns>
        public IList<ITranslationObject> GetData()
        {
            
            string text = this.reader.GetText();
            string[] splitToWords = text.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            var translationObjectCollection = new List<ITranslationObject>();
            foreach (var word in splitToWords)
            {
                try
                {
                    var tansObj = GetTranslationObjects(word);
                    translationObjectCollection.Add(tansObj);
                }
                catch (ArgumentException ex)
                {
                    //TODO: Log error
                }
               
            }

            return translationObjectCollection;
        }

        public void AddNewData(ITranslationObject translationObject)
        {

            var translationCollection = this.GetData();
            if (translationCollection.Contains(translationObject))
            {
                int indexOfObject = translationCollection.IndexOf(translationObject);
                string translation = translationObject.Translation;
                translationCollection[indexOfObject].AddNewTranslation(translation, false);
            }
            else
            {
                translationCollection.Add(translationObject);
            }
            
            this.writer.Write(translationCollection);
        }

        private ITranslationObject GetTranslationObjects(string text)
        {
            string[] elements = text.Split(new char[] { '$' }, StringSplitOptions.RemoveEmptyEntries);
            if (elements.Length < 3)
            {
                throw new ArgumentException("Elements from text have to be full(Word, Translation, Status).");
            }

            string word = elements[0];
            string translation = elements[1];
            bool status = Boolean.Parse(elements[2]);
            return new TranslationObject(word, translation, status);
        }
    }
}
