using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{

    class AlgoMatrix
    {

        public void printForward(int[][] sourceArray, int rowStart, int rowEnd, int colStart, int colEnd,List<int> result)
        {

            //upper row
            for (int j = rowStart; j <= colEnd; j++)
            {
                if (sourceArray[rowStart][j] != 0)
                {
                    result.Add(sourceArray[rowStart][j]);
                    //Console.Write(sourceArray[rowStart][j] + " ,");
                    sourceArray[rowStart][j] = 0;
                }

            }

            //side cols
            for (int i = rowStart; i <= rowEnd; i++)
            {
                for (int j = colStart; j <= colEnd; j++)
                {
                    if (j == colEnd)
                    {
                        if (sourceArray[i][j] != 0)
                        {
                            result.Add(sourceArray[i][j]);
                            //Console.Write(sourceArray[i][ j] + " ,");
                            sourceArray[i][j] = 0;
                        }

                    }
                }
            }
        }

        public int[][] GetSwapMatrix(int[][] sourceArray)
        {
           

            for (int i = 0; i < sourceArray.Length; i++)
            {
                Array.Reverse(sourceArray[i]);
            }
            Array.Reverse(sourceArray);
            return sourceArray;
        }

        public bool IsCompleted(int[][] sourceArray)
        {
            int rowsTotal = sourceArray.Count() - 1;
            int colsTotal = sourceArray[0].Count() - 1;
            int isCompletedCount = 0;
            for (int i = 0; i <= rowsTotal; i++)
            {
                for (int j = 0; j <= colsTotal; j++)
                {
                    if (sourceArray[i][j] == 0)
                        isCompletedCount++;
                }
            }

            return isCompletedCount <= (sourceArray.Count() * sourceArray[0].Count()) ? true : false;
        }


    }
}
