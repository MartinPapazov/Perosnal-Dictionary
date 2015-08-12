namespace PersonalDictionary
{
    using Contracts;
    using System;

    class TranslationObject : ITranslationObject
    {
        private string word;
        private string translation;
        public TranslationObject(string word, string translation)
        {
            this.Word = word;
            this.Translation = translation;
            this.Status = false;
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

        public override string ToString()
        {
            string text = string.Format("{0}${1};", this.word, this.translation);
            return text;
        }
    }
}
