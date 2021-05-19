using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadgeChallengeThree.Classes
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> DoorAccess = new List<string>();

        public Badge() { }
        public Badge(int badgeID, List<string> doorAccess)
        {
            BadgeID = badgeID;
            DoorAccess = doorAccess;
        }
    }
}
