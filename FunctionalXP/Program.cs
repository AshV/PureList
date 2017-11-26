using static System.Console;

namespace FunctionalXP
{
    class Program
    {
        static void Main(string[] args)
        {
            PureList<int?> pureList = new PureList<int?>(1, 2, 3, 4, 5, 6, 7, 8, 9);

            WriteLine("Calling Head => ");
            WriteLine(pureList.Head());
            WriteLine();

            WriteLine("Calling Tail => ");
            PureList<int?> TailList = pureList.Tail();
            for (int i = 0; i < TailList.Length; i++)
                Write(TailList[i] + " ");
            WriteLine();
            WriteLine();

            WriteLine("Callng Cons => ");
            PureList<int?> ConsList = pureList.Cons(99);
            for (int i = 0; i < ConsList.Length; i++)
                Write(ConsList[i] + " ");
            WriteLine();
            WriteLine();

            WriteLine("Calling Drop => ");
            PureList<int?> DropList = pureList.Drop(2);
            for (int i = 0; i < DropList.Length; i++)
                Write(DropList[i] + " ");
            WriteLine();
            WriteLine();

            WriteLine("Callinh Reverse => ");
            PureList<int?> ReverseList = pureList.Reverse();
            for (int i = 0; i < ReverseList.Length; i++)
                Write(ReverseList[i] + " ");
            WriteLine();
            WriteLine();

            WriteLine("Calling Filter");
            PureList<int?> EvenElementList = pureList.Filter(e => e % 2 == 0);
            for (int i = 0; i < EvenElementList.Length; i++)
                Write(EvenElementList[i] + " ");
            WriteLine();
        }
    }
}