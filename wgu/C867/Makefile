CXXFLAGS=-g -std=c++11 -Wall -pedantic

roster : roster.o student.o networkStudent.o securityStudent.o softwareStudent.o
	g++ roster.o student.o networkStudent.o securityStudent.o softwareStudent.o -o roster

roster.o : roster.cpp roster.h
	g++ $(CXX) -c roster.cpp

student.o : student.cpp student.h degree.h
	g++ $(CXX) -c student.cpp

networkStudent.o : networkStudent.cpp networkStudent.h student.cpp student.h degree.h
	g++ $(CXX) -c networkStudent.cpp

securityStudent.o : securityStudent.cpp	securityStudent.h student.cpp student.h degree.h
	g++ $(CXX) -c securityStudent.cpp

softwareStudent.o : softwareStudent.cpp softwareStudent.h student.cpp student.h degree.h
	g++ $(CXX) -c softwareStudent.cpp

clean :
	rm *.o
