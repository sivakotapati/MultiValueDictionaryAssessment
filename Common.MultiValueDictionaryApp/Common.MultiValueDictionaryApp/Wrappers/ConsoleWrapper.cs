using Common.MultiValueDictionaryApp.Exceptions;
using Common.MultiValueDictionaryApp.Interfaces;
using Common.MultiValueDictionaryApp.Constants;

namespace Common.MultiValueDictionaryApp.Wrappers
{
    public static class ConsoleWrapper
    {
        public static bool ValidateInput(string operation, object key, object value)
        {
            var isValid = false;
            switch (operation)
            {
                case Operations.Keys:
                case Operations.Clear:
                case Operations.AllMembers:
                case Operations.Items:
                case Operations.Stop:
                    isValid = true;
                    break;
                case Operations.Members:
                case Operations.RemoveAll:
                case Operations.KeyExists:
                    if (key != null)
                    {
                        isValid = true;
                    }
                    break;
                case Operations.Add:
                case Operations.Remove:
                case Operations.MemberExists:
                    if (key != null && value != null)
                    {
                        isValid = true;
                    }
                    break;
            }
            return isValid;
        }

        public static void Items<TKey, TValue>(IMultiValueDictionary<TKey, TValue> dict)
        {
            var items = dict.Items();
            if (items == null)
            {
                return;
            }
            foreach (var item in items)
            {
                ShowSuccessMessage(item.Key + ": " + item.Value);
            }
        }

        public static void AllMembers<TKey, TValue>(IMultiValueDictionary<TKey, TValue> dict)
        {
            var members = dict.AllMembers();
            if (members == null)
            {
                return;
            }

            foreach (var member in members)
            {
                ShowSuccessMessage(member);
            }
        }

        public static void Remove<TKey, TValue>(IMultiValueDictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            try
            {
                dict.Remove(key, value);
                ShowSuccessMessage(UIMessages.Removed);
            }
            catch (KeyNotExistsException ex)
            {
                ShowErrorMessage(UIMessages.KeyNotExists);
            }
            catch (MemberNotExistsException ex)
            {
                ShowErrorMessage(UIMessages.MemberNotExists);
            }
            catch (Exception ex)
            {
                ShowErrorMessage(UIMessages.SomeErrorOccured);
            }
        }

        public static void RemoveAll<TKey, TValue>(IMultiValueDictionary<TKey, TValue> dict, TKey key)
        {
            try
            {
                dict.RemoveAll(key);
                ShowSuccessMessage(UIMessages.Removed);
            }
            catch (KeyNotExistsException ex)
            {
                ShowErrorMessage(UIMessages.KeyNotExists);
            }
            catch (Exception ex)
            {
                ShowErrorMessage(UIMessages.SomeErrorOccured);
            }
        }

        public static void GetKeys<TKey, TValue>(IMultiValueDictionary<TKey, TValue> dict)
        {
            foreach (var key in dict.Keys)
            {
                Console.WriteLine(key);
            }
        }
        public static void GetMembers<TKey, TValue>(IMultiValueDictionary<TKey, TValue> dict, TKey key)
        {
            try
            {
                foreach (var member in dict.Members(key))
                {
                    Console.WriteLine(member);
                }
            }
            catch (KeyNotExistsException ex)
            {
                ShowErrorMessage(UIMessages.KeyNotExists);
            }
            catch (Exception ex)
            {
                ShowErrorMessage(UIMessages.SomeErrorOccured);
            }
        }

        public static void Add<TKey, TValue>(IMultiValueDictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            try
            {
                dict.Add(key, value);
                ShowSuccessMessage(UIMessages.Added);
            }
            catch (MemberAlreadyExistsException ex)
            {
                ShowErrorMessage(UIMessages.MemberAlreadyExists);
            }
            catch (Exception e)
            {
                ShowErrorMessage(UIMessages.SomeErrorOccured);
            }
        }

        public static void ShowSuccessMessage(object message)
        {
            Console.WriteLine(message);
        }

        public static void ShowErrorMessage(string message)
        {
            Console.WriteLine("ERROR, " + message);
        }
    }

}
