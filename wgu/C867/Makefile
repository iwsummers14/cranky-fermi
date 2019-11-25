CXX=clang++
CXXFLAGS=-g -std=c++11 -Wall -pedantic

roster : roster.o student.o networkStudent.o securityStudent.o softwareStudent.o
	$(CXX) roster.o student.o networkStudent.o securityStudent.o softwareStudent.o -o roster

roster.o : roster.cpp roster.h student.h networkStudent.h securityStudent.h softwareStudent.h degree.h
	$(CXX) -c roster.cpp

student.o : student.cpp student.h degree.h
	$(CXX) -c student.cpp

networkStudent.o : networkStudent.cpp networkStudent.h student.cpp student.h degree.h
	$(CXX) -c networkStudent.cpp

securityStudent.o : securityStudent.cpp	securityStudent.h student.cpp student.h degree.h
	$(CXX) -c securityStudent.cpp

softwareStudent.o : softwareStudent.cpp softwareStudent.h student.cpp student.h degree.h
	$(CXX) -c softwareStudent.cpp

clean :
	rm *.o
