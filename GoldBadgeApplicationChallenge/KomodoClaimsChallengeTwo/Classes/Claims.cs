using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeApplicationChallenge._02_KomodoClaims
{
    public enum ClaimType { Car = 1, Home, Theft }
    public class Claims
    {
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                if (DateOfClaim.Month > (DateOfIncident.Month + 1))
                {
                    return false;
                }
                else
                    return true;
            }
        }

        public Claims() { }
        public Claims(int id, ClaimType claimType, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = id;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
    }
}
