using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            testdll.DemoStruct1 d1 = new testdll.DemoStruct1();
            testdll.DemoStruct2 d2 = new testdll.DemoStruct2();
            for (int c = 0; c < 100000; c++)
            {
                d1.x = 1;//结构体 int类型
                d1.d = 65535;//结构体 ushort类型
                d1.y = 2.54;//结构体 double类型
                d1.z = false;//结构体 bool类型

                //结构体 float数组类型
                d1.arr = new float[200];
                for (int i = 0; i < d1.arr.Length; i++)
                    d1.arr[i] = i + 1;

                //结构体 char数组类型(string)
                //string sz = "qwertyqwpasdfghjklzxcmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbn\0";
                //d1.str = sz.ToCharArray();
                d1.str = "qwertyqwpasdfghjklzxcmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbn\0";

                //结构体 float二维数组类型
                d1.arr2 = new float[16];
                for (int i = 0; i < d1.arr2.Length; i++)
                {
                    d1.arr2[i] = i+1;
                }

                //结构体 bool数组类型
                d1.b = new bool[4];
                d1.b[0] = true;
                d1.b[1] = false;
                d1.b[2] = true;
                d1.b[3] = false;

                //参数bool数组类型，可以用byte数组替代
                byte[] b = new byte[4];
                b[0] = 1;
                b[1] = 0;
                b[2] = 1;
                b[3] = 0;

                //结构体 int类型
                d1.ptrLen1 = 4;
                d1.ptrLen2 = 5;

                //结构体 int型/char型一维指针类型
                int[] p2 = new int[d1.ptrLen1];
                byte[] pstr = new byte[d1.ptrLen1];
                for (int i = 0; i < d1.ptrLen1; i++)
                {
                    p2[i] = i * 2;
                    pstr[i] = Convert.ToByte(i + 2);
                }
                d1.p = Marshal.AllocHGlobal(d1.ptrLen1 * sizeof(int));
                Marshal.Copy(p2, 0, d1.p, d1.ptrLen1);
                
                d1.pstr = Marshal.AllocHGlobal(d1.ptrLen1 * sizeof(char));
                Marshal.Copy(pstr, 0, d1.pstr, d1.ptrLen1);
                

                //结构体 int型二维维指针类型
                int[][] pp = new int[d1.ptrLen1][];
                for (int i = 0; i < d1.ptrLen1; i++)
                {
                    pp[i] = new int[d1.ptrLen2];
                    for (int j = 0; j < d1.ptrLen2; j++)
                    {
                        pp[i][j] = (i * d1.ptrLen2) + j;
                    }
                }
                IntPtr[] intPtr = new IntPtr[d1.ptrLen1];
                for (int i = 0; i < d1.ptrLen1; i++)
                {
                    intPtr[i] = Marshal.AllocHGlobal(d1.ptrLen2 * sizeof(int));
                    Marshal.Copy(pp[i], 0, intPtr[i], d1.ptrLen2);

                }
                d1.pp = Marshal.AllocHGlobal(d1.ptrLen1*IntPtr.Size);
                Marshal.Copy(intPtr, 0, d1.pp, d1.ptrLen1);

                


                //结构体2
                d2.sum_arr = 0.0f;
                d2.sum_p = 0;
                d2.sum_pp = 0;

                d2.sum_arr1 = 0.0f;
                d2.sum_p1 = 0;
                d2.sum_pp1 = 0;
                ////////以上是对结构体变量赋值，需要进行托管转非托管//////


                //调用c++接口
                int a = testdll.testStruct(b, ref d1, ref d2);

                ///////以下是对接口返回的结构体进行非托管转托管////

                //计算结构体float数组和
                float sum_arr = 0;
                for (int i = 0; i < d1.arr.Length; i++)
                {
                    sum_arr += d1.arr[i];
                }

                //字符数组
                string sz = d1.str;

                //计算结构体int型一维指针和
                Marshal.Copy(d1.p, p2, 0, d1.ptrLen1);
                int sum_p = 0;
                for (int i = 0; i < p2.Length; i++)
                {
                    sum_p += p2[i];
                }

                //结构体char指针转byte数组
                Marshal.Copy(d1.pstr, pstr, 0, d1.ptrLen1);
                string szbyte = Encoding.Default.GetString(pstr);
                
                //计算结构体int型二维指针和
                Marshal.Copy(d1.pp, intPtr, 0, d1.ptrLen1);
                for (int i = 0; i < d1.ptrLen1; i++)
                {
                    Marshal.Copy(intPtr[i], pp[i], 0, d1.ptrLen2);
                }
                int sum_pp = 0;
                for (int i = 0; i < intPtr.Length; i++)
                {
                    for (int j = 0; j < pp[i].Length; j++)
                    {
                        sum_pp += pp[i][j];
                    }
                }
                
                //释放非托管内存，必须手动调用
                Marshal.FreeHGlobal(d1.p);
                Marshal.FreeHGlobal(d1.pstr);
                for (int i = 0; i < d1.ptrLen1; i++)
                {
                    Marshal.FreeHGlobal(intPtr[i]);

                }
                Marshal.FreeHGlobal(d1.pp);
            }
        }
    }
}
