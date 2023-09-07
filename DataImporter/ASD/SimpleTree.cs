using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DataImporter.ASD
{
    public class SimpleTreeNode<T>
    {
        public T NodeValue;
        public SimpleTreeNode<T> Parent;
        public List<SimpleTreeNode<T>> Children;
        public int Depth = 0;

        public SimpleTreeNode(T val, SimpleTreeNode<T> parent)
        {
            NodeValue = val;
            Parent = parent;
            Children = new List<SimpleTreeNode<T>>();
            Depth = 0;
        }
        public SimpleTreeNode(T val)
        {
            NodeValue = val;
            Parent = null;
            Children = new List<SimpleTreeNode<T>>();
            Depth = 0;
        }
    }
    public class SimpleTree<T>
    {
        public static SimpleTreeNode<T> Root;
        public SimpleTree(SimpleTreeNode<T> root)
        {
            Root = root;
        }
        public void AddChild(SimpleTreeNode<T> ParentNode, SimpleTreeNode<T> NewChild)
        {
            if (ParentNode == null || NewChild == null) return;

            if (NodeExist(ParentNode))
            {
                ParentNode.Children.Add(NewChild);
                NewChild.Parent = ParentNode;
            }
        }
        private static bool NodeExist(SimpleTreeNode<T> node)
        {
            if (Equals(Root, node)) return true;
            bool exist = false;
            return NodeExistStart(Root, node, ref exist);
        }
        private static bool NodeExistStart(SimpleTreeNode<T> root, SimpleTreeNode<T> node, ref bool exist)
        {
            foreach (var child in root.Children)
            {
                if (Equals(child, node))
                {
                    exist = true;
                    return exist;
                }
                NodeExistStart(child, node, ref exist);
            }
            return exist;
        }
        public List<SimpleTreeNode<T>> GetAllNodes()
        {
            var result = new List<SimpleTreeNode<T>>() { Root };
            int depth = 1;
            Root.Depth = depth;
            StartGetAllNodes(Root, ref result, ref depth);
            return result;
        }
        private static void StartGetAllNodes(SimpleTreeNode<T> root, ref List<SimpleTreeNode<T>> result, ref int depth)
        {
            foreach (var child in root.Children)
            {
                depth++;

                child.Depth = depth;
                result.Add(child);
                StartGetAllNodes(child, ref result, ref depth);
            }
            depth--;
            return;
        }

        public List<SimpleTreeNode<T>> FindNodesByValue(T val)
        {
            if (Root == null) return new List<SimpleTreeNode<T>>();

            var result = new List<SimpleTreeNode<T>>();

            if (Equals(Root.NodeValue, val))
            {
                result.Add(Root);
            }
            StartFindNodesByValue(Root, val, ref result);

            return result;
        }
        private void StartFindNodesByValue(SimpleTreeNode<T> root, T val, ref List<SimpleTreeNode<T>> result)
        {
            foreach (var child in root.Children)
            {
                if (Equals(child.NodeValue, val))
                {
                    result.Add(child);
                }
                StartFindNodesByValue(child, val, ref result);
            }
            return;
        }

        public int Count()
        {
            if (Root == null) return 0;

            var count = 1; // ++root
            StartCount(Root, ref count);
            return count;
        }

        public void StartCount(SimpleTreeNode<T> root, ref int count)
        {
            foreach (var child in root.Children)
            {
                count++;
                StartCount(child, ref count);
            }
            return;
        }
    }
}
