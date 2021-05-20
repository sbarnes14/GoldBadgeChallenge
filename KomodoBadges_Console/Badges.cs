using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges_Console
{
    public enum DoorType { A1 = 1, A2, A3, A4, A5, A6, A7, A8, A9}
    public class Badges
    {
        public int BadgeID { get; set; }
        public  List<DoorType> TypeOfDoor { get; set; }

        public Badges() { }
        public Badges(int badgeID)
        {
            BadgeID = badgeID;
        }
    }
}
