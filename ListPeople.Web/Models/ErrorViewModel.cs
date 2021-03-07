using ListPeople.Data;
using System;
using System.Collections.Generic;

namespace ListPeople.Web.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
    public class HomeViewModel
    {
        public List<Person> People { get; set; }
        public string Message { get; set; }
    }
}
