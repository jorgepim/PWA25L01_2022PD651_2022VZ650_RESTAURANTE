﻿using Microsoft.EntityFrameworkCore;

namespace L01_2022PD651_2022VZ650.Models
{
    public class restauranteContext : DbContext
    {
        public restauranteContext(DbContextOptions<restauranteContext> options) : base(options)
        {
        }
    }
}
