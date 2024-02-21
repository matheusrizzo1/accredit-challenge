using Accredit.Challenge.Borders.Dtos;
using Accredit.Challenge.Borders.Repositories;
using Accredit.Challenge.Borders.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accredit.Challenge.Services.Services
{
    public class GithubService : IGithubService
    {
        private const int TAKE_REPOS_COUNT = 5;
        private readonly IGithubRepository _githubRepository;
        public GithubService(IGithubRepository githubRepository)
        {
            _githubRepository = githubRepository;
        }
        public async Task<GithubUserDto> GetUser(string username) => await _githubRepository.GetUser(username);

        public async Task<IEnumerable<GithubRepoDto>> GetUserRepos(string username)
        {
            var repos = await _githubRepository.GetUserRepos(username);

            return repos.OrderByDescending(x => x.Stargazers_Count).Take(TAKE_REPOS_COUNT);
        }
    }
}
