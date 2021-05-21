using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using ReelWords;
using Xunit;

namespace ReelWordsTests
{
    public class UserSessionManagerShould
    {
        private IUserSessionManager _userSessionManager;

        public UserSessionManagerShould()
        {
            _userSessionManager = new UserSessionManager();
        }

        [Fact]
        public void ReturnTheCurrentUserScore()
        {
            _userSessionManager.SaveScore(new Score(9000));
            _userSessionManager.SaveScore(new Score(1));
            //Act
            var result = _userSessionManager.GetTotalScore();
            //Assert
            var expectedScore = new Score(9001);
            result.Should().BeEquivalentTo(expectedScore);
        }
    }
}
