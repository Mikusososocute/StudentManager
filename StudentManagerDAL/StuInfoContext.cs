﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagerModel
{
    public class StuInfoContext:DbContext
    {
        public DbSet<StuInfo> StuInfos { get; set; }

        public StuInfoContext(DbContextOptions<StuInfoContext> options) : base(options)
        {
            
        }

    }

    


}
