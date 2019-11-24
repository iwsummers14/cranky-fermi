#pragma once
#ifndef ROSTER_H_
#define ROSTER_H_
#include "student.h"
#include "networkStudent.h"
#include "securityStudent.h"
#include "softwareStudent.h"
#include "degree.h"

using namespace std;

class Roster
{
	public:
		Roster();
		Roster(string* dataTable[]);

		~Roster();

	private:

		/*const string studentData[] = {
			"A1,John,Smith,John1989@gmail.com,20,30,35,40,SECURITY",
			"A2,Suzan,Erickson,Erickson_1990@gmailcom,19,50,30,40,NETWORKING",
			"A3,Jack,Napoli,The_lawyer99yahoo.com,19,20,40,33,SOFTWARE",
			"A4,Erin,Black,Erin.black@comcast.net,22,50,58,40,SECURITY",
			"A5,Ian,Summers,isumme1@my.wgu.edu,36,29,44,32, SOFTWARE"
		};

	  //protected*/

};

#endif