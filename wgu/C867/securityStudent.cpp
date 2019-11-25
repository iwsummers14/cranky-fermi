/*

	Ian Summers
	C867 Scripting and Programming
	Student ID: 000490659

*/

#pragma once
#include "securityStudent.h"
#include "degree.h"

// function definition for gettor/accessor getDegreeProgram, overridding class Student
Degree SecurityStudent::getDegreeProgram()
{
  return degree;
}
