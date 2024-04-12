using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBF_Never_Buddy.Classes
{
    public class btNode
    {
        public long data;
        public btNode? leftChild;
        public btNode? rightChild;

        public btNode(long data)
        {
            this.data = data;
        }

        public btNode() { }

    }

    public class BinaryTree
    {


        public btNode root;

        bool isEmpty()
        {
            return root == null;
        }

        void inorderTraversal()
        {
            inorder(root);
        }

        void preorderTraversal()
        {   
            preorder(root);
        }

        void postorderTraversal()
        {
            postorder(root);    
        }
        void inorder(btNode node)
        {
            if (root != null)
            {
                inorder(node.leftChild);
                Debug.WriteLine(node.data);
                inorder(node.rightChild);
            }
        }

        void preorder(btNode treePtr)
        {
            if (treePtr != null)
            {
                Debug.WriteLine(treePtr.data);
                preorder(treePtr.leftChild);
                preorder(treePtr.rightChild);   
            }
        }

        void postorder(btNode treePtr)
        {
            if (treePtr != null)
            {           
                postorder(treePtr.leftChild);
                postorder(treePtr.rightChild);
                Debug.WriteLine(treePtr.data);
            }
        }

        int treeHeight()
        {
            return height(root);
        }

        int treeNodeCount()
        {
            return nodeCount(root);
        }

        int height(btNode p)
        {
            if(p == null)
            {
                return 0;
            }
            else
            {
                return 1 + max(height(p.leftChild), height(p.rightChild)); 
            }
        }

        int max(int x, int y)
        {
            if(x >= y) 
            { 
                return x;
            }
            else
            {
                return y;
            }
        }

        int nodeCount(btNode p)
        {
            if( p == null)
            {
                return 0;
            }
            else
            {
                return 1 + nodeCount(p.leftChild) + nodeCount(p.rightChild);
            }
        }

    }
    public class BST : BinaryTree
    {
        public void insert(long data)
        {
            btNode current;
            btNode trailCurrent;
            btNode newNode = new();

            newNode.data = data;
            Debug.Assert(newNode != null);  
            newNode.leftChild = null;
            newNode.rightChild = null;
            if(this.root == null)
            {
                root = newNode;
            }
            else
            {
                current = this.root;
                while(current != null)
                {
                    trailCurrent = current;
                    if(current.data == data)
                    {
                        Debug.WriteLine($"Data {data} is already in the list\nDuplicates aren't allowed.");
                        return;
                    }
                    else if (current.data > data)
                    {
                        current = current.leftChild;
                    }
                    else
                    {
                        current = current.rightChild;
                    }
                }
                /**
                if (trailCurrent.data > data)
                {
                    trailCurrent.leftChild = newNode;
                }
                else
                {
                    trailCurrent.rightChild = newNode;
                }
                **/
            }
          

        }
        public bool search(int value)
        {
            btNode current;
            bool found = false;

            if(this.root == null)
            {
                Debug.WriteLine("Empty tree cannot search");
            }
            else
            {
                current = (btNode)this.root;
                while (current != null && !found)
                {
                    if(current.data == value)
                    {
                        found = true;
                    }
                    else if(current.data > value)
                    {
                        current = current.leftChild;
                    }
                    else
                    {
                        current = current.rightChild;
                    }
                }
            }
            return false;
        }

        public void deleteNode(int deleteItem)
        {
            btNode current;
            btNode trailCurrent;
            bool found = false; 

            if(this.root == null)
            {
                Debug.WriteLine("Cannot delete from empty tree.");
            }
            else
            {
                current = (btNode)this.root;
                trailCurrent = (btNode)this.root;

                while(current != null && !found)
                {
                    if(current.data == deleteItem)
                    {
                        found = true;
                    }
                    else
                    {
                        trailCurrent = current;
                        if(current.data > deleteItem)
                        {
                            current = current.leftChild;
                        }
                        else
                        {
                            current = current.rightChild;
                        }
                    }
                }
            }
        }


        public long MaxValue()
        {
            if (this.root == null)
            {
                Debug.WriteLine("Empty tree cannot search");
                return -1;
            }
            btNode node = root;
            while (node.rightChild != null)
            {
                node = node.rightChild;
            }

            return node.data;
        }

    }
}
