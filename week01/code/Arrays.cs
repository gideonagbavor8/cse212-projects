public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        // Plan:
        //  1. Create an array of size 'length' to store the multiples.
        //  2. Use a for loop to iterate 'length' times (i from 0 to length-1).
        //  3. For each iteration, calculate the multiple: number * (i + 1).
        //    - This gives us: number, 2*number, 3*number, ..., length*number.
        //  4. Store each calculated multiple in the array at index i.
        // Return the completed array.
        double[] multiples = new double[length];
        
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }


        return multiples; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        // Plan:
        // 1. Determine where the rotation point is using modulo to handle cases where amount >= data.Count
    //    - splitPoint = data.Count - (amount % data.Count)
    // 2. Extract the right portion (the elements that will move to the front)
    //    - Use GetRange(splitPoint, amount) to get elements from splitPoint to the end
    // 3. Extract the left portion (the elements that will move to the back)
    //    - Use GetRange(0, splitPoint) to get elements from start to splitPoint
    // 4. Clear the original list to remove all elements
    // 5. Add the right portion to the front of the list
    // 6. Add the left portion to the back of the list
    // This effectively rotates the list to the right by the specified amount
    int splitPoint = data.Count - (amount % data.Count);
        List<int> rightPortion = data.GetRange(splitPoint, data.Count - splitPoint);
        List<int> leftPortion = data.GetRange(0, splitPoint);
        
        data.Clear();
        data.AddRange(rightPortion);
        data.AddRange(leftPortion);
    }
}
