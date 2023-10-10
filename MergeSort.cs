using System;

class MergeSort
{
    public static void Sort(int[] arr)
    {
        if (arr == null || arr.Length <= 1)
            return;

        MergeSortRecursive(arr, 0, arr.Length - 1);
    }

    private static void MergeSortRecursive(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int middle = (left + right) / 2;

            MergeSortRecursive(arr, left, middle);
            MergeSortRecursive(arr, middle + 1, right);

            Merge(arr, left, middle, right);
        }
    }

    private static void Merge(int[] arr, int left, int middle, int right)
    {
        int n1 = middle - left + 1;
        int n2 = right - middle;

        int[] leftArray = new int[n1];
        int[] rightArray = new int[n2];

        for (int i = 0; i < n1; i++)
        {
            leftArray[i] = arr[left + i];
        }

        for (int j = 0; j < n2; j++)
        {
            rightArray[j] = arr[middle + 1 + j];
        }

        int k = left;
        int iIndex = 0;
        int jIndex = 0;

        while (iIndex < n1 && jIndex < n2)
        {
            if (leftArray[iIndex] <= rightArray[jIndex])
            {
                arr[k] = leftArray[iIndex];
                iIndex++;
            }
            else
            {
                arr[k] = rightArray[jIndex];
                jIndex++;
            }
            k++;
        }

        while (iIndex < n1)
        {
            arr[k] = leftArray[iIndex];
            iIndex++;
            k++;
        }

        while (jIndex < n2)
        {
            arr[k] = rightArray[jIndex];
            jIndex++;
            k++;
        }
    }

    public static void Main(string[] args)
    {
        int[] arr = { 12, 4, 5, 6, 7, 3, 1, 15 };

        Console.Write("Original Array: ");
        PrintArray(arr);

        Sort(arr);

        Console.Write("Sorted Array: ");
        PrintArray(arr);
    }

    private static void PrintArray(int[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
