using Accredit.Challenge.Borders.Dtos;

namespace Accredit.Challenge.Tests.Builders
{
    public class GithubRepoDtoBuilder
    {
        private long _id;
        private string _name;
        private string _description;
        private int _stargazers_Count;
        private string _html_Url;

        public GithubRepoDtoBuilder()
        {
            _id = 123456;
            _name = "Repo 1";
            _description = "Lorem ipsum";
            _stargazers_Count = 0;
            _html_Url = "https://github.com/user/repo";
        }

        public GithubRepoDtoBuilder WithId(long id)
        {
            _id = id;
            return this;
        }

        public GithubRepoDtoBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public GithubRepoDtoBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public GithubRepoDtoBuilder WithStargazers_Count(int stargazers_Count)
        {
            _stargazers_Count = stargazers_Count;
            return this;
        }

        public GithubRepoDtoBuilder WithHtml_Url(string html_Url)
        {
            _html_Url = html_Url;
            return this;
        }

        public GithubRepoDto Build()
        {
            return new GithubRepoDto
            {
                Id = _id,
                Name = _name,
                Description = _description,
                Stargazers_Count = _stargazers_Count,
                Html_Url = _html_Url
            };
        }
    }
}
