﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.PracticeExercises
{
    public class BlockedCellException : Exception
    {
        public BlockedCellException() : base("blocked cell") 
        {

        }
    }
}