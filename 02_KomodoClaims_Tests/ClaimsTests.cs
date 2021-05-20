using KomodoClaims_Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _02_KomodoClaims_Tests
{
    [TestClass]
    public class ClaimsTests
    {
        [TestMethod]
        public void ViewAllClaims()
        {
            Claims claim = new Claims();
            ClaimsRepository repository = new ClaimsRepository();
            repository.CreateANewClaim(claim);

            List<Claims> directory = repository.ViewAllClaims();

            bool result = directory.Contains(claim);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void EnterNewClaim()
        {
            Claims claim = new Claims();
            ClaimsRepository repository = new ClaimsRepository();

            bool result = repository.CreateANewClaim(claim);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void NextClaim()
        {
            Claims claim = new Claims();
            ClaimsRepository repository = new ClaimsRepository();

            bool result = repository.NextClaim(claim);

            Assert.IsTrue(result);
        }
    }
}
