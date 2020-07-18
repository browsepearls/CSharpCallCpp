// Gocool.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "head.h"
#include<stdio.h>


// 测试 const char *
void __stdcall const_char_star(const char * filename)
{
	printf("%s\n", filename);
}


void __stdcall char_star_for_a_var(char * var)
{
	*var = '$';
	printf("你好，我是C++ dll, 你用的C#传入的字符已经被我修改成字符$了\n");
}

void __stdcall char_arr(char arr[],int length)
{
	for (int i = 0; i < length; ++i)
	{
		arr[i] = 'N';
		printf("%c\t", arr[i]);
	}
	printf("\n");
}

void __stdcall double_star_star(double** arr, int row,int column) 
{
	for (int i = 0; i < row; ++i) {
		for (int j = 0; j < column; ++j) {
			arr[i][j] = i+j;
			printf("row:%d, column:%d, value:%f\n", i, j, arr[i][j]);
		}
	}
}