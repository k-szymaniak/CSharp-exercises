using System;

namespace Lab_3
{
    class Stack<T>
    {
        private T[] _arr = new T[10];
        private int _last = -1;

        public void Push(T item)
        {
            _arr[++_last] = item;
        }
        public T Pop()
        {
            return _arr[_last--];
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            Stack<string> strstack = new Stack<string>(); 
            stack.Push(14);
            stack.Push(2);
            stack.Push(6);
            stack.Push(12);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            ValueTuple<string, decimal, int> product = ValueTuple.Create("Laptop",2000,4);
            
        }
    }
}
