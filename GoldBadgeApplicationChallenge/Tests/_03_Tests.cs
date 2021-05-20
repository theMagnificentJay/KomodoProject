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

        [TestMethod]
        public void EditBadge_AssertWasEdited()
        {
            // Adding new badge
            Badge badge = new Badge();
            BadgesRepo _repo = new BadgesRepo();
            _repo.AddNewBadge(1, new List<string> { "value" });

            // Editing Badge
            bool editing = true;
            string list = "new value";
            _repo.EditBadge(1, list, editing);
            Assert.IsTrue(badge.DoorAccess.Contains(list)); // Fails - but works method works in ui I am bad at tests I know - forgive me
        }
    }
}
