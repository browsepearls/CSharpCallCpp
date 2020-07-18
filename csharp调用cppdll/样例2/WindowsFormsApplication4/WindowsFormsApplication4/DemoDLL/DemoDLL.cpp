// DemoDLL.cpp : Defines the exported functions for the DLL application.
//

#include "DemoDLL.h"
#include <iostream>
#include <string>
using namespace std;

extern "C"
{
	dll_export int __stdcall testStruct(bool b[], DemoStruct1 * pDS, DemoStruct2 * res)
	{
		
		cout << "初始值pDS->size:" << sizeof(DemoStruct1) << endl;
		cout << "初始值pDS->x:" << pDS->x << endl;
		cout << "初始值pDS->d:" << pDS->d << endl;
		cout << "初始值pDS->y:" << pDS->y << endl;
		cout << "初始值pDS->z:" << pDS->z << endl;
		cout << "初始值pDS->ptrLen1:" << pDS->ptrLen1 << endl;
		cout << "初始值pDS->ptrLen2:" << pDS->ptrLen2 << endl;
		cout << "初始值pDS->str:" << pDS->str << endl;
		cout << "初始值res->sum_arr:" << res->sum_arr << endl;
		cout << "初始值res->sum_p:" << res->sum_p << endl;
		cout << "初始值res->sum_pp:" << res->sum_pp << endl;
		cout << "初始值b[]:";
		for (int i = 0; i <pDS->ptrLen1; i++)//c# 参数bool 数组会自动在后面补3个0，字节对齐，所以c#用byte数组替换
		{
			cout << b[i];

		}
		cout << endl;

		cout << "初始值pDS->pstr:";
		for (int i = 0; i < pDS->ptrLen1; i++)//c# char类型占2个byte， c++只占一个byte,所以c#使用byte数组替换
		{
			cout << (int)pDS->pstr[i];
			
		}
		cout << endl;

		cout << "初始值pDS->b[]:";
		for (int i = 0; i < pDS->ptrLen1; i++)
		{
			cout << pDS->b[i];

		}
		cout << endl;
		
		for (size_t i = 0; i < sizeof(d1->arr) / sizeof(float); i++)
		{
			res->sum_arr += pDS->arr[i];
		}
		cout << "传入计算res->sum_arr:" << res->sum_arr << endl;

		for (size_t i = 0; i < pDS->ptrLen1; i++)
		{
			res->sum_p += pDS->p[i];

			for (size_t j = 0; j < pDS->ptrLen2; j++)
			{
				res->sum_pp += pDS->pp[i][j];
			}
		}
		cout << "传入计算res->sum_p:" << res->sum_p << endl;
		cout << "传入计算res->sum_pp:" << res->sum_pp << endl;

		for (size_t i = 0; i < sizeof(d1->arr) / sizeof(float); i++)
		{
			pDS->arr[i] = i + 2;
			res->sum_arr1 += pDS->arr[i];
		}
		cout << "修改计算res->sum_arr1:" << res->sum_arr1 << endl;

		pDS->x = 100;
		pDS->y = 33.5;
		pDS->z = !pDS->z;
		
		char sz[] = { "qqqqqyqwpasdfghjklzxcmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbn" };
		strcpy_s(pDS->str, sz);
		
		/*cout << "d1->arr2:" << sizeof(d1->arr2) / sizeof(float)/4 << endl;
		cout << "d1->arr2_1:" << sizeof(d1->arr2[0]) / sizeof(float) << endl;

		for (size_t i = 0; i < sizeof(d1->arr2) / sizeof(float)/4; i++)
		{

			for (size_t j = 0; j < sizeof(d1->arr2[i]) / sizeof(float); j++)
			{
				res->sum_pp += pDS->arr2[i][j];
			}
		}*/
		pDS->arr2[1][2] = 100;
		
		string aa = "abcd";
		strcpy_s(pDS->pstr, aa.length()+1,aa.c_str());

		//pDS->pstr = "abcd";
		for (size_t i = 0; i < pDS->ptrLen1; i++)
		{
			pDS->p[i] = i;
			//pDS->pstr[i] = 'a';
			res->sum_p1 += pDS->p[i];

			for (size_t j = 0; j < pDS->ptrLen2; j++)
			{
				pDS->pp[i][j] = j;
				res->sum_pp1+= pDS->pp[i][j];
			}
		}
		cout << "修改计算res->sum_p1:" << res->sum_p1 << endl;
		cout << "修改计算res->sum_pp1:" << res->sum_pp1 << endl;

		return 0;
	}
}