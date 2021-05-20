using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims_Console
{
    public class Claims
    {
        public double ClaimID { get; set; }
        public string ClaimType { get; set; }
        public string ClaimDescription { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool Isvalid
        {
            get
            {
                if ((DateOfClaim - DateOfIncident).TotalDays < 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public Claims() { }

        public Claims(double claimID, string claimType, string claimDescription, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            ClaimDescription = claimDescription;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
    }
}