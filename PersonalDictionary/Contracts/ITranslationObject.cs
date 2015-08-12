using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDictionary.Contracts
{
    public interface ITranslationObject
    {
        string Word { get; }

        string Translation { get; }

        bool Status { get; set; }
    }
}
