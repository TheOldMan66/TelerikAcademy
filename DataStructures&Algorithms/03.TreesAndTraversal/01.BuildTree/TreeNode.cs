using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAndTraversal
{
    public class MyTreeNode<T>
    {
        private T value;
        private List<MyTreeNode<T>> childs;
        private MyTreeNode<T> parent;

        public MyTreeNode(T value)
        {
            this.value = value;
            this.childs = new List<MyTreeNode<T>>();
            this.parent = null;
        }

        public void AddChild(T value)
        {
            MyTreeNode<T> child = new MyTreeNode<T>(value);
            child.parent = this;
            this.childs.Add(child);
        }

        private void AddChild(MyTreeNode<T> child)
        {
            child.parent = this;
            this.childs.Add(child);
        }

        public T Value
        {
            get
            {
                return this.value;
            }
        }

        public List<MyTreeNode<T>> Childs
        {
            get
            {
                return this.childs;
            }
        }

        public MyTreeNode<T> Parent
        {
            get
            {
                return this.parent;
            }
        }

        public void ChangeParent(MyTreeNode<T> newParent)
        {
            if (this.parent != null)
            {
                this.parent.childs.Remove(this);
            }
            newParent.AddChild(this);
        }
    }
}
