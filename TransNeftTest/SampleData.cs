using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest
{
    public static class SampleData
    {
        public static void Initialize(OrganizationContext context)
        {
            if (!context.Holdings.Any())
            {
                context.Holdings.Add(new Holding { Name = "Транснефть" });
            }


        }
    }
}
