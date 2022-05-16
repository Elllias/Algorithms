


using System.Diagnostics;

namespace Lab2;

public class Main1{
    private static void Main()
    {
        var listSort = new[] {"BubbleSort", "QSort", "MergeSort", "InsertSort", "TreeSort", "RBSort"};
        
        Console.WriteLine("Что будем тестировать? \n");
        for (var i = 0; i < listSort.Length; i++)
        {
            Console.WriteLine($"{i+1}. {listSort[i]}");
        }
        Console.WriteLine("7. Все\n");

        switch(Convert.ToInt32(Console.ReadLine()))
        {
            case 1:
                TestBubbleSort();
                break;
            case 2:
                TestQSort();
                break;
            case 3: 
                TestMergeSort();
                break;
            case 4:
                TestInsertSort();
                break;
            case 5:
                TestTreeSort();
                break;
            case 6:
                TestRBSort();
                break;
            case 7:
                TestAllSort();
                break;
            default:
                Console.WriteLine("Неверный ввод! Введи цифру, напротив сортировки!");
                break;
        }

        Console.ReadLine();
    }

    private static void TestBubbleSort()
    {
        int[] arr = { 3, 9, 4, 6, 4, 1, 2, 3, 2, 8, 7, 7 };
        
        Console.WriteLine("Unsorted: ");
        foreach (int n in arr)
            Console.Write(n + " ");
        Console.WriteLine();
        
        BubbleSort.Sorting(arr);
        
        Console.WriteLine("Sorted: ");
        foreach (int n in arr)
            Console.Write(n + " ");
        Console.WriteLine();
    }

    private static void TestQSort()
    {
        int[] arr = { 3, 9, 4, 6, 4, 1, 2, 3, 2, 8, 7, 7 };
        
        Console.WriteLine("Unsorted");
        foreach (int n in arr)
            Console.Write(n + " ");
        Console.WriteLine();
        
        QSort.Sorting(arr);
        
        Console.WriteLine("Sorted");
        foreach (int n in arr)
            Console.Write(n + " ");
        Console.WriteLine();
    }

    private static void TestTreeSort()
    {
        int[] arr = { 3, 9, 4, 6, 4, 1, 2, 3, 2, 8, 7, 7 };
        
        Console.WriteLine("Unsorted: ");
        foreach (int num in arr)
            Console.Write(num + " ");
        Console.WriteLine();
        
        TreeSort ts = new TreeSort();
        ts.Sorting(arr);

        Console.WriteLine("Sorted: ");
        foreach (int num in arr)
            Console.Write(num + " ");
        Console.WriteLine();
    }
    
    private static void TestInsertSort()
    {
        int[] arr = { 3, 9, 4, 6, 4, 1, 2, 3, 2, 8, 7, 7 };
        
        Console.WriteLine("Unsorted: ");
        foreach (int num in arr)
            Console.Write(num + " ");
        Console.WriteLine();
        
        InsertSort.Sorting(arr);

        Console.WriteLine("Sorted: ");
        foreach (int num in arr)
            Console.Write(num + " ");
        Console.WriteLine();
    }
    
    private static void TestMergeSort()
    {
        List<int> arr = new List<int>() { 3, 9, 4, 6, 4, 1, 2, 3, 2, 8, 7, 7 };
        
        Console.WriteLine("Unsorted: ");
        foreach (int num in arr)
            Console.Write(num + " ");
        Console.WriteLine();
        
        var result = MergeSort.Sorting(arr);

        Console.WriteLine("Sorted: ");
        foreach (int num in result)
            Console.Write(num + " ");
        Console.WriteLine();
    }
    
    private static void TestRBSort()
    {
        RBSort tree = new RBSort();
        tree.Insert(5);
        tree.Insert(3);
        tree.Insert(7);
        tree.Insert(1);
        tree.Insert(9);
        tree.Insert(-1);
        tree.Insert(11);
        tree.Insert(6);
        tree.DisplayTree();
    }

    private static void TestAllSort()
    {
        Console.WriteLine("BubbleSort:\n");
                TestBubbleSort();
                Console.WriteLine("\n");
                
                Console.WriteLine("QSort:\n");
                TestQSort();
                Console.WriteLine("\n");
                
                Console.WriteLine("MergeSort:\n");
                TestMergeSort();
                Console.WriteLine("\n");
                
                Console.WriteLine("InsertSort:\n");
                TestInsertSort();
                Console.WriteLine("\n");
                
                Console.WriteLine("TreeSort:\n");
                TestTreeSort();
                Console.WriteLine("\n");
                
                Console.WriteLine("RBSort:\n");
                TestRBSort();
                Console.WriteLine("\n");
    }
}