using GoldBadgeApplicationChallenge._03_KomodoBadges;
using KomodoBadgeChallengeThree.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class _03_Tests
    {
        [TestMethod]
        public void ViewBadges_AssertWasAdded()
        {
            Badge badge = new Badge();
            BadgesRepo _repo = new BadgesRepo();
            _repo.AddNewBadge(1, new List<string> { "value" });
            Dictionary<int, List<string>> badgeRepo = _repo.ViewBadges();
            Assert.IsTrue(badgeRepo.ContainsKey(badge.BadgeID));
        }
    }
}
