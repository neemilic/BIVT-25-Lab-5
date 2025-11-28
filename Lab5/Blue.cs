using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            double[] answer = null;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            answer = new double[n];
            for (int i = 0; i < n; i++)
            {
                int cnt = 0;
                double summ = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        summ += matrix[i, j];
                        cnt++;
                    }

                }
                if (cnt > 0)
                {
                    answer[i] = summ / cnt;
                }

            }
            Console.WriteLine(string.Join(" ", answer));
 

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        int mx_row = 0;
        int mx_col = 0;
        int[,] answer = null;
        answer = new int[n - 1, m - 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > matrix[mx_row, mx_col])
                    {
                        mx_row = i;
                        mx_col = j;
                    }
                }
            }
            for (int i = 0; i < mx_row; i++)
            {
                for (int j = 0; j < mx_col; j++)
                {
                    answer[i, j] = matrix[i, j];
                }
            }
            for (int i = mx_row; i < n - 1; i++)
            {
                for (int j = 0; j < mx_col; j++)
                {
                    answer[i, j] = matrix[i + 1, j];
                }
            }
            for (int i = 0; i < mx_row; i++)
            {
                for (int j = mx_col; j < m - 1; j++)
                {
                    answer[i, j] = matrix[i, j + 1];
                }
            }
            for (int i = mx_row; i < n - 1; i++)
            {
                for (int j = mx_col; j < m - 1; j++)
                {
                    answer[i, j] = matrix[i + 1, j + 1];
                    //Console.WriteLine(matrix[i + 1, j + 1]);
                }
            }

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (m > 1)
            {
                for (int i = 0; i < n; i++)
                {
                    int mx_ind = 0;
                    int mx_elem = matrix[i, 0];
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i, j] > matrix[i, mx_ind])
                        {
                            mx_ind = j;
                            mx_elem = matrix[i, j];
                        }
                    }
                    for (int j = mx_ind; j < m - 1; j++)
                    {
                        matrix[i, j] = matrix[i, j + 1];
                    }
                    matrix[i, m - 1] = mx_elem;
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                    Console.WriteLine(" ");
                }
            }
            

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            answer = new int[n, m + 1];
            for (int i = 0; i < n; i++)
            {
                int mx_elem = matrix[i, 0];
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > mx_elem)
                    {
                        mx_elem = matrix[i, j];
                    }
                }
                Console.WriteLine(mx_elem);
                for (int j = 0; j < m - 1; j++)
                {
                    answer[i, j] = matrix[i, j];
                }
                answer[i, m - 1] = mx_elem;
                answer[i, m] = matrix[i, m - 1];

            }

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            answer = new int[n * m / 2];
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((j + i) % 2 == 1)
                        answer[k++] = matrix[i, j];
                }
            }

            
            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m) return;
            int mx = matrix[0, 0];
            int mx_row = 0;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, i] > mx)
                {
                    mx = matrix[i, i];
                    mx_row = i;
                }
            }
            int first_otr = 0;
            bool flag = true;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, k] < 0)
                {
                    flag = false;
                    first_otr = i;
                    break;
                }
            }
            if (flag) return;
            int p = 0;
            for (int j = 0; j < m; j++)
            {
                p = matrix[mx_row, j];
                matrix[mx_row, j] = matrix[first_otr, j];
                matrix[first_otr, j] = p;
            }

        }
        public void Task7(int[,] matrix, int[] array)
        {
            int mx = matrix[0, 0];
            int mx_row = 0;
            int m = matrix.GetLength(1);

            Console.WriteLine(array.Length + " " + m);

            if (matrix.GetLength(1) >= 2 && array.Length == m)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {

                    if (matrix[i, m - 2] > mx)
                    {
                        mx = matrix[i, m - 2];
                        mx_row = i;
                    }
                }
                for (int i = 0; i < array.Length; i++)
                {
                    matrix[mx_row, i] = array[i];
                    //Console.WriteLine(matrix[i, m - 2]);
                }

            }
        }
        public void Task8(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int j = 0; j < m; j++)
            {
                int mx_row = 0;
                int mx = matrix[0, j];
                int sum = 0;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                        mx_row = i;
                    }
                }
                if (mx_row < n / 2)
                {
                    for (int i = mx_row + 1; i < n; i++)
                    {
                        sum += matrix[i, j];
                    }
                    matrix[0, j] = sum;
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(" ");

        }
        public void Task9(int[,] matrix)
        {

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int k = n;
            if (n % 2 == 1)
                k = n - 1;
            for (int i = 0; i < k; i++)
            {
                if (i % 2 == 0)
                {
                    int mx_col_nc = 0;
                    int mx_nc = matrix[i, 0];
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i, j] > mx_nc)
                        {
                            mx_nc = matrix[i, j];
                            mx_col_nc = j;
                        }
                    }
                    int mx_col_ch = 0;
                    int mx_ch = matrix[i + 1, 0];
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i + 1, j] > mx_ch)
                        {
                            mx_ch = matrix[i + 1, j];
                            mx_col_ch = j;
                        }
                    }
                    //Console.WriteLine(mx_nc + " " + mx_ch);
                    (matrix[i, mx_col_nc], matrix[i + 1, mx_col_ch]) = (matrix[i + 1, mx_col_ch], matrix[i, mx_col_nc]);
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

        }
        public void Task10(int[,] matrix)
        {

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m) return;
            int mx = matrix[0, 0];
            int mx_ind = 0;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, i] > mx)
                {
                    mx = matrix[i, i];
                    mx_ind = i;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < m; j++)
                {
                    if (i < mx_ind)
                        matrix[i, j] = 0;
                }
            }

        }
        public void Task11(int[,] matrix)
        {

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] array = new int[n];
            int[,] sort = new int[2, n];
            //int[] ind = new int[n];
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = 0; j < m; j++)
                    if (matrix[i, j] > 0)
                        count++;

                array[i] = count;
            }

            for (int i = 0; i < n - 1; i++)
            {
                int mi = i;

                for (int j = i + 1; j < n; j++)
                    if (array[j] > array[mi])
                        mi = j;

                if (mi == i)
                    continue;

                for (int j = 0; j < m; j++)
                    (matrix[i, j], matrix[mi, j]) = (matrix[mi, j], matrix[i, j]);

                (array[i], array[mi]) = (array[mi], array[i]);


            }
        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;
            double sum = 0;
            int cnt = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum += array[i][j];
                    cnt++;
                }
            }
            int cnt_del = 0;
            double sr_arr = sum / cnt;
            for (int i = 0; i < array.Length; i++)
            {
                double sum_row = 0;
                int cnt_row = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum_row += array[i][j];
                    cnt_row++;
                }
                if (sum_row / cnt_row < sr_arr)
                    cnt_del++;
            }
            //Console.WriteLine(cnt_del);
            answer = new int[array.Length - cnt_del][];
            int ind = -1;
            for (int i = 0; i < array.Length; i++)
            {
                //Console.WriteLine("check");

                double sum_row = 0;
                int cnt_row = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum_row += array[i][j];
                    cnt_row++;
                }

                if (sum_row / cnt_row >= sr_arr)
                {
                    ind++;

                    answer[ind] = new int[array[i].Length];
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        answer[ind][j] = array[i][j];
                    }
                }
            }

            for (int i = 0; i < answer.Length; i++)
            {
                for (int j = 0; j < answer[i].Length; j++)
                {
                    Console.Write(answer[i][j] + " ");
                }
                Console.WriteLine();
            }
            return answer;
        }
    }
}
