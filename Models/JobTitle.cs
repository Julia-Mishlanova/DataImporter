﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class JobTitle
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
