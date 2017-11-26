using System;
using static System.Console;

namespace FunctionalXP
{
    class Program
    {
        static void Main(string[] args)
        {
            var pList = new PureList<int>(1, 2, 3, 4, 5, 6, 7, 8, 9);
            WriteLine(pList.Head());
            var N = pList.Tail();
            for (int i = 0; i < N.Length; i++)
                Write(N[i] + " ");
            WriteLine();
            N = pList.Cons(99);
            for (int i = 0; i < N.Length; i++)
                Write(N[i] + " ");
            WriteLine();
            N = pList.Drop(2);
            for (int i = 0; i < N.Length; i++)
                Write(N[i] + " ");
            WriteLine();
            N = pList.Reverse();
            for (int i = 0; i < N.Length; i++)
                Write(N[i] + " ");
        }
    }
}