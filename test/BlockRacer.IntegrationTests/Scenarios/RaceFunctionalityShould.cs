using System.Threading.Tasks;
using Xunit;
using BlockRacer.IntegrationTests.Base;

namespace BlockRacer.IntegrationTests {

    public class RaceFunctionalityShould : BaseTestSetup {

        public RaceFunctionalityShould() {
            
        }

        [Fact]
        public async Task ReturnOkWhenStartingAGame() {
        }

        [Fact]
        public async Task ReturnNoWhenDeletingAGameInProgress() {
        }

        [Fact]
        public async Task ReturnNoWhenMakingAnIllegalMove() {
        }

        [Fact]
        public async Task ReturnOkWhenMakingAnlegalMove() {
        }

        [Fact]
        public async Task ReturnNOkWhenMakingAMoveInAnOtherGame() {
        }

        [Fact]
        public async Task ReturnFalseWhenMakingMoreThanThreeGamesAsFreemiumUser() {
        }

        [Fact]
        public async Task ReturnOkWhenDeletingAMapThatUserHasCreated() {
        }

        [Fact]
        public async Task ReturnNOkWhenDeletingAMapThatOtherUserHasCreated() {
        }

        [Fact]
        public async Task ReturnZeroPublicGamesWhenNoGamesIsCreated() {            
        }
        [Fact]
        public async Task ReturnOnePublicGamesWhenOneGameIsCreated() {            
        }

        public async Task ReturnZeroPublicGamesWhenAllGamesAreStarted() {            
        }

        public async Task ReturnRaceResultForAnFinishedGame() {            
        }
    }
}