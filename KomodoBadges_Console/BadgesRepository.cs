using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges_Console
{
    public class BadgesRepository
    {
        private readonly List<Badges> _badges = new List<Badges>();

        public bool AddBadge(Badges newBadge)
        {
            int startingcount = _badges.Count;
            _badges.Add(newBadge);
            bool wasAdded = (_badges.Count > startingcount) ? true : false;
            return wasAdded;
        }
        public List<Badges> ViewAllBadges()
        {
            return _badges;
        }
    }
}
