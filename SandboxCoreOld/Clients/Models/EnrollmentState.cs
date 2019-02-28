using System;

namespace SandboxCore.Clients.Models
{
    [Flags]
    public enum EnrollmentState
    {
        Active,
        Invited,
        Creation_Pending,
        Deleted,
        Rejected,
        Completed,
        Inactive,
    }
}