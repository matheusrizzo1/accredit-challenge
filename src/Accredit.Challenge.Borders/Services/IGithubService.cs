using Accredit.Challenge.Borders.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Accredit.Challenge.Borders.Services
{
    public interface IGithubService
    {
        Task<GithubUserDto> GetUser(string username);
        Task<IEnumerable<GithubRepoDto>> GetUserRepos(string username);
    }
}
