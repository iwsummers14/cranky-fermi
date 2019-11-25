/*

	Ian Summers
	C867 Scripting and Programming
	Student ID: 000490659

*/

#include "roster.h"
#include "student.h"
#include "securityStudent.h"
#include "networkStudent.h"
#include "softwareStudent.h"
#include "degree.h"
#include <iostream>
#include <string>

using namespace std;

Roster::Roster() {};
Roster::~Roster() {
	for (int i = 0; i < ROSTER_SIZE; i++) {
		delete this->classRosterArray[i];
	}
	delete this;
};

void Roster::add(
		string studentId,
		string firstName,
		string lastName,
		string emailAddress,
		int age,
		int daysInCourse1,
		int daysInCourse2,
		int daysInCourse3,
		string sDegree
	) 
{

	int daysInCourses[3] = { daysInCourse1, daysInCourse2, daysInCourse3 };

	for (int i = 0; i < ROSTER_SIZE; i++)
	{
		if (classRosterArray[i] != nullptr)
		{
			continue;
		}
		else
		{
			if (sDegree == "NETWORK") {
				classRosterArray[i] = new NetworkStudent(
					studentId,
					firstName,
					lastName,
					emailAddress,
					age,
					daysInCourses
				);
			}

			if (sDegree == "SECURITY") {

				classRosterArray[i] = new SecurityStudent(
					studentId,
					firstName,
					lastName,
					emailAddress,
					age,
					daysInCourses
				);
			}

			if (sDegree == "SOFTWARE") {
				classRosterArray[i] = new SoftwareStudent(
					studentId,
					firstName,
					lastName,
					emailAddress,
					age,
					daysInCourses
				);
				
			}

			break;
		}
	}

};

void Roster::remove(string studentId) 
{

	bool studentFound = false;

	for (int i = 0; i < ROSTER_SIZE; i++)
	{
		if (classRosterArray[i] != nullptr) {

			if (classRosterArray[i]->getStudentId() == studentId) {
				
				studentFound = true;
				classRosterArray[i] = nullptr;
			}

		}

	}

	if (studentFound == true)
	{
		cout << "Student with ID " << studentId << " was removed from the roster.\n";
	}
	else {
		cout << "ERROR: Student with ID " << studentId << " was not found!\n";

	}
	
};

void Roster::printAll() {

	for (int i = 0; i < ROSTER_SIZE; i++)
	{
		if (classRosterArray[i] != nullptr) {
			cout << (i + 1) << "\t";
			classRosterArray[i]->print();
		}
		
	}
};

void Roster::printDaysInCourse(string studentId) 
{
	for (int i = 0; i < ROSTER_SIZE; i++)
	{
		if (classRosterArray[i] != nullptr) {

			if (classRosterArray[i]->getStudentId() == studentId) {

				int sum = 0;
				int average = 0;
				int* days = classRosterArray[i]->getStudentDaysToComplete();
				int divisor = NUM_COURSES_TRACKED;
				
				for (int i = 0; i < divisor; i++)
				{
					sum = sum + days[i];
				}

				average = sum / divisor;
				
				cout << "Student with ID " << studentId << " has spent an average of " << average << " days in the three courses.\n";

			}

		}

	}
};

void Roster::printInvalidEmails() {

	for (int i = 0; i < ROSTER_SIZE; i++)
	{
		if (classRosterArray[i] != nullptr) {
			
			bool hasAtSign = false;
			bool hasPeriod = false;
			bool hasSpaces = false;

			string emailAddr = classRosterArray[i]->getStudentEmailAddress();
			for (char &c : emailAddr) {
				
				if (c == '@') {
					hasAtSign = true;
				}
				if (c == '.') {
					hasPeriod = true;
				}
				if (c == ' ') {
					hasSpaces = true;
				}

			}
			
			// print based on evaluations
			if (hasAtSign == false)
			{
				cout << classRosterArray[i]->getStudentEmailAddress() << " <- This email address is missing an '@' symbol." << endl;
			}
			if (hasPeriod == false)
			{
				cout << classRosterArray[i]->getStudentEmailAddress() << " <- This email address is missing a period." << endl;
			}
			if (hasSpaces == true)
			{
				cout << classRosterArray[i]->getStudentEmailAddress() << " <- This email address contains spaces." << endl;
			}

		}

	}

};

