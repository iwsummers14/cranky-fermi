/*
Ian Summers
C867 Scripting and Programming
Student ID: 

const string studentData[] =
 {"A1,John,Smith,John1989@gmail.com,20,30,35,40,SECURITY",
 "A2,Suzan,Erickson,Erickson_1990@gmailcom,19,50,30,40,NETWORK",
 "A3,Jack,Napoli,The_lawyer99yahoo.com,19,20,40,33,SOFTWARE",
 "A4,Erin,Black,Erin.black@comcast.net,22,50,58,40,SECURITY",
 "A5,Ian,Summers,isumme1@my.wgu.edu,36,
 14,43,64,SOFTWARE"
}

*/
#include <string>
#ifndef STUDENT_H_
#define STUDENT_H_


class Student {
    public:

        /* default constructor */
        Student();

        /* constructor */
        Student(string sId, string fName, string lName, string eAddress, int age, int* daysCourses ){
        
        // accessor or 'getter' functions
        string getStudentId();
        string getStudentFirstName();
        string getStudentLastName();
        string getStudentEmailAddress();
        int getStudentAge();
        int *getStudentDaysToComplete();


        // mutator or 'setter' functions
        void setStudentId(string sId);
        void setStudentFirstName(string fName);
        void setStudentLastName(string lName);
        void setStudentEmailAddress(string eAddress);
        void setStudentAge(int sAge);
        void setStudentDaysToComplete(int daysCourse1, int daysCourse2, int daysCourse3);

    private:
        string studentId;
        string firstName;
        string lastName;
        string emailAddress;
        int studentAge;
        int daysToComplete[3];

        
}


#endif