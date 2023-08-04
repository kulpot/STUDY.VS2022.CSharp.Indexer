using System;
using System.Collections;
using System.Collections.Generic;

//ref link:https://www.youtube.com/watch?v=3L6Wv7AxjjI&list=PLRwVmtr-pp07QlmssL4igw1rnrttJXerL&index=20
//ctrl+shift+space --- check target details 
// list -- are dynamic, can grow and shrink
// list -- manage array underneath
// all link function rely on IEnumerator
// IEnumerable -- the container sequence just like LINQ while IEnumerator --- can walk through the sequence of both linq and IEnumrable
// Indexer -- knowledge in operator overloading

class MeList<T> : IEnumerable<T>
{
    T[] items = new T[5];
    int count;
    public void Add(T item)
    {
        if (count == items.Length)
            Array.Resize(ref items, items.Length * 2);  // resize the underlying containers --- add slots by x2 of previous slot
        items[count++] = item;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < count; i++)
            yield return items[i];      // requires yield return knowledge
        //return new MeEnumerator(this);
    }

    IEnumerator System.Collections.IEnumerable.GetEnumerator() { return GetEnumerator(); }
    public T this[int index]    //indexer -- looks like property
    //public T this[int index, string blah, char c]
    {
        get
        {
            //if (index >= count || index < 0)              highlight+ctrl+. + extract method 
            //    throw new IndexOutOfRangeException();
            CheckBoundaries(index); 
            return items[index];
        }
        set 
        {
            //if (index >= count || index < 0)
            //    throw new IndexOutOfRangeException();
            CheckBoundaries(index);
            items[index] = value;
        }
    }

    void CheckBoundaries(int index)
    {
        if (index >= count || index < 0)
            throw new IndexOutOfRangeException();
    }
}


class MainClass
{
    static void Main()
    {
        MeList<int> myPartyAges = new MeList<int>() { 25, 34, 32 };
        myPartyAges[2] = 66;    
        //List<int> myPartyAges = new List<int>() { 25, 34, 32 };
        Console.WriteLine(myPartyAges[2]);
        //Console.WriteLine(myPartyAges[1, "kulpot", 'g']);

    }
}