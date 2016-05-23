using System;
using Xunit;
using BlockRacer.Models;
using BlockRacer.Repositories;

namespace BlockRacer.UnitTests.Models
{
    public class RaceRepository_AddIsOk {
        [Fact]
        public void AddRaceToRepository() {
            Player player = new Player();
            Race race = new Race(1, 2, player);
            
            bool successful = RaceRepository.Add(race);
            Assert.True(successful, "The race was not added successfully to the repository.");
        }
    }
}