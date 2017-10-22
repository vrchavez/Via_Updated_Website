using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViaRepairFTE.Requests
{
    public class AppointmentUpdateRequest : AppointmentAddRequest
    {
        public int Id { get; set; }
    }
}