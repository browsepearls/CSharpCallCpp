#pragma once
#pragma once
struct DemoStruct1
{
	int x;
	unsigned short d;
	double y;
	bool z;
	float arr[200];
	char str[100];
	float arr2[4][4];
	bool b[4];
	int *p;
	int **pp;
	char *pstr;
	int ptrLen1;
	int ptrLen2;
}*d1;

struct DemoStruct2
{
	float sum_arr;
	int sum_p;
	int sum_pp;
	float sum_arr1;
	int sum_p1;
	int sum_pp1;

};

#define dll_export __declspec(dllexport)
extern "C"
{
	dll_export int __stdcall testStruct(bool b[], DemoStruct1 *pDS, DemoStruct2 *res);
}