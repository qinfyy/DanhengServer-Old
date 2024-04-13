using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Util
{
    /// <summary>
    /// A list that can be used to randomly select an element with a certain weight from it.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RandomList<T> : List<T>
    {
        private readonly List<T> _List = [];

        public RandomList()
        {
        }

        public RandomList(IEnumerable<T> collection)
        {
            AddRange(collection);
        }

        public void Add(T item, int weight)
        {
            for (int i = 0; i < weight; i++)
            {
                _List.Add(item);
            }
        }

        public void AddRange(IEnumerable<T> collection, IEnumerable<int> weights)
        {
            var list = collection.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                Add(list[i], weights.ElementAt(i));
            }
        }

        public T? GetRandom()
        {
            if (_List.Count == 0)
            {
                return default;
            }
            return _List[Random.Shared.Next(_List.Count)];
        }
    }
}
