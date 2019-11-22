/*
  Ian Summers
  C867
  Student Id:
*/
#include "student.h"
using namespace std;

/* default constructor definition */
Student::Student()
{
    this->studentId = "Unknown";
    this->firstName = "Unknown";
    this->lastName = "Unknown";
    this->emailAddress = "Unknown";
    this->studentAge = -1;
    this->daysToComplete = -1, -1, -1
}

/* constructor definition*/
Student::Student(string sId, string fName, string lName, string eAddress, int age, int *daysCourses)
{
    this->studentId = sId;
    this->firstName = fName;
    this->lastName = lName;
    this->emailAddress = eAddress;
    this->studentAge = age;
    this->daysToComplete = daysCourses;
}

// accessor or 'getter' functions
string Student::getStudentId()
{
    return studentId;
}
string Student::getStudentFirstName()
{
    return firstName;
}

string Student::getStudentLastName()
{
    return lastName;
}
string Student::getStudentEmailAddress()
{
    return emailAddress;
}
int Student::getStudentAge()
{
    return studentAge;
}
int Student::*getStudentDaysToComplete()
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
