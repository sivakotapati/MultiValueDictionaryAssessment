using Common.MultiValueDictionaryApp.Constants;
using Common.MultiValueDictionaryApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.MultiValueDictionaryApp.Implementations
{
    public static class MultiValueDictionaryFactory
    {
        public static InMemoryMultiValueDictionary<TKey,TValue> GetInstance<TKey,TValue>(MultiValueDictionaryType option)
        {
            InMemoryMultiValueDictionary<TKey, TValue> _dict;
            switch (option)
            {
                
                case MultiValueDictionaryType.InMemory:
                    _dict= new InMemoryMultiValueDictionary<TKey, TValue>();
                    break;
                default:
                    throw new UnSupportedDictionaryTypeException(UIMessages.MultiValueDictionaryTypeNotSupported + Environment.NewLine);
            }
            return _dict;
        }
    }
}
