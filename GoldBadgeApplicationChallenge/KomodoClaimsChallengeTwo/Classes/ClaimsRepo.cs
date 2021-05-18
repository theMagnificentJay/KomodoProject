using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeApplicationChallenge._02_KomodoClaims
{
    public class ClaimsRepo
    {
        public readonly Queue<Claims> _claims = new Queue<Claims>();

        // CRUD w/ view[], remove/next[], add[] - in the menu list

        // ViewClaims
        public Queue<Claims> ViewClaims()
        {
            return _claims;
        }

        // NextClaim
        public bool NextClaim(Claims nextClaim)
        {
            Claims contentToDequeue = nextClaim;
            if (contentToDequeue != null)
            {
                _claims.Dequeue();
                return true;
            }
            else
                return false;
        }

        // NewClaim
        public bool AddClaim(Claims newClaim)
        {
            int startingCount = _claims.Count;
            _claims.Enqueue(newClaim);
            bool claimAdded = (_claims.Count > startingCount) ? true : false;
            return claimAdded;
        }
    }
}
