using Data_Structures._1.BasicTree;
using Data_Structures._2.BinaryTree;

namespace Data_Structures
{
    public static class Examples
    {
        public static Tree<int> Example1()
        {
            Tree<int> tree = new Tree<int>();
            tree.Root = new TreeNode<int>() { Data = 100 };
            tree.Root.Children = new List<TreeNode<int>>
            {
                new TreeNode<int>() { Data = 50, Parent = tree.Root},
                new TreeNode<int>() { Data = 1, Parent = tree.Root},
                new TreeNode<int>() { Data = 150, Parent = tree.Root},
            };

            tree.Root.Children[2].Children = new List<TreeNode<int>>()
            {
                new TreeNode<int>() { Data = 30, Parent = tree.Root.Children[2] }
            };

            return tree;
        }

        public static Tree<Person> Example2()
        {
            Tree<Person> company = new Tree<Person>();

            company.Root = new TreeNode<Person>()
            {
                Data = new Person(100, "Joe", "CEO"),
                Parent = null
            };

            company.Root.Children = new List<TreeNode<Person>>()
            {
                new TreeNode<Person>()
                {
                    Data = new Person(1, "Billy", "Manager of Development"),
                    Parent = null
                },
                new TreeNode<Person>()
                {
                    Data = new Person(50, "Rose", "Manager of Sales"),
                    Parent = null
                },
            };

            company.Root.Children[1].Children = new List<TreeNode<Person>>()
            {
                new TreeNode<Person>()
                {
                    Data = new Person(1, "Jacob", "Manager of Marketing"),
                    Parent = null
                },
                new TreeNode<Person>()
                {
                    Data = new Person(1, "Heinsenberg", "Pleb"),
                    Parent = null
                }
            };

            return company;
        }

        public static void ExampleBinaryTreeDisplay()
        {
            BTree btr = new BTree();
            btr.Add(6);
            btr.Add(2);
            btr.Add(3);
            btr.Add(11);
            btr.Add(30);
            btr.Add(9);
            btr.Add(13);
            btr.Add(18);

            btr.Print();
        }
    }


}