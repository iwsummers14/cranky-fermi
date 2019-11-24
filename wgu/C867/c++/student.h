/*

Ian Summers
C867 Scripting and Programming
Student ID:

*/
#pragma once
#ifndef STUDENT_H_
#define STUDENT_H_
#include "degree.h"

using namespace std;

class Student
{
    public:

        /* default constructor */
        Student();

        /* constructor with required parameters */
        Student(
          string sId,
          string fName,
          string lName,
          string eAddress,
          int age,
          int* daysCourses,
          int daysCoursesArraySize
        );

        /* accessor or 'getter' functions */
        string getStudentId() const;
        string getStudentFirstName() const;
        string getStudentLastName() const;
        string getStudentEmailAddress() const;
        int getStudentAge() const;
        int *getStudentDaysToComplete();


        /* mutator or 'setter' functions */
        void setStudentId(string sId);
        void setStudentFirstName(string fName);
        void setStudentLastName(string lName);
        void setStudentEmailAddress(string eAddress);
        void setStudentAge(int sAge);
        void setStudentDaysToComplete(int daysCourse1, int daysCourse2, int daysCourse3);

        /* virtual functions */
        virtual Degree getDegreeProgram();
        virtual void print();

        /* destructor */
        ~Student();

    protected:

        string studentId;
        string firstName;
        string lastName;
        string emailAddress;
        int studentAge;
        int daysToComplete[3];

};

#endif
