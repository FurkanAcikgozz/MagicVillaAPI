﻿using MagicVillaAPI.Models;

namespace MagicVillaAPI.Data
{
    public static class VillaStore
    {
        //public static List<VillaDTO> villaList = new List<VillaDTO> {
        //    new VillaDTO{Id=1,Name="Pool View" },
        //    new VillaDTO{Id=2,Name="Beach View" }
        //    };

        public static List<VillaDTO> villaList = new List<VillaDTO> {
            new VillaDTO{Id=1,Name="Pool View",Sqft=100,Occupancy=4 },
            new VillaDTO{Id=2,Name="Beach View",Sqft=300,Occupancy=3 }
            };
    }
}
