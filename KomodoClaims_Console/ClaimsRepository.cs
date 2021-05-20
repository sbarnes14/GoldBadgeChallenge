using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims_Console
{
    public class ClaimsRepository
    {
        private readonly List<Claims> _claims = new List<Claims>();

        public List<Claims> ViewAllClaims()
        {
            return _claims;
        }

        public bool NextClaim(Claims nextClaim)
        {
            int startingCount = _claims.Count;
            _claims.Remove(nextClaim);
            bool wasRemoved = (_claims.Count < startingCount) ? true : false;
            return wasRemoved;
        }

        public bool CreateANewClaim(Claims newClaim)
        {
            int startingCount =_claims.Count;
            _claims.Add(newClaim);
            bool wasAdded = (_claims.Count > startingCount) ? true : false;
            return wasAdded;
        }
    }
}
