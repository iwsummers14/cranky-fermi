#include "student.h"
#include "degree.h"
using namespace std;

class NetworkStudent : public Student
{
  public:
    Degree getDegreeProgram() override const;

  protected:
    Degree degree = NETWORKING;
}
