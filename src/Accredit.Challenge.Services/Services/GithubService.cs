using Accredit.Challenge.Borders.Dtos;
using Accredit.Challenge.Borders.Repositories;
using Accredit.Challenge.Borders.Services;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accredit.Challenge.Services.Services
{
    public class GithubService : IGithubService
    {
        private const int TAKE_REPOS_COUNT = 5;
        private readonly IGithubRepository _githubRepository;
        private readonly IMemoryCache _cache;

        private const string USER_CACHE_TOKEN = "user_";
        private const string REPOS_CACHE_TOKEN = "repos_";
        private const int MINUTES_TO_EXPIRE = 10;
        public GithubService(IGithubRepository githubRepository, IMemoryCache cache)
        {
            _githubRepository = githubRepository;
            _cache = cache;
        }
        public async Task<GithubUserDto> GetUser(string username)
        {
            _cache.TryGetValue<GithubUserDto>(USER_CACHE_TOKEN + username, out var cachedUser);
            if (cachedUser != null) return cachedUser;

            var user = await _githubRepository.GetUser(username);
            _cache.Set(USER_CACHE_TOKEN + username, user, TimeSpan.FromMinutes(MINUTES_TO_EXPIRE));

            return user;
        }

        public async Task<IEnumerable<GithubRepoDto>> GetUserRepos(string username)
        {
            _cache.TryGetValue<IEnumerable<GithubRepoDto>>(REPOS_CACHE_TOKEN + username, out var cachedRepos);

            if (cachedRepos != null) return cachedRepos;
            var repos = await _githubRepository.GetUserRepos(username);
            var filteredRepos = repos.OrderByDescending(x => x.Stargazers_Count).Take(TAKE_REPOS_COUNT);

            _cache.Set(REPOS_CACHE_TOKEN + username, filteredRepos, TimeSpan.FromMinutes(MINUTES_TO_EXPIRE));

            return filteredRepos;
        }
    }
}
