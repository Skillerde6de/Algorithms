using System;
using System.Linq;

namespace execution
{
  class array_example
  {
    public static int[] insertion_sort(int[] A)
    {
      Console.WriteLine("The order before sorting: " + string.Join(",", A));
      // Loop through for the amount of entries in the table
      for (int j = 1; j < A.Length; j++)
      {
        // Set key to the current value A
        var key = A[j];
        // Set compare to the index of the value before key
        int compare = j - 1;
        // Keep looping until either
        //  1: compare is below 0
        //  2: the value of compare is smaller than the value of the key
        while (compare >= 0 && A[compare] > key)
        {
          // Move the smaller value to the end of the array
          A[compare + 1] = A[compare];
          compare = compare - 1;
        }
        // Insert the value of key in the location above compare
        A[compare + 1] = key;
      }
      Console.WriteLine("The order after sorting: " + string.Join(",", A));
      return A;
    }

    public static int[] reverse_insertion_sort(int[] A)
    {
      // Calling the sorting function
      insertion_sort(A);
      // Reversing the output
      Array.Reverse(A);
      Console.WriteLine("The order after reversing the sort: " + string.Join(",", A));
      return A;
    }

    public static int sequential_search(int[] A, int toCheck)
    {
      // Loop for the amount of items in the array 
      for (int i = 0; i < A.Length; i++)
      {
        // If the current item matches the search
        if (A[i] == toCheck)
        {
          // Return the index
          return i;
        }
      }
      // Return -1 as error code
      return -1;
    }

    public static int[] add_arrays(int[] A, int[] B)
    {
      var arr1 = insertion_sort(A).ToList();
      var arr2 = insertion_sort(B).ToList();
      int[] C = new int[arr1.Count + arr2.Count];
      for (int i = 0; i < C.Length; i++)
      {
        int smaller = 0;
        if (arr1.Count > 0)
        {
          if (arr2.Count > 0)
          {
            if (arr1[0] <= arr2[0] || arr2.Count == 0)
            {
              smaller = arr1[0];
              arr1.Remove(smaller);
              Console.WriteLine("Value to be added: " + smaller);
            }
            else
            {
              smaller = arr2[0];
              arr2.Remove(smaller);
              Console.WriteLine("Value to be added: " + smaller);
            }
          }
          else
          {
            smaller = arr1[0];
            arr1.Remove(smaller);
            Console.WriteLine("Value to be added: " + smaller);
          }
        }
        else
        {
          smaller = arr2[0];
          arr2.Remove(smaller);
          Console.WriteLine("Value to be added: " + smaller);
        }
        C[i] = smaller;
      }
      Console.WriteLine(string.Join(",", C));
      return C;
    }
  }
}