using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Striker : OffensivePlayer
{
    public Striker()
    {
        Position = "Striker";
    }
    public override void ExpCheck(int newExp)
    {
        base.ExpCheck(newExp + 1);
    }
}

