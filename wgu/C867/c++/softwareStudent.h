#include "student.h"
#include "degree.h"
using namespace std;

class SoftwareStudent : public Student
{
  public:
    Degree getDegreeProgram() override const;

  protected:
    Degree degree = SOFTWARE;
}
