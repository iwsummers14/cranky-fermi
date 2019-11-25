/*

	Ian Summers
	C867 Scripting and Programming
	Student ID: 000490659

*/

#pragma once
#include "student.h"
#include "degree.h"

using namespace std;

//subclass SoftwareStudent, inherits class Student
class SoftwareStudent : public Student
{
	using Student::Student;

	public:
		Degree getDegreeProgram() override;

	protected:
		Degree degree = Degree::SOFTWARE;
};
