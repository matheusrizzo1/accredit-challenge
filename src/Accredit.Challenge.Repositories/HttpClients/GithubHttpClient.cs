using Accredit.Challenge.Borders.Dtos;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Accredit.Challenge.Repositories.HttpClients
{
    public class GithubHttpClient : HttpClientBase
    {
        private const string GITHUB_BASEURL = "https://api.github.com";
        public GithubHttpClient(HttpClient httpClient) : base(httpClient)
        { }

        public async Task<GithubUserDto> GetUser(string username)
        {
            var uri = $"{GITHUB_BASEURL}/users/{username}";
            return await Execute<GithubUserDto>(uri);
        }
        public async Task<IEnumerable<GithubRepoDto>> GetUserRepos(string username)
        {
            var uri = $"{GITHUB_BASEURL}/users/{username}/repos";
            return await Execute<IEnumerable<GithubRepoDto>>(uri);
        }
    }
}
