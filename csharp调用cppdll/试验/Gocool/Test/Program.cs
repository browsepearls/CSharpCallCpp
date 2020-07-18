using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        [DllImport(@"Gocool.dll", EntryPoint = "const_char_star", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern  void const_char_star(string filename);

        public static void test_const_char_star(string filename)
        {
            const_char_star(filename);
        }


        [DllImport(@"Gocool.dll", EntryPoint = "char_star_for_a_var", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void char_star_for_a_var(ref byte var);

        public static void test_char_star_for_a_var(ref byte var)
        {
            char_star_for_a_var(ref var);
            Console.WriteLine((char)var);
        }

        [DllImport(@"Gocool.dll", EntryPoint = "char_arr", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void char_arr(byte[] bytes,int length);

        public static void test_char_arr(byte[] bytes)
        {
            char_arr(bytes, bytes.Length);
            foreach (byte item in bytes)
            {
                Console.Write((char)item + "\t");
            }
            Console.WriteLine();
        }

        [DllImport(@"Gocool.dll", EntryPoint = "double_star_star", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void double_star_star(IntPtr arr, int row, int column);

        public static void test_double_star_star(IntPtr arr, int row, int column)
        {
            double_star_star(arr, row, column);
        }


        static void Main(string[] args)
        {
            //测试案例1
            test_const_char_star("没有共产党，就没有如来佛祖");

            //测试案例2
            byte b = 65;
            test_char_star_for_a_var(ref b);

            //测试案例3
            test_char_arr(new byte[] { 65, 66, 67, 68, 69 });

            //测试案例4
            double[][] arr = new double[3][];
            for(int i = 0; i < arr.Length; ++i)
            {
                arr[i] = new double[4] { 0, 0, 0, 0 };
            }

            for(int k = 0; k < 1000000; ++k)
            {
                test_double_star_star(Trans(arr), 3, 4);

            }

            Console.Read();
        }

        static IntPtr Trans(double[][] arr)
        {
            //结构体 int型二维维指针类型

            IntPtr[] intPtr = new IntPtr[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                intPtr[i] = Marshal.AllocHGlobal(arr[i].Length * sizeof(double));
                Marshal.Copy(arr[i], 0, intPtr[i], arr[i].Length);
            }
            IntPtr result = Marshal.AllocHGlobal(arr.Length * IntPtr.Size);
            Marshal.Copy(intPtr, 0, result, arr.Length);
            return result;
        }
    }
}
