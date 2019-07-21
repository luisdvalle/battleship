﻿using StateTrackerProject.Interfaces;

namespace StateTrackerProject.Domain
{
    public class Player : IPlayer
    {
        public string Name { get; }

        public Player(string name)
        {
            Name = name;
        }
    }
}
