﻿using KomodoBadgeChallengeThree.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeApplicationChallenge._03_KomodoBadges
{
    public class BadgesRepo
    {
        private readonly Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();

        public Dictionary<int, List<string>> ViewBadges()
        {
            return _badgeDictionary;
        }

        public void AddNewBadge(int key, List<string> value)
        {
            _badgeDictionary.Add(key, value);
        }

        public bool EditBadge(Badge badgeToEdit, Badge newBadge)
        {
            if (badgeToEdit != null)
            {
                badgeToEdit.BadgeID = newBadge.BadgeID;
                badgeToEdit.DoorAccess = newBadge.DoorAccess;
                return true;
            }
            else
                return false;
        }
    }
}
