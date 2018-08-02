﻿using System;
using System.Collections.Generic;

namespace CarDealer.Models
{
    public class Car
    {
        public Car()
        {
            this.Sales = new HashSet<Sale>();
            this.PartCars = new HashSet<PartCar>();
        }

        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public ICollection<Sale> Sales { get; set; }

        public ICollection<PartCar> PartCars { get; set; }
    }
}