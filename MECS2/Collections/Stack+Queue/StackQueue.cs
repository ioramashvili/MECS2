using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECS2
{
    class StackQueue
    {
        public static void StackExample()
        {
            Stack<string> stack = new Stack<string>();
            stack.Push("Student1");
            stack.Push("Student2");
            stack.Push("Student3");

            Console.WriteLine(stack.Peek());
            while (stack.Count != 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }

        public static void QueueExample()
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("Student1");
            queue.Enqueue("Student2");
            queue.Enqueue("Student3");

            Console.WriteLine(queue.Peek());
            while (queue.Count != 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
