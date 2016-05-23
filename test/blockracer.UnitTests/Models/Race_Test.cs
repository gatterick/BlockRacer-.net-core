using System;
using Xunit;
using BlockRacer.Models;

namespace blockracer.UnitTests.Models.Race
{
    public class RaceUnitTest {
        [Fact]
        public void CreateRaceAndCheckNotStartedStatus() {
            Race race = new Race();
            Assert.False(true, "False -> False");   
        }
    }
}