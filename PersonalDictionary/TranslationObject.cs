namespace PersonalDictionary
{
    using Contracts;
    using System;

    class TranslationObject : ITranslationObject
    {
        private string word;
        private string translation;
        public TranslationObject(string word, string translation, bool status)
        {
            this.Word = word;
            this.Translation = translation;
            this.Status = status;
        }
        public string Word
        {
            get { return word; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Word", "Cannot be null");
                }

                this.word = value;
            }
        }

        public string Translation
        {
            get { return this.translation; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("translation", "Cannot be null");
                }

                this.translation = value;
            }
        }


        public bool Status { get; set; }

        public void AddNewTranslation(string translation, bool removeOldTranslation)
        {
            if (removeOldTranslation)
            {
                this.Translation = translation;
            }
            else
            {
                this.Translation += ",\n" + translation;
            }
        }

        public bool Equals(ITranslationObject other)
        {
            bool areEqual = this.Word.Equals(other.Word, StringComparison.CurrentCultureIgnoreCase);
            return areEqual;
        }

        public override string ToString()
        {
            string text = string.Format("{0}${1}${2};", this.word, this.translation, this.Status.ToString());
            return text;
        }
    }
}
