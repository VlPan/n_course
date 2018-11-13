using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace N_Course.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int INN { get; set; }
        public string workCode { get; set; }
        public string profession { get; set; }
        public string DateOfBirth { get; set; }
        public string placeOfBorn { get; set; }
        public string citizenship { get; set; }
        public string address { get; set; }
        public string number { get; set; }
        public DateTime Created { get; set; }

    }
}