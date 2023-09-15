/*
Given an m x n matrix, return all elements of the matrix in spiral order.

Example 1:
Input: matrix = [[1, 2, 3],[4,5,6],[7,8,9]]
Output: [1,2,3,6,9,8,7,4,5]

Example 2:
Input: matrix = [[1, 2, 3, 4],[5,6,7,8],[9,10,11,12]]
Output: [1,2,3,4,8,12,11,10,9,5,6,7]

Constraints:
m == matrix.length
n == matrix[i].length
1 <= m, n <= 10
- 100 <= matrix[i][j] <= 100
*/

/*
Please implement the SpiralOrder method according to the description.
The correctness of the implementation will be validated with tests
once you send back your solution.
*/

namespace Algo
{

    public class SpiralMatrix
    {
        public IList<int> SpiralOrder(int[][] matrix)   
        {
            AlgoMatrix algoMatrix = new AlgoMatrix();
            int rowsTotal = matrix.Count() - 1;
            int colsTotal = matrix[0].Count() - 1;
            int rowStart = 0;
            int rowEnd = rowsTotal;
            int colStart = 0;
            int colEnd = colsTotal;

            List<int> result = new List<int>();
           
            while (algoMatrix.IsCompleted(matrix) && rowStart < rowEnd)
            {
                algoMatrix.printForward(matrix, rowStart, rowEnd, colStart, colEnd, result);

                matrix = algoMatrix.GetSwapMatrix(matrix);
                algoMatrix.printForward(matrix, rowStart, rowEnd, colStart, colEnd, result);
                matrix = algoMatrix.GetSwapMatrix(matrix);
                rowStart = rowStart + 1;
                rowEnd = rowEnd - 1;
                colStart = colStart + 1;
                colEnd = colEnd - 1;

            }
            return result;
        }
    }
}


