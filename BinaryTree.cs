using System;
using System.Collections;
using System.Collections.Generic;

// Узагальнене бінарне дерево (лише класи, не структури)
public class BinaryTree<T> : IEnumerable<T> where T : class, IComparable<T>
{
    private class Node
    {
        public T Data;
        public Node Left;
        public Node Right;

        public Node(T data)
        {
            Data = data;
        }
    }

    private Node root;

    public void Insert(T item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        root = Insert(root, item);
    }

    private Node Insert(Node node, T item)
    {
        if (node == null)
            return new Node(item);

        if (item.CompareTo(node.Data) < 0)
            node.Left = Insert(node.Left, item);
        else
            node.Right = Insert(node.Right, item);

        return node;
    }

    // Центрований (inorder) обхід — варіант 6
    public IEnumerator<T> GetEnumerator()
    {
        return new InorderEnumerator(root);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    // Власний ітератор (inorder: лівий -> корінь -> правий)
    private class InorderEnumerator : IEnumerator<T>
    {
        private Node root;
        private Stack<Node> stack;
        private T current;
        private bool started;

        public InorderEnumerator(Node root)
        {
            this.root = root;
            stack = new Stack<Node>();
            Reset();
        }

        public T Current => current;
        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (!started)
            {
                PushLeft(root);
                started = true;
            }

            if (stack.Count == 0)
                return false;

            Node node = stack.Pop();
            current = node.Data;
            PushLeft(node.Right);
            return true;
        }

        private void PushLeft(Node node)
        {
            while (node != null)
            {
                stack.Push(node);
                node = node.Left;
            }
        }

        public void Reset()
        {
            stack.Clear();
            current = null;
            started = false;
        }

        public void Dispose() { }
    }
}
