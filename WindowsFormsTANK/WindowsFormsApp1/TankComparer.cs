using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsTANK
{
    public class TankComparer : IComparer<Vehicle>
    {
        public int Compare(Vehicle x, Vehicle y)
        {
            if (x is TANK && y is TANK)
            {
                return ComparerTank((TANK)x, (TANK)y);
            }
            if (x is TANK && y is BasicTANK)
            {
                return -1;
            }
            if (x is BasicTANK && y is TANK)
            {
                return 1;
            }
            if (x is BasicTANK && y is BasicTANK)
            {
                return ComparerBasicTank((BasicTANK)x, (BasicTANK)y);
            }
            return 0;
        }
        private int ComparerBasicTank(BasicTANK x, BasicTANK y)
        {
            if (x.MaxSpeed != y.MaxSpeed)
            {
                return x.MaxSpeed.CompareTo(y.MaxSpeed);
            }
            if (x.Weight != y.Weight)
            {
                return x.Weight.CompareTo(y.Weight);
            }
            if (x.MainColor != y.MainColor)
            {
                return x.MainColor.Name.CompareTo(y.MainColor.Name);
            }
            return 0;
        }
        private int ComparerTank(TANK x, TANK y)
        {
            var res = ComparerBasicTank(x, y);
            if (res != 0)
            {
                return res;
            }
            if (x.DopColor != y.DopColor)
            {
                return x.DopColor.Name.CompareTo(y.DopColor.Name);
            }
            if (x.FrontSpoiler != y.FrontSpoiler)
            {
                return x.FrontSpoiler.CompareTo(y.FrontSpoiler);
            }
            if (x.SideSpoiler != y.SideSpoiler)
            {
                return x.SideSpoiler.CompareTo(y.SideSpoiler);
            }
            if (x.BackSpoiler != y.BackSpoiler)
            {
                return x.BackSpoiler.CompareTo(y.BackSpoiler);
            }
            if (x.SportLine != y.SportLine)
            {
                return x.SportLine.CompareTo(y.SportLine);
            }
            if (x.MainColor != y.MainColor)
            {
                return x.MainColor.Name.CompareTo(y.MainColor.Name);
            }
            if (x.Weight != y.Weight)
            {
                return x.Weight.CompareTo(y.Weight);
            }
            if (x.MaxSpeed != y.MaxSpeed)
            {
                return x.MaxSpeed.CompareTo(y.MaxSpeed);
            }
            return 0;
        }
    }
}
