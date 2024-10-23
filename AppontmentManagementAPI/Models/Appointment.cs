using System;
using System.Collections.Generic;

namespace AppontmentManagement.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public string PatientName { get; set; } = null!;

    public DateOnly AppointmentDate { get; set; }

    public TimeOnly AppointmentTime { get; set; }

    public string Reason { get; set; } = null!;
}
