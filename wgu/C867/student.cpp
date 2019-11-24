/*
  Ian Summers
  C867
  Student Id:
*/
#include "student.h"
#include "degree.h"
#include <iostream>
#include <string>

/* default constructor definition */
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

/* constructor definition*/
Student::Student(string sId, string fName, string lName, string eAddress, int age, int* daysCourses, int daysCoursesArraySize)
{
    this->studentId = sId;
    this->firstName = fName;
    this->lastName = lName;
    this->emailAddress = eAddress;
    this->studentAge = age;
    for (int i = 0; i < daysCoursesArraySize; i++)
    {
      this->daysToComplete[i] = daysCourses[i];
    }

}

/* destructor definition */

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
int *Student::getStudentDaysToComplete()
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

/* print function */

void Student::print(){
    
      cout << getStudentId();
      cout << "\tFirst Name: " << getStudentFirstName();
      cout << "\tLast Name: " << getStudentLastName();
      cout << "\tAge: " << getStudentAge();
      cout << "\tdaysInCourse: " << getStudentDaysToComplete();
      cout << "\tDegree Program:" << getDegreeProgram() << endl;

}
