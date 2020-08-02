using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap_Sort
{

    class HeapSortTree<T> where T : IComparable
    {
        List<T> Tree = new List<T>();
        int Root = 0;
        public HeapSortTree()
        {

        }
        public void Insert(T value)
        {
            if (Tree.Count == 0)
            {
                Tree.Add(value);
            }
            else
            {
                Tree.Add(value);
                HeapifyUp(Tree.Count);
            }

        }
        public void HeapifyUp(int index)
        {
            if (index == 0)
            {
                return;
            }
            T temp = default(T);
            dynamic a = Tree[index];
            dynamic b = Tree[(index - 1) / 2];
            if (a < b)
            {
                temp = a;
                a = b;
                b = temp;
                Tree[index] = a;
                Tree[(index - 1) / 2] = b;
                HeapifyUp((index - 1) / 2);
            }
        }
        public T Pop()
        {
            T temp = Tree[Root];
            Tree[Root] = Tree[Tree.Count - 1];
            Tree.RemoveAt(Tree.Count - 1);
            HeapifyDown(Root);
            return temp;
        }
        public void HeapifyDown(int index)
        {
            T temp = default(T);
            dynamic left = index * 2 + 1;
            dynamic right = index * 2 + 2;
            if (left <= Tree.Count && right <= Tree.Count)
            {
                if (Tree[left] < Tree[right])
                {
                    if (Tree[left] < Tree[index])
                    {
                        temp = Tree[index];
                        Tree[index] = Tree[left];
                        Tree[left] = temp;
                        HeapifyDown(left);
                    }
                }
                if (Tree[right] < Tree[left])
                {
                    if (Tree[right] < Tree[index])
                    {
                        temp = Tree[index];
                        Tree[index] = Tree[right];
                        Tree[right] = temp;
                        HeapifyDown(right);
                    }
                }
            }
            if (left > Tree.Count)
            {
                if (Tree[right] < Tree[index])
                {
                    temp = Tree[index];
                    Tree[index] = Tree[right];
                    Tree[right] = temp;
                    HeapifyDown(right);
                }
            }
            if (right > Tree.Count)
            {
                if (Tree[left] < Tree[index])
                {
                    temp = Tree[index];
                    Tree[index] = Tree[left];
                    Tree[left] = temp;
                    HeapifyDown(left);
                }
            }
        }
    }
}
