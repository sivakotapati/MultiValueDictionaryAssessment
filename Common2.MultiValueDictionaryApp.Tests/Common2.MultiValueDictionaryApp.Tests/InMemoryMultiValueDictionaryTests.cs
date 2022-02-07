using Common.MultiValueDictionaryApp.Exceptions;
using Common.MultiValueDictionaryApp.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common2.MultiValueDictionaryApp.Tests
{
    [TestClass]
    public class InMemoryMultiValueDictionaryTests
    {
        InMemoryMultiValueDictionary<string, string> _dict =
            new InMemoryMultiValueDictionary<string, string>();
        public InMemoryMultiValueDictionaryTests()
        {

        }

        [TestMethod]
        public void Keys_ShouldReturnEmptyCollection_WhenDictionaryIsEmpty()
        {
            var result = _dict.Keys;
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void Keys_ShouldReturnAllKeys_WhenDictionaryIsNotEmpty()
        {
            _dict.Add("foo", "bar");
            _dict.Add("baz", "bang");
            var result = _dict.Keys;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result.Contains("foo"));
            Assert.IsTrue(result.Contains("baz"));
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotExistsException), ExceptionMessages.KeyNotExists)]
        public void Members_ShouldThrowException_WhenKeyNotExists()
        {
            _dict.Members("bad");
        }

        [TestMethod]
        public void Members_ShouldReturnAllMembersOfKey_WhenKeyExists()
        {
            _dict.Add("foo", "bar");
            _dict.Add("foo", "baz");
            var result = _dict.Members("foo");
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Contains("bar"));
            Assert.IsTrue(result.Contains("baz"));
        }

        [TestMethod]
        [ExpectedException(typeof(MemberAlreadyExistsException), ExceptionMessages.MemberAlreayExists)]
        public void Add_ShouldThrowException_WhenMemberAlreadyExists()
        {
            _dict.Add("foo", "bar");
            var result = _dict.Add("foo", "bar");
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Add_ShouldSucessfullyAdd_WhenMeberNotExists()
        {
            bool result = _dict.Add("foo", "bar");
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotExistsException), ExceptionMessages.KeyNotExists)]
        public void Remove_ShouldThrowException_WhenKeyNotExists()
        {
            _dict.Add("foo", "bar");
            _dict.Add("foo", "baz");
            _dict.Remove("foo", "bar");
            _dict.Remove("foo", "baz");
            _dict.Remove("foo", "bar");
        }


        [TestMethod]
        [ExpectedException(typeof(MemberNotExistsException), ExceptionMessages.MemberNotExists)]
        public void Remove_ShouldThrowException_WhenMemberNotExists()
        {
            _dict.Add("foo", "bar");
            _dict.Add("foo", "baz");
            _dict.Remove("foo", "bar");
            _dict.Remove("foo", "bar");
        }

        [TestMethod]
        public void Remove_ShouldSuccessfullyRemoveMember_WhenMemberExist()
        {
            _dict.Add("foo", "bar");
            _dict.Add("foo", "baz");
            _dict.Remove("foo", "bar");
            var memmebrs = _dict.Members("foo");
            Assert.IsNotNull(memmebrs);
            Assert.AreEqual(1, memmebrs.Count);
            Assert.IsFalse(memmebrs.Contains("bar"));
        }

        [TestMethod]
        public void Remove_ShouldRemoveKey_WhenLastMemberIsRemoved()
        {
            _dict.Add("foo", "bar");
            _dict.Add("foo", "baz");
            _dict.Remove("foo", "bar");
            _dict.Remove("foo", "baz");
            bool result = _dict.KeyExists("foo");
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotExistsException), ExceptionMessages.KeyNotExists)]
        public void RemoveAll_ShouldThrowException_WhenKeyNotExists()
        {
            _dict.RemoveAll("foo");
        }

        [TestMethod]
        public void RemoveAll_ShouldRemoveKeyAndAllMebersOfKey_WhenKeyExists()
        {
            _dict.Add("foo", "bar");
            _dict.Add("foo", "baz");
            _dict.RemoveAll("foo");
            bool result = _dict.KeyExists("foo");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Clear_ShouldRemoveAllKeys()
        {
            _dict.Add("foo", "bar");
            _dict.Add("foo", "baz");
            _dict.Add("bang", "zip");
            _dict.Clear();
            var keys = _dict.Keys;
            Assert.IsNotNull(keys);
            Assert.IsTrue(keys.Count == 0);
        }

        [TestMethod]
        public void KeyExists_ShouldReturnFalse_WhenKeyNotExists()
        {
            _dict.Add("foo", "bar");
            bool result = _dict.KeyExists("bang");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void KeyExists_ShouldReturnTrue_WhenKeyExists()
        {
            _dict.Add("foo", "bar");
            bool result = _dict.KeyExists("foo");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MemberExists_ShouldReturnFalse_WhenMemberNotExists()
        {
            _dict.Add("foo", "bar");
            bool result = _dict.MemberExists("foo", "biz");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MemberExists_ShouldReturnTrue_WhenMemberExists()
        {
            _dict.Add("foo", "bar");
            bool result = _dict.MemberExists("foo", "bar");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AllMembers_ShouldReturnNull_WhenNoMemberExists()
        {
            ICollection<string> result = _dict.AllMembers();
            Assert.IsNull(result);
        }

        [TestMethod]
        public void AllMembers_ShouldReturnAllMembers_WhenMembersExists()
        {
            _dict.Add("foo", "bar");
            _dict.Add("foo", "baz");
            _dict.Add("bang", "aaa");
            _dict.Add("bang", "bbb");
            ICollection<string> result = _dict.AllMembers();

            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count);
            Assert.IsTrue(result.Contains("bar"));
            Assert.IsTrue(result.Contains("baz"));
            Assert.IsTrue(result.Contains("aaa"));
            Assert.IsTrue(result.Contains("bbb"));
        }

        [TestMethod]
        public void Items_ShuouldReturnNull_WhenNoItemsExists()
        {
            List<KeyValuePair<string, string>>? result = _dict.Items();
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Items_ShouldReturnAllKeysAndAllMembers_WhenItemsExists()
        {
            _dict.Add("foo", "bar");
            _dict.Add("foo", "baz");
            _dict.Add("bang", "bar");
            _dict.Add("bang", "baz");

            List<KeyValuePair<string, string>> result = _dict.Items();

            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count);
            Assert.IsTrue(result.Contains(new KeyValuePair<string, string>("foo", "bar")));
            Assert.IsTrue(result.Contains(new KeyValuePair<string, string>("foo", "baz")));
            Assert.IsTrue(result.Contains(new KeyValuePair<string, string>("bang", "bar")));
            Assert.IsTrue(result.Contains(new KeyValuePair<string, string>("bang", "baz")));
        }
    }

}
