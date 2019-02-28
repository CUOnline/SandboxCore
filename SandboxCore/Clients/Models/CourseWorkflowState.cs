using System;

namespace SandboxCore.Clients.Models
{
    [Flags]
    public enum CourseWorkflowState
    {
        Undefined = 0x00,
        Created = 0x01,
        Claimed = 0x02,
        Unpublished = 0x04,
        Available = 0x08,
        Completed = 0x10,
        Deleted = 0x20,
    }
}