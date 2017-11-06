using System;

namespace ASPNET_HerfstVakantie_Reygel_Robbe.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}