#include "student.h"
#include "degree.h"
using namespace std;

class SecurityStudent : public Student
{
  public:
    Degree getDegreeProgram() override const;

  protected:
    Degree degree = SECURITY;
}
