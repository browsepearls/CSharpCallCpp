using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication4
{
    public class testdll
    {
        [DllImport(@"DemoDLL.dll", EntryPoint = "testStruct", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int testStruct(byte[] b, ref DemoStruct1 d1, ref DemoStruct2 d2);
       


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct DemoStruct1
        {
            public int x;
            public ushort d;
            public double y;
            public bool z;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 200)]
            public float[] arr;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 100)]
            public string str;
            //[MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 100)]//ok
            //public char[] str;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4*4)]
            public float[] arr2;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
            public bool[] b;
            public IntPtr p;
            public IntPtr pp;
            public IntPtr pstr;
            public int ptrLen1;
            public int ptrLen2;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct DemoStruct2
        {
            public float sum_arr;
            public int sum_p;
            public int sum_pp;
            public float sum_arr1;
            public int sum_p1;
            public int sum_pp1;
        }

    }
}
