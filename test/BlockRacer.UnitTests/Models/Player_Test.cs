using Xunit;
using BlockRacer.Mvc.Models;

namespace BlockRacer.UnitTests.Models
{
    public class Player_Test {
        [Theory]
        public void CreateRaceAndCheckNotStartedStatus() {
            Player player = new Player();
            //Race race = new Race();
            Assert.Equal(player.userType, Player.TypeOfUser.Freemium);  
        }
    }
}