﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Goalkeeper : DefenderPlayer
{
    public Goalkeeper()
    {
        Position = "Goalkeeper";
    }
    public override void ExpCheck(int newExp)
    {
        base.ExpCheck(newExp + 1);
    }
}

