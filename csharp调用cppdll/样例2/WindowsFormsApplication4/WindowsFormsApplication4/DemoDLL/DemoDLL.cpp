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
		
		cout << "��ʼֵpDS->size:" << sizeof(DemoStruct1) << endl;
		cout << "��ʼֵpDS->x:" << pDS->x << endl;
		cout << "��ʼֵpDS->d:" << pDS->d << endl;
		cout << "��ʼֵpDS->y:" << pDS->y << endl;
		cout << "��ʼֵpDS->z:" << pDS->z << endl;
		cout << "��ʼֵpDS->ptrLen1:" << pDS->ptrLen1 << endl;
		cout << "��ʼֵpDS->ptrLen2:" << pDS->ptrLen2 << endl;
		cout << "��ʼֵpDS->str:" << pDS->str << endl;
		cout << "��ʼֵres->sum_arr:" << res->sum_arr << endl;
		cout << "��ʼֵres->sum_p:" << res->sum_p << endl;
		cout << "��ʼֵres->sum_pp:" << res->sum_pp << endl;
		cout << "��ʼֵb[]:";
		for (int i = 0; i <pDS->ptrLen1; i++)//c# ����bool ������Զ��ں��油3��0���ֽڶ��룬����c#��byte�����滻
		{
			cout << b[i];

		}
		cout << endl;

		cout << "��ʼֵpDS->pstr:";
		for (int i = 0; i < pDS->ptrLen1; i++)//c# char����ռ2��byte�� c++ֻռһ��byte,����c#ʹ��byte�����滻
		{
			cout << (int)pDS->pstr[i];
			
		}
		cout << endl;

		cout << "��ʼֵpDS->b[]:";
		for (int i = 0; i < pDS->ptrLen1; i++)
		{
			cout << pDS->b[i];

		}
		cout << endl;
		
		for (size_t i = 0; i < sizeof(d1->arr) / sizeof(float); i++)
		{
			res->sum_arr += pDS->arr[i];
		}
		cout << "�������res->sum_arr:" << res->sum_arr << endl;

		for (size_t i = 0; i < pDS->ptrLen1; i++)
		{
			res->sum_p += pDS->p[i];

			for (size_t j = 0; j < pDS->ptrLen2; j++)
			{
				res->sum_pp += pDS->pp[i][j];
			}
		}
		cout << "�������res->sum_p:" << res->sum_p << endl;
		cout << "�������res->sum_pp:" << res->sum_pp << endl;

		for (size_t i = 0; i < sizeof(d1->arr) / sizeof(float); i++)
		{
			pDS->arr[i] = i + 2;
			res->sum_arr1 += pDS->arr[i];
		}
		cout << "�޸ļ���res->sum_arr1:" << res->sum_arr1 << endl;

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
		cout << "�޸ļ���res->sum_p1:" << res->sum_p1 << endl;
		cout << "�޸ļ���res->sum_pp1:" << res->sum_pp1 << endl;

		return 0;
	}
}