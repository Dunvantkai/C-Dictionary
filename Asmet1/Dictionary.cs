using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asmet1
{
    internal class Dictionary
    {
        internal class MyDictionary
        {
            Dictionary<string, Node> DictionaryDs { get; set; }

            public MyDictionary()
            {
                DictionaryDs = new Dictionary<string, Node>();
            }
            private void Insert(string key, Node entry)
            {
                if (!DictionaryDs.ContainsKey(key))
                    DictionaryDs.Add(key, entry);
            }
            //ui caller
            public void AddOp(string word)
            {
                Node entry = new Node(word, word.Length);
                Insert(word, entry);
            }
            public bool DelOp(string word)
            {
                return DictionaryDs.Remove(word);
            }

            public Node Find(string word)
            {
                if (DictionaryDs.TryGetValue(word, out Node entry))
                {
                    return entry;
                }
                return null;
            }
            public IEnumerable<Node> GetAllEntries()
            {
                return DictionaryDs.Values;
            }
            public void ClearAllEntries()
            {
                DictionaryDs.Clear();
            }
        }
    }
}