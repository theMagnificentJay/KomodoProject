using GoldBadgeApplicationChallenge._02_KomodoClaims;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Tests
{
    [TestClass]
    public class _02_Tests
    {
        // View and Add claims test methods are technically the same bc claim needs to be added to view
        [TestMethod]
        public void ViewClaims_ShouldReturnClaims()
        {
            Claims claim = new Claims();
            ClaimsRepo _repo = new ClaimsRepo();
            _repo.AddClaim(claim);
            Queue<Claims> allClaims = _repo.ViewClaims();
            bool claimInQueue = allClaims.Contains(claim);
            Assert.IsTrue(claimInQueue);
        }

        [TestMethod]
        public void NextClaim_ShouldReturnBool()
        {
            Claims claim = new Claims();
            ClaimsRepo _repo = new ClaimsRepo();
            _repo.AddClaim(claim);
            Queue<Claims> allClaims = _repo.ViewClaims();
            _repo.NextClaim(claim);
            bool claimNotInQueue = allClaims.Contains(claim);
            Assert.IsFalse(claimNotInQueue);
        }

        [TestMethod]
        public void AddClaim_ShouldReturnBool()
        {
            Claims claim = new Claims();
            ClaimsRepo _repo = new ClaimsRepo();
            _repo.AddClaim(claim);
            Queue<Claims> allClaims = _repo.ViewClaims();
            bool claimInQueue = allClaims.Contains(claim);
            Assert.IsTrue(claimInQueue);
        }
    }
}
