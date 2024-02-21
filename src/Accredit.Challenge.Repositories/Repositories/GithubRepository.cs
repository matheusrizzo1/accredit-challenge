using Accredit.Challenge.Borders.Dtos;
using Accredit.Challenge.Borders.Repositories;
using Accredit.Challenge.Repositories.HttpClients;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Accredit.Challenge.Repositories.Repositories
{
    public class GithubRepository : IGithubRepository
    {
        private readonly GithubHttpClient _githubHttpClient;
        public GithubRepository(GithubHttpClient githubHttpClient)
        {
            _githubHttpClient = githubHttpClient;
        }

        public async Task<GithubUserDto> GetUser(string username) => await _githubHttpClient.GetUser(username);
        public async Task<IEnumerable<GithubRepoDto>> GetUserRepos(string username) => await _githubHttpClient.GetUserRepos(username);
    }
}
