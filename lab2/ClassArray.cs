using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr3_katamaran
{
    class ClassArray<T> where T : ITransport
    {

        private T[] place;
        private T defaultValue;

        public ClassArray(int sizes, T defVal)
        {
            defaultValue = defVal;
            place = new T[sizes];
            for (int i = 0; i < place.Length; i++)
            {
                place[i] = defaultValue;
            }
        }

        public T getObject(int ind)
        {
            if (ind > -1 && ind < place.Length)
            {
                return place[ind];
            }
            return defaultValue;
        }
        public static int operator +(ClassArray<T> t, T Katamaran)
        {
            for (int i = 0; i < t.place.Length; i++)
            {
                if (t.CheckFreeTerra(i))
                {
                    t.place[i] = Katamaran;
                    return i;
                }
            }
            return -1;
        }
        public static T operator -(ClassArray<T> t, int index)
        {
            if (!t.CheckFreeTerra(index))
            {
                T Tarantul = t.place[index];
                t.place[index] = t.defaultValue;
                return Tarantul;

            }
            return t.defaultValue;
        }
        private bool CheckFreeTerra(int index)
        {
            if (index < 0 || index > place.Length)
            {
                return false;
            }
            if (place[index] == null)
            {
                return true;
            }
            if (place[index].Equals(defaultValue))
            {
                return true;
            }
            return false;
        }
    }
}
