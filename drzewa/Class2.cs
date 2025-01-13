using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//zrobić metode dodaj do bst, TreeView,
namespace drzewa
{
    internal class BST
    {
        private NodeT root;

        public void Add(int liczba)
        {
            NodeT newNode = new NodeT(liczba);
            if (root == null)
            {
                root = newNode;
            }
            else
            {
                NodeT current = root;
                NodeT parent = null;

                while (current != null)
                {
                    parent = current;
                    if (liczba < current.data)
                    {
                        current = current.lewe;
                    }
                    else
                    {
                        current = current.prawe;
                    }
                }

                newNode.rodzic = parent;
                if (liczba < parent.data)
                {
                    parent.lewe = newNode;
                }
                else
                {
                    parent.prawe = newNode;
                }
            }
        }

        public void Remove(int liczba)
        {
            NodeT nodeToRemove = FindNode(root, liczba);
            if (nodeToRemove == null)
            {
                return; // Węzeł nie znaleziony
            }

            // 1. Gdy węzeł nie ma dzieci
            if (nodeToRemove.lewe == null && nodeToRemove.prawe == null)
            {
                if (nodeToRemove == root)
                {
                    root = null;
                }
                else
                {
                    if (nodeToRemove.rodzic.lewe == nodeToRemove)
                    {
                        nodeToRemove.rodzic.lewe = null;
                       
                    }
                    else
                    {
                        nodeToRemove.rodzic.prawe = null;
                        
                    }
                }
            }
            // 2. Gdy węzeł ma jedno dziecko
            else if (nodeToRemove.lewe == null || nodeToRemove.prawe == null)
            {
                NodeT child = (nodeToRemove.lewe != null) ? nodeToRemove.lewe : nodeToRemove.prawe;

                if (nodeToRemove == root)
                {
                    root = child;
                    child.rodzic = null;
                }
                else
                {
                    if (nodeToRemove.rodzic.lewe == nodeToRemove)
                    {
                        nodeToRemove.rodzic.lewe = child;
                    }
                    else
                    {
                        nodeToRemove.rodzic.prawe = child;
                    }
                    child.rodzic = nodeToRemove.rodzic;
                }
            }
            // 3. Gdy węzeł ma dwoje dzieci
            else
            {
                //poprawić jeśli nodeToremove.prawe.rodzic=successor
                NodeT successor = FindMin(nodeToRemove.prawe);
                nodeToRemove.data = successor.data;
                Remove(successor.data);
            }
        }

        private NodeT FindNode(NodeT current, int liczba)
        {
            while (current != null)
            {
                if (liczba == current.data)
                {
                    return current;
                }
                else if (liczba < current.data)
                {
                    current = current.lewe;
                }
                else
                {
                    current = current.prawe;
                }
            }
            return null;
        }

        private NodeT FindMin(NodeT node)
        {
            while (node.lewe != null)
            {
                node = node.lewe;
            }
            return node;
        }

        public void DodajDoTreeView(TreeNodeCollection nodes)
        {
            nodes.Clear();
            if (root != null)
            {
                DodajWęzełDoTreeView(root, nodes);
            }
        }

        public void DodajWęzełDoTreeView(NodeT node, TreeNodeCollection nodes)
        {
            if (node == null) return;

            TreeNode newNode = nodes.Add(node.data.ToString());
            DodajWęzełDoTreeView(node.lewe, newNode.Nodes);
            DodajWęzełDoTreeView(node.prawe, newNode.Nodes);
        }
        public void RemoveNodeFromTreeView(TreeView treeView, int value)
        {
            foreach (TreeNode node in treeView.Nodes)
            {
                TreeNode foundNode = FindNode(node, value);
                if (foundNode != null)
                {
                    foundNode.Remove(); // Usunięcie znalezionego węzła
                    return; // Przerywa pętlę po znalezieniu i usunięciu węzła
                }
            }
        }

        private TreeNode FindNode(TreeNode currentNode, int value)
        {
            if (int.Parse(currentNode.Text) == value)
            {
                return currentNode;
            }

            foreach (TreeNode childNode in currentNode.Nodes)
            {
                TreeNode foundNode = FindNode(childNode, value);
                if (foundNode != null)
                {
                    return foundNode;
                }
            }

            return null; // Zwraca null, jeśli węzeł nie został znaleziony
        }
    }
}
