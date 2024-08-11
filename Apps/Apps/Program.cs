using Apps;

static int main()
{
    Console.WriteLine("\n+++++----- Binary Search Tree Examples -----+++++");

    Console.WriteLine("\nRead the source codes to see the difference between examples.\n");

    BinaryTreeExamples.BinarySearchTreeExample_01();
    BinaryTreeExamples.BinarySearchTreeExample_02();
    BinaryTreeExamples.BinarySearchTreeExample_03();

    Console.WriteLine("\n+++++----- Binary Search Tree Examples -----+++++\n");




    Console.WriteLine("\n+++++----- Breadth First Search Examples -----+++++");

    BreadthFirstSearchExamples.BreadthFirstSearchExample();

    Console.WriteLine("\n+++++----- Breadth First Search Examples -----+++++\n");




    Console.WriteLine("\n+++++----- Depth First Search Examples -----+++++");

    DepthFirstSearchExamples.DepthFirstSearchExample();

    Console.WriteLine("\n+++++----- Depth First Search Examples -----+++++\n");



    Console.WriteLine("+++++----- GRAPH EXAMPLES -----+++++");

    Console.WriteLine("\nRead the source codes to see the difference between examples.\n");

    GraphExamples.DirectionalWeightedGraphExample();
    GraphExamples.DirectionalUnweightedGraphExample();
    GraphExamples.UndirectedWeightedGraphExample();
    GraphExamples.UndirectedUnweightedGraphExample();

    Console.WriteLine("\n+++++----- GRAPH EXAMPLES -----+++++");




    Console.WriteLine("+++++----- HEAP EXAMPLES -----+++++");

    Console.WriteLine("\nRead the source codes to see the difference between examples.\n");

    HeapExamples.MinHeapExample_01();
    HeapExamples.MinHeapExample_02();

    HeapExamples.MaxHeapExample_01();
    HeapExamples.MaxHeapExample_02();

    Console.WriteLine("\n+++++----- HEAP EXAMPLES -----+++++");




    Console.WriteLine("\n+++++----- Linked List Examples -----+++++");

    LinkedListExamples.Addding_Value_to_my_Linked_List();
    LinkedListExamples.Addding_Node_to_my_Linked_List();
    LinkedListExamples.RemoveLast_Feature();
    LinkedListExamples.RemoveFirst_Feature();
    LinkedListExamples.Remove_Implementation();
    LinkedListExamples.LinQ_with_my_Linked_List();
    LinkedListExamples.Different_Constructor_Designs_for_my_Linked_List();

    Console.WriteLine("\n+++++----- Linked List Examples -----+++++\n");




    Console.WriteLine("\n+++++----- Min Spanning Tree Examples -----+++++");

    MinSpanningTreeExamples.KRUSKAL();
    MinSpanningTreeExamples.PRIMS();

    Console.WriteLine("\n+++++----- Min Spanning Tree Examples -----+++++\n");




    Console.WriteLine("\n+++++----- Post Fix Examples -----+++++");

    Console.WriteLine(PostFixExamples.Run("3 4 + 5 *")); // It works for only on digit numbers, you can improve the code

    Console.WriteLine("\n+++++----- Post Fix Examples -----+++++\n");




    Console.WriteLine("\n+++++----- Queue Examples -----+++++");

    QueueExamples.QueueExample_01();

    Console.WriteLine("\n+++++----- Queue Examples -----+++++\n");




    Console.WriteLine("\n+++++----- Set Examples -----+++++");

    SetExamples.SetExample_01();

    Console.WriteLine("\n+++++----- Set Examples -----+++++\n");




    Console.WriteLine("\n+++++----- Sorting Examples -----+++++");

    SortingExamples.QUICK_SORT();
    SortingExamples.INSERTION_SORT();
    SortingExamples.SELECTON_SORT();
    SortingExamples.MERGE_SORT();
    SortingExamples.HEAP_SORT();
    SortingExamples.BUBBLE_SORT();

    Console.WriteLine("\n+++++----- Sorting Examples -----+++++\n");




    Console.WriteLine("\n+++++----- Stack Examples -----+++++");

    StackExamples.Pushing_Popping_Peeking_getting_Count();

    Console.WriteLine("\n+++++----- Stack Examples -----+++++\n");

    return 0;
}

return main();