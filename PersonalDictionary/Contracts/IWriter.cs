using System.Collections.Generic;
namespace PersonalDictionary.Contracts
{
    public interface IWriter
    {
        void Write(IList<ITranslationObject> translationObjects);
    }
}
