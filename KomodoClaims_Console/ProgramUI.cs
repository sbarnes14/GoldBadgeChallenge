using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims_Console
{
    public class ProgramUI
    {
        ClaimsRepository _repo = new ClaimsRepository();
        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Please select action you would like to perform\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit");

                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "1":
                        ViewAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        EnterANewClaim();
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a number corresponding to the action you would like to perform");
                        break;
                }
                Console.WriteLine("Please press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void ViewAllClaims()
        {
            Console.Clear();
            Console.WriteLine($"{"ClaimID",-10} {"ClaimType",-15} {"Description",-20} {"Amount",-10} {"Date of incident",-20} {"Date of claim",-20} {"IsValid",-10}");
            List<Claims> allClaims = _repo.ViewAllClaims();
            foreach (Claims content in allClaims)
            {
                Console.WriteLine($"{content.ClaimID,-10} {content.ClaimType,-15} {content.ClaimDescription,-20} {content.ClaimAmount,-10} {content.DateOfIncident,-20} {content.DateOfClaim,-20} {content.Isvalid}");
            }
        }
        public void TakeCareOfNextClaim()
        {
            Console.Clear();
            List<Claims> nextClaim = _repo.ViewAllClaims();
            int index = nextClaim.IndexOf(nextClaim.GetEnumerator().Current);
            foreach (Claims claim in nextClaim.ToList())
            {
                Console.WriteLine($"ClaimID: {claim.ClaimID}\n" +
                    $"Claim Type: {claim.ClaimType}\n" +
                    $"Description: {claim.ClaimDescription}\n" +
                    $"Claim Amount: {claim.ClaimAmount}\n" +
                    $"Date of Incident: {claim.DateOfIncident}\n" +
                    $"Date of Claim: {claim.DateOfClaim}");

                Console.WriteLine("Do you want to deal with this claim now? (Y/N)");

                if (Console.ReadKey().KeyChar == 'y')
                {
                    _repo.NextClaim(claim);
                    Console.Clear();
                }
                else
                {
                Console.Clear();

                }
            }
        }
        public void EnterANewClaim()
        {
            Console.Clear();
            Claims newClaim = new Claims();

            List<Claims> claimList = _repo.ViewAllClaims();
            foreach (Claims content in claimList)
            {
                content.ClaimID += 1;
            }

            Console.WriteLine("What type of claim is this? (Auto, Home, Theft)");
            newClaim.ClaimType = Console.ReadLine();

            Console.WriteLine("Please Provide a brief description of the incident");
            newClaim.ClaimDescription = Console.ReadLine();

            Console.WriteLine("What is the amount for this claim?");
            string amountAsString = Console.ReadLine();
            double amountAsDouble = Convert.ToDouble(amountAsString);
            newClaim.ClaimAmount = amountAsDouble;

            Console.WriteLine("When did the incident occur? (MM, DD, YYYY)");
            string incidentAsString = Console.ReadLine();
            DateTime incidentAsDateTime = Convert.ToDateTime(incidentAsString);
            newClaim.DateOfIncident = incidentAsDateTime;

            Console.WriteLine("When was this claim filed? (MM, DD, YYYY)");
            string claimAsString = Console.ReadLine();
            DateTime claimAsDateTime = Convert.ToDateTime(claimAsString);
            newClaim.DateOfClaim = claimAsDateTime;

            bool wasAdded = _repo.CreateANewClaim(newClaim);
            if (wasAdded)
            {
                Console.WriteLine("The claim has been added successfully");
            }
            else
            {
                Console.WriteLine("The claim was not added correctly, please try again");
            }
        }
    }
}
