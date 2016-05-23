using System;
using Xunit;
using BlockRacer.Models;

namespace BlockRacer.UnitTests.Models
{
    public class Player_Test {
        [Theory]
        public void CreateRaceAndCheckNotStartedStatus() {
            Player player = new Player();
            //Race race = new Race();
            Assert.Equal(player.getUserType(), Player.TypeOfUser.Freemium);   
        }
    }
}