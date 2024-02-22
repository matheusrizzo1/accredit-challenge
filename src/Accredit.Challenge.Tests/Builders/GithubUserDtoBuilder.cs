using Accredit.Challenge.Borders.Dtos;

namespace Accredit.Challenge.Tests.Builders
{
    public class GithubUserDtoBuilder
    {
        private string _login;
        private long _id;
        private string _avatar_Url;
        private string _url;
        private string _repos_Url;
        private string _name;
        private string _location;

        public GithubUserDtoBuilder()
        {
            _login = "login";
            _id = 123456;
            _avatar_Url = "http://github.com/avatar.png";
            _url = "http://github.com/login";
            _repos_Url = "http://github.com/login/repos";
            _name = "name";
            _location = "location";

        }

        public GithubUserDtoBuilder WithLogin(string login)
        {
            _login = login;
            return this;
        }

        public GithubUserDtoBuilder WithId(long id)
        {
            _id = id;
            return this;
        }

        public GithubUserDtoBuilder WithAvatar_Url(string avatar_Url)
        {
            _avatar_Url = avatar_Url;
            return this;
        }

        public GithubUserDtoBuilder WithUrl(string url)
        {
            _url = url;
            return this;
        }

        public GithubUserDtoBuilder WithRepos_Url(string repos_Url)
        {
            _repos_Url = repos_Url;
            return this;
        }

        public GithubUserDtoBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public GithubUserDtoBuilder WithLocation(string location)
        {
            _location = location;
            return this;
        }

        public GithubUserDto Build()
        {
            return new GithubUserDto
            {
                Login = _login,
                Id = _id,
                Avatar_Url = _avatar_Url,
                Url = _url,
                Repos_Url = _repos_Url,
                Name = _name,
                Location = _location
            };
        }
    }
}
