using Common.MultiValueDictionaryApp.Constants;
using Common.MultiValueDictionaryApp.Exceptions;
using Common.MultiValueDictionaryApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.MultiValueDictionaryApp.Implementations
{
    public static class MultiValueDictionaryFactory
    {
        public static IMultiValueDictionary<TKey,TValue> GetInstance<TKey,TValue>(MultiValueDictionaryType option)
        {
            IMultiValueDictionary<TKey, TValue> _dict;
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
