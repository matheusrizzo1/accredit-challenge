using Accredit.Challenge.Borders.Dtos;
using Accredit.Challenge.Borders.Exceptions;
using Accredit.Challenge.Borders.Services;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Accredit.Challenge.Api.Controllers
{
    public class GithubController : Controller
    {
        private readonly IGithubService _githubService;

        public GithubController(IGithubService githubService)
        {
            _githubService = githubService;
        }

        // GET: Github
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetUser(string username)
        {
            var res = new JsonResponse { success = true };
            try
            {
                var user = await _githubService.GetUser(username);

                res.data = user;
            }
            catch (NotFoundException)
            {
                res.success = false;
                res.msg = $"User with username '{username}' was not found";
            }
            catch (Exception)
            {

                res.success = false;
                res.msg = "An unexpected error occurred";
            }

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetRepos(string username)
        {
            var res = new JsonResponse { success = true };
            try
            {
                var repos = await _githubService.GetUserRepos(username);

                res.data = repos;
            }
            catch (NotFoundException)
            {
                res.success = false;
                res.msg = $"Repos for username '{username}' was not found";
            }
            catch (Exception)
            {

                res.success = false;
                res.msg = "An unexpected error occurred";
            }

            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}