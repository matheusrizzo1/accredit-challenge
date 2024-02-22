using Accredit.Challenge.Borders.Dtos;
using Accredit.Challenge.Borders.Repositories;
using Accredit.Challenge.Services.Services;
using Accredit.Challenge.Tests.Builders;
using FluentAssertions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accredit.Challenge.Tests.Repositories
{
    [TestClass]
    public class GithubServiceTest
    {
        private readonly Mock<IGithubRepository> _githubRepository;
        private readonly GithubService _service;

        public GithubServiceTest()
        {
            _githubRepository = new Mock<IGithubRepository>();
            var cache = new MemoryCache(new MemoryCacheOptions());
            _service = new GithubService(_githubRepository.Object, cache);
        }

        [TestMethod]
        public async Task GetUser_WhenEverythingIsOK_ReturnsUser()
        {
            _githubRepository.Setup(x => x.GetUser(It.IsAny<string>())).ReturnsAsync(new GithubUserDtoBuilder().Build());

            var firstCallResponse = await _service.GetUser("login");
            var secondCallResponse = await _service.GetUser("login");

            firstCallResponse.Id.Should().BeGreaterThan(0);
            firstCallResponse.Login.Should().NotBeNullOrEmpty();
            firstCallResponse.Name.Should().NotBeNullOrEmpty();

            secondCallResponse.Id.Should().Be(firstCallResponse.Id);
            secondCallResponse.Login.Should().Be(firstCallResponse.Login);
            secondCallResponse.Name.Should().Be(firstCallResponse.Name);

            _githubRepository.Verify(x => x.GetUser(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public async Task GetRepos_WhenEverythingIsOK_ReturnsRepos()
        {
            _githubRepository.Setup(x => x.GetUserRepos(It.IsAny<string>())).ReturnsAsync(new List<GithubRepoDto> {
                new GithubRepoDtoBuilder().Build(),
                new GithubRepoDtoBuilder().Build(),
                new GithubRepoDtoBuilder().Build(),
                new GithubRepoDtoBuilder().Build(),
                new GithubRepoDtoBuilder().Build(),
                new GithubRepoDtoBuilder().Build() });

            var firstCallResponse = await _service.GetUserRepos("login");
            var secondCallResponse = await _service.GetUserRepos("login");

            firstCallResponse.Count().Should().Be(5);
            firstCallResponse.First().Id.Should().BeGreaterThan(0);
            firstCallResponse.First().Name.Should().NotBeNullOrEmpty();
            firstCallResponse.First().Html_Url.Should().NotBeNullOrEmpty();

            secondCallResponse.Count().Should().Be(5);
            secondCallResponse.First().Id.Should().Be(firstCallResponse.First().Id);
            secondCallResponse.First().Name.Should().Be(firstCallResponse.First().Name);
            secondCallResponse.First().Html_Url.Should().Be(firstCallResponse.First().Html_Url);

            _githubRepository.Verify(x => x.GetUserRepos(It.IsAny<string>()), Times.Once);
        }
    }
}
