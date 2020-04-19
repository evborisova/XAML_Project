﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Consultant.Domain
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Assignment> Assigments { get; set; }

        public List<Employee> Employees { get; set; }

    }
}
