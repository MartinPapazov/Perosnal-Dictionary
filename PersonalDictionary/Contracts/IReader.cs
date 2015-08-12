using System.Collections.Generic;
namespace PersonalDictionary.Contracts
{
    
    public interface IReader
    {
        IList<ITranslationObject> Words();
    }
}
