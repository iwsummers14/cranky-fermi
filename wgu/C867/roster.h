/*

	Ian Summers
	C867 Scripting and Programming
	Student ID: 000490659

*/


#pragma once
#include "student.h"
#include "networkStudent.h"
#include "securityStudent.h"
#include "softwareStudent.h"
#include "degree.h"

using namespace std;

const string studentData[] = {
			"A1,John,Smith,John1989@gm ail.com,20,30,35,40,SECURITY",
			"A2,Suzan,Erickson,Erickson_1990@gmailcom,19,50,30,40,NETWORK",
			"A3,Jack,Napoli,The_lawyer99yahoo.com,19,20,40,33,SOFTWARE",
			"A4,Erin,Black,Erin.black@comcast.net,22,50,58,40,SECURITY",
			"A5,Ian ,Summers,isumme1@my.wgu.edu,36,29,44,32,SOFTWARE"
};

const int ROSTER_SIZE = sizeof(studentData) / sizeof(studentData[0]);
const int NUM_COURSES_TRACKED = 3;

class Roster
{
public:

	// constructor
	Roster();

	// destructor
	~Roster();

	// public functions
	void add(
		string studentId,
		string firstName,
		string lastName,
		string emailAddress,
		int age,
		int daysInCourse1,
		int daysInCourse2,
		int daysInCourse3,
		string sDegree
	);

	void remove(
		string studentId
	);

	void printAll();

	void printDaysInCourse(
		string studentId
	);

	void printInvalidEmails();

	void printByDegreeProgram(int degreeProgram);
	
	// array of pointers 
	Student* classRosterArray[ROSTER_SIZE] = { nullptr };
		
	
};
