using Common.MultiValueDictionaryApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.MultiValueDictionaryApp.Implementations
{    
    public class DbMultiValueDictionary<TKey, TValue> : IMultiValueDictionary<TKey, TValue>
    {
        public ICollection<TKey> Keys => throw new NotImplementedException();

        public bool Add(TKey key, TValue value)
        {
            throw new NotImplementedException();
        }

        public ICollection<TValue> AllMembers()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public List<KeyValuePair<TKey, TValue>> Items()
        {
            throw new NotImplementedException();
        }

        public bool KeyExists(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool MemberExists(TKey key, TValue value)
        {
            throw new NotImplementedException();
        }

        public ICollection<TValue> Members(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(TKey key, TValue value)
        {
            throw new NotImplementedException();
        }

        public bool RemoveAll(TKey key)
        {
            throw new NotImplementedException();
        }
    }
}
