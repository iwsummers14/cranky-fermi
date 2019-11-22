/* Ian Summers
C867 
Student Id:
*/
#include "student.h"
using namespace std;

/* default constructor definition */
Student::Student()
{
    studentId = "Unknown";
    firstName = "Unknown";
    lastName = "Unknown";
    emailAddress = "Unknown";
    studentAge = -1;
    daysToComplete = -1, -1, -1
}

/* constructor definition*/
Student::Student(string sId, string fName, string lName, string eAddress, int age, int *daysCourses)
{
    studentId = sId;
    firstName = fName;
    lastName = lName;
    emailAddress = eAddress;
    studentAge = age;
    daysToComplete = daysCourses;
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
void Student::setStudentId(string sId);
void Student::setStudentFirstName(string fName);
void Student::setStudentLastName(string lName);
void Student::setStudentEmailAddress(string eAddress);
void Student::setStudentAge(int sAge);
void Student::setStudentDaysToComplete(int daysCourse1, int daysCourse2, int daysCourse3);