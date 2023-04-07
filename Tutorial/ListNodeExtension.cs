
using System.Collections;
using System.Collections.Generic;

namespace Tutorial
{
    public class ListNode<T>
    {
        public readonly T Value;
        public readonly ListNode<T> Next;

        public ListNode(T value)
        {
            Value = value;
        }

        public ListNode(T value, ListNode<T> next)
        {
            Value = value;
            Next = next;
        }
    }

    public class SingleLinkedList<T> : IReadOnlyCollection<T>
    {
        public int Count => _count;

        private ListNode<T> _firstNode;
        private ListNode<T> _lastNode;
        private int _count;

        //public void Add(T value)
        //{
        //    var newNode = new ListNode<T>(value);

        //    if (_firstNode == null)
        //    {
        //        _firstNode = newNode;
        //    }
        //    else
        //    {
        //        _lastNode = new ListNode<T>(_lastNode.Value, newNode);
        //        _lastNode.;
        //    }

        //    _count++;
        //}

        public void Add(T newValue)
        {
            _firstNode = null;

            foreach (T value in this)
            {
                _firstNode = new ListNode<T>(value, new ListNode<T>(node.Value));
            }
            node = new ListNode<T>(newValue, node);
        }


        public IEnumerator<T> GetEnumerator()
        {
            ListNode<T> current = _firstNode;
            while(current != null)
            {
                yield return current.Value;
                current = current.Next;
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }
}
