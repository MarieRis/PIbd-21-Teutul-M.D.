using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr5_katamaran
{
    class ClassArray<T> where T : ITransport
    {
        private Dictionary<int, T> places;
        private int maxCount;

        private T defaultValue;

        public ClassArray(int size, T defVal)
        {
            defaultValue = defVal;
            places = new Dictionary<int, T>();
            maxCount = size;
        }


        public static int operator +(ClassArray<T> t, T Tarantul)
        {
            if (t.places.Count == t.maxCount)
            {
                return -1;
            }
            for (int i = 0; i < t.places.Count; i++)
            {
                if (t.CheckFreeTerra(i))
                {
                    t.places.Add(i, Tarantul);
                    return i;
                }
            }
            t.places.Add(t.places.Count, Tarantul);
            return t.places.Count - 1;
        }
        public static T operator -(ClassArray<T> t, int index)
        {
            if (t.places.ContainsKey(index))
            {
                T Katamaran = t.places[index];
                t.places.Remove(index);
                return Katamaran;
            }
            return t.defaultValue;
        }
        private bool CheckFreeTerra(int index)
        {
            return !places.ContainsKey(index);
        }
        public T this[int ind]
        {
            get
            {
                if (places.ContainsKey(ind))
                {
                    return places[ind];
                }
                return defaultValue;
            }
        }
    }
}
