using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Array
{
    /*
    Boxing ve Unboxing işlemlerinden kendimizi kurtararak Type güvenliğini saplmak için generic olarak sınıfımızı tanımladık.
    Bir sınıfı generic olarak tanımlamak için sınıf isminin sonuna <T> yazılır.

    Generic sınıfım için IEnumerable interface'ni miras alacağım, böylelikle bir numaralandırma özelliği kazanacak.
    Kazandıkğı bu numaralandırma özelliği sayeseinde elemanları foreach içinde kullanılabilir.

    Bir interface'i miras aldığımızda miras alınan interface'in içerdiği metodlar mevcut class'ın içinde override edilmelidir.

    ICloneable interface'inin Clone metodu ile ilgili nesnenin bir kopyasını oluşturabiliriz.
    */
    public class Array<T> : IEnumerable<T>, ICloneable
    {
        private T[] InnerList; //Sınıf içindeki dizimiz, private tanımlandı, dışardan erişim olmayacak.
        public int Count { get; private set; }
        public int Capacity => InnerList.Length; //Lambda expression ile tanımlanan ifade sadece okunabilirdir(get), yani set edilemez.
        //Capacity adlı property'e erişen kişi Lambda expression ile tanımladığımız return işlemi sayesinde dizinin uzunluğunu sorgulayacak.

        //Bir class tanımlandığında onun için default olarak boş bir constructur tanımlanır. Yazmaya gerek yoktur.

        public Array()
        {
            InnerList = new T[2]; //Elimde herhangi bir Size bilgisi yoksa bu diziyi 2 elemanlı olarak başlatacağım.
            Count = 0; //Henüz bir eleman eklenmedi diziye.
        }

        public Array(params T[] initial)
        {
            InnerList = new T[initial.Length];
            Count = 0;
            foreach (var item in initial) 
                Add(item); 
        }

        private void DoubleArray() //Dizin Size'ını ikiye katlar. Bunun için yeni bir dizi oluşturur.
        {
            var temp = new T[InnerList.Length * 2];
            for (int i = 0; i < InnerList.Length; i++) //Eski dizimiz içindeki elemanları koyalıyoruz.
            {
                temp[i] = InnerList[i]; 
            }
            InnerList = temp;
        }

        private void HalfArray()
        {
            if (InnerList.Length > 2) //Dizinin boyutunu yarıya indirebilmem için dizinin Size'ı en az 2 olmalı.
            {
                var temp = new T[InnerList.Length / 2];

                for (int i = 0; i < InnerList.Length / 4; i++)
                {
                    temp[i] = InnerList[i];
                }
                InnerList = temp;
            }
        }

        public void Add(T item)
        {
            if (InnerList.Length == Count) DoubleArray();
            InnerList[Count++] = item;
        }

        private T Remove()
        {
            if (Count == 0) throw new Exception("Array is empty.");

            if (InnerList.Length / 4 == Count)
            {
                HalfArray();
            }

            var temp = InnerList[Count - 1];
            if (Count > 0) Count--;
            return temp;
        }

        public object Clone()
        {
            //return this.MemberwiseClone(); //İlgili nesnenin bütün özelliklerinin yeni oluştutulan nesneye geçmesini sağlar.

            var arr = new Array<T>();

            foreach (var item in this)
                arr.Add(item);

            return arr;

            //Clone() metodu Object class'ına cast ederek döndürür, daha sonra programın ilgili yerinde dönüş değeri asıl class'a cast edilmelidir. 
        }

        public IEnumerator<T> GetEnumerator()
        {
            //Linq sorgusu.
            return InnerList.Take(Count).GetEnumerator(); //InnerList'teki elemanları Count kadar ver.
            //return InnerList.Select(x => x).GetEnumerator(); //InnerList'teki elemanları ver.
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
