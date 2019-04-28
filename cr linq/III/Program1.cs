using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_III
{
    class A
    {
        public int userCode;
        public int birthYear;
        public string homeAdress;
        public A(string homeAdress, int birthYear, int userCode)
        {
            this.homeAdress = homeAdress;
            this.userCode = userCode;
            this.birthYear = birthYear;
            
        }
    }
    class B
    {
        public string article;
        public string category;
        public string homeCountry;
        public B(string article, string category, string homeCountry)
        {
            this.article = article;
            this.category = category;
            this.homeCountry = homeCountry;
        }
    }
    class C
    {
        public int userCode;
        public string storeName;
        public int discount;
        public C(int userCode, int discount , string storeName)
        {
            this.userCode = userCode;
            this.storeName = storeName;
            this.discount = discount;
        }
    }
    class D
    {
        public string article;
        public string storeName;
        public int cost;
        public D(int cost, string article, string storeName )
        {
            this.article = article;
            this.storeName = storeName;
            this.cost = cost;
        }
    }
    class E
    {
        public int userCode;
        public string article;
        public string storeName;
        public E(string storeName, string article, int userCode)
        {
            this.storeName = storeName;
            this.article = article;
            this.userCode = userCode;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var a = new List<A>()
            {
                new A("Pushkin",2000,1),
                new A("l",2000,2)

            };
            var c = new List<C>()
            {
                new C(1,50,"store1")
            };
            var d = new List<D>()
            {
                new D(10,"AD000-0000","store1"),
                new D(11,"AD000-0001","store1")
            };
            var e = new List<E>()
            {
                new E("store1","AD000-0000",1),
                new E("store1","AD000-0000",1)
            };
            var result = e
                .Join(d,
                v => Tuple.Create(v.article,v.storeName),
                o => Tuple.Create(o.article, o.storeName),
                (v, o) => new { StoreName = v.storeName, Cost = o.cost, UserCode = v.userCode })
                .Join(a, o => o.UserCode, v => v.userCode, (v, o) =>
                new { BirthYear = o.birthYear, v.StoreName, v.Cost, v.UserCode })
                .Select(v =>
                {
                    if (c.ToDictionary(n => n.userCode).Keys.Contains(v.UserCode)) return new { v.BirthYear, v.StoreName, Cost = v.Cost * c.ToDictionary(n => n.userCode)[v.UserCode].discount / 100, v.UserCode };
                    else return v;
                }).GroupBy(v => Tuple.Create(v.BirthYear, v.StoreName)).Select(v => new { Group = v.Key, Inf = v.ToList() }).Select(v =>
                {
                    return new { v.Group, Sum = v.Inf.Sum(l => l.Cost) };
                })
                ;
        }
    }
}
