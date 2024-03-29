﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weight_Watchers.core.Response
{
    public class SubscriberAndCard:BaseResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        public double BMI { get; set; }
    }
}