void Roster::printByDegreeProgram(int degreeProgram) {

	for (int i = 0; i < ROSTER_SIZE; i++)
	{
		if (classRosterArray[i] != nullptr) {

			if (classRosterArray[i]->getDegreeProgram() == degreeProgram) {

				classRosterArray[i]->print();

			}
			
		}

	}
};

void printHeading() {
	cout << "==================================================================================\n";
	cout << "Performance Assessment for Course: C867 Scripting and Programming - Applications,\n";
	cout << "\twritten in C++,\n";
	cout << "\tby Ian Summers, Student ID#000490659.\n";
	cout << "==================================================================================\n\n";
}

void main() {

	// print heading - item F.1
	printHeading();

	// create instance of roster class - item F.2
	Roster* classRoster = new Roster();

	// parse data table and add students - item F.3
	cout << "\nParsing data table and adding students to roster..\n";
	for (int i = 0; i < ROSTER_SIZE; i++) {

		size_t position = 0;
		char delim = ',';
		string row = studentData[i];

		// extract student ID
		position = row.find(delim);
		string studentId = row.substr(0, position);
		row.erase(0, (position + 1));

		// extract firstName
		position = row.find(delim);
		string firstName = row.substr(0, position);
		row.erase(0, (position + 1));

		// extract lastName
		position = row.find(delim);
		string lastName = row.substr(0, position);
		row.erase(0, (position + 1));

		// extract email
		position = row.find(delim);
		string email = row.substr(0, position);
		row.erase(0, (position + 1));

		// extract age
		position = row.find(delim);
		string sAge = row.substr(0, position);
		row.erase(0, (position + 1));
		int age = stoi(sAge);

		// extract first value for days
		position = row.find(delim);
		string days1 = row.substr(0, position);
		row.erase(0, (position + 1));
		int daysInCourse1 = stoi(days1);


		// extract second value for days
		position = row.find(delim);
		string days2 = row.substr(0, position);
		row.erase(0, (position + 1));
		int daysInCourse2 = stoi(days2);

		// extract third value for days
		position = row.find(delim);
		string days3 = row.substr(0, position);
		row.erase(0, (position + 1));
		int daysInCourse3 = stoi(days3);

		// extract degree
		position = row.find(delim);
		string sDegree = row.substr(0, position);
		row.erase(0, (position + 1));

		// add the entry to the roster
		classRoster->add(
			studentId,
			firstName,
			lastName,
			email,
			age,
			daysInCourse1,
			daysInCourse2,
			daysInCourse3,
			sDegree
		);
	};


	// print all - item F.4.a
	cout << "\nPrinting full student roster..\n";
	classRoster->printAll();

	// identify invalid emails and print - item F.4.b
	cout << "\nPrinting invalid email addresses contained in the roster data..\n";
	classRoster->printInvalidEmails();
	
	// loop through classRosterArray and for each element - item F.4.c
	// classRoster.printAverageDaysInCourse(/*current_object's student id*/);
	cout << "\nPrinting average time spent across three courses for all students..\n";
	for (int i = 0; i < ROSTER_SIZE; i++) {

		string sId = classRoster->classRosterArray[i]->getStudentId();

		classRoster->printDaysInCourse(sId);
	}


	// classRoster.printByDegreeProgram(SOFTWARE) - item F.4.d
	cout << "\nPrinting list of students in the SOFTWARE program..\n";
	classRoster->printByDegreeProgram(Degree(SOFTWARE));

	// removing student with ID "A3" twice - item F.4.e and F.4.f
	cout << "\nRemoving Student A3..\n";
	classRoster->remove("A3");

	cout << "\nRemoving Student A3..\n";
	classRoster->remove("A3");

	// call the destructor - item F.4.g
	cout << "\nDisposing of class roster object..";
	delete classRoster;

}
