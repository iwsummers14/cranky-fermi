/*

	Ian Summers
	C867 Scripting and Programming
	Student ID: 000490659

*/

#include "student.h"
#include "degree.h"
#include <iostream>
#include <string>

// default constructor definition 
Student::Student()
{
    this->studentId = "Unknown";
    this->firstName = "Unknown";
    this->lastName = "Unknown";
    this->emailAddress = "Unknown";
    this->studentAge = -1;
    this->daysToComplete[0] = -1;
    this->daysToComplete[1]= -1;
    this->daysToComplete[2]= -1;
}

// constructor definition
Student::Student(string sId, string fName, string lName, string eAddress, int age, int* daysCourses)
{
    this->studentId = sId;
    this->firstName = fName;
    this->lastName = lName;
    this->emailAddress = eAddress;
    this->studentAge = age;
	
	int elementCount = (sizeof(daysToComplete) / sizeof(daysToComplete[0]));

    for (int i = 0; i < elementCount; i++)
    {
      this->daysToComplete[i] = daysCourses[i];
    }

}

// destructor definition 

Student::~Student(){

}

// accessor or 'getter' functions
string Student::getStudentId() const
{
    return studentId;
}
string Student::getStudentFirstName() const
{
    return firstName;
}

string Student::getStudentLastName() const
{
    return lastName;
}
string Student::getStudentEmailAddress() const
{
    return emailAddress;
}
int Student::getStudentAge() const
{
    return studentAge;
}
int* Student::getStudentDaysToComplete()
{
    return daysToComplete;
}

// mutator or 'setter' functions
void Student::setStudentId(string sId){
  this->studentId = sId;
}

void Student::setStudentFirstName(string fName)
{
    this->firstName = fName;
}

void Student::setStudentLastName(string lName)
{
  this->lastName = lName;
}
void Student::setStudentEmailAddress(string eAddress)
{
  this->emailAddress = eAddress;
}
void Student::setStudentAge(int sAge)
{
  this->studentAge = sAge;
}
void Student::setStudentDaysToComplete(int daysCourse1, int daysCourse2, int daysCourse3)
{
  this->daysToComplete[0] = daysCourse1;
  this->daysToComplete[1] = daysCourse2;
  this->daysToComplete[2] = daysCourse3;
}

// print function 

void Student::print(){
    
      cout << "First Name: " << getStudentFirstName() << "\t";
      cout << "Last Name: " << getStudentLastName() << "\t";
      cout << "Age: " << getStudentAge() << "  \t";

	  cout << "daysInCourse: {";
	  int* days = getStudentDaysToComplete();
	  for (int i = 0; i < 3; i++) {
		  
		  cout << days[i];

		  if (i != 2) {
			  cout << ", ";
		  }

	  }
	  cout << "}";

	  cout << "\tDegree Program: ";
	  switch (getDegreeProgram()) {
	  case 0:
		  cout << "Security\n";
		  break;
	  case 1:
		  cout << "Networking\n";
		  break;
	  case 2:
		  cout << "Software\n";
	  }
	  
}

