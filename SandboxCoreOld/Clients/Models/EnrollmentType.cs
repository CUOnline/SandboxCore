using System;

namespace SandboxCore.Clients.Models
{
    [Flags]
    public enum EnrollmentType
    {
        StudentEnrollment,
        TeacherEnrollment,
        TaEnrollment,
        DesignerEnrollment,
        ObserverEnrollment,
    }
}