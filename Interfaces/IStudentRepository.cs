using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Interfaces
{
    //TO SUPPORT DEPENDENCIES INJECTION (STORING THE OBject in service factory and get theobject from service factory)
    //AND ABSTRACTION
    //
    public interface IStudentRepository 
    {
        Student GetStudentDetails(string enrollId);
        int UpdateDetail(string enrollId,string Studentname);//newlyadded
        

    }
}
