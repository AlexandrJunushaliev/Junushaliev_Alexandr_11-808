using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace hashes
{
    public class ReadonlyBytes : IEnumerable<byte>
    {
        public ReadonlyBytes(params byte[] a)
        {
            if (a != null)
                this.a = a;
            else throw new ArgumentNullException();
            length = a.Length;
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= Length) throw new IndexOutOfRangeException();
                return a[index];
            }
        }

        readonly byte[] a;
        int length;
        public int Length { get { return length; } }

        public IEnumerator<byte> GetEnumerator()
        {
            for (var i = 0; i < a.Length; i++)
            {
                yield return a[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ReadonlyBytes)) return false;
            var byteArray = obj as ReadonlyBytes;
            var i = 0;
            if (a.Length != byteArray.Length) return false;
            foreach (var _byte in byteArray)
            {
                if (_byte != a[i]) return false;
                i++;
            }
            return true;
        }

        public static class FNVConstants
        {
            public static readonly int OffsetBasis = unchecked((int)2166136261);
            public static readonly int Prime = 16777619;
        }

        public override int GetHashCode()
        {
            int hash = FNVConstants.OffsetBasis;
            if (a.Length > 2)
            {
                unchecked
                {
                    hash += (hash ^ a[0].GetHashCode()) * FNVConstants.Prime;
                    hash += (hash ^ a[a.Length / 2].GetHashCode()) * FNVConstants.Prime;
                    hash += (hash ^ a[Length - 1].GetHashCode()) * FNVConstants.Prime;
                }
                
            }
            else
            {
                unchecked
                {
                    foreach (var elem in a)
                    {
                        hash += (hash ^ elem.GetHashCode()) * FNVConstants.Prime;
                    }
                }
                
            }
            return hash;
        }

        public override string ToString()
        {
            var s = new StringBuilder("[");
            foreach (var _byte in a)
            {
                s.Append(_byte.ToString() + ", ");
            }
            if (s.Length > 2)
            { s.Remove(s.Length - 2, 2); }
            s.Append("]");
            return s.ToString();
        }
    }
}