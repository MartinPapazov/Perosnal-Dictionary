namespace PersonalDictionary.Contracts
{
    using System.Collections.Generic;
    public interface ITranslationObjectsFactory
    {
        IList<ITranslationObject> GetData();

        void AddNewData(ITranslationObject translationObject);
        
    }
}
