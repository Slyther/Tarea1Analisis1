using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Domain.Entities;
using Domain.Services;
using MiPrimerMVC.Models;

namespace MiPrimerMVC.Controllers
{
    public class SynergyController : Controller
    {
        readonly IReadOnlyRepository _readOnlyRepository;
        readonly IWriteOnlyRepository _writeOnlyRepository;

        public SynergyController(IReadOnlyRepository readOnlyRepository, IWriteOnlyRepository writeOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository;
            _writeOnlyRepository = writeOnlyRepository;
        }

        [Authorize]
        public ActionResult Index()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                var user = _readOnlyRepository.FirstOrDefault<User>(x => x.Email == authTicket.UserData);
                if (user != null)
                {
                    var model = new ProjectListModel();
                    var typelist =
                        from ProjectEntity ute in _readOnlyRepository.GetAll<ProjectEntity>()
                        where ute.UserId == user.Id && !ute.Archived
                        select ute;
                    var typeList = new List<ProjectEntity>(typelist);
                    model.ProjectList = new List<ProjectListModel>();
                    foreach (var tL in typeList)
                    {
                        model.ProjectList.Add(new ProjectListModel
                        {
                            ProjectId = tL.Id,
                            ProjectName = tL.ProjectName,
                            ProjectDescription = tL.ProjectDescription
                        });
                    }
                    return View(model);
                }
            }
            return RedirectToAction("Logout", "User");
        }

        [Authorize]
        public ActionResult NewProject()
        {
            return View(new NewProjectModel());
        }

        [HttpPost]
        public ActionResult NewProject(NewProjectModel model)
        {
            if (ModelState.IsValid)
            {
                HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie != null)
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                    var user = _readOnlyRepository.FirstOrDefault<User>(x => x.Email == authTicket.UserData);
                    if (user != null)
                    {
                        var project = _readOnlyRepository.FirstOrDefault<ProjectEntity>(x => x.ProjectName == model.ProjectName && x.UserId == user.Id);
                        if (project == null)
                        {
                            var newProjectItem = new ProjectEntity
                            {
                                ProjectName = model.ProjectName,
                                UserId = user.Id,
                                ProjectDescription = model.ProjectDescription
                            };
                            newProjectItem = _writeOnlyRepository.Create(newProjectItem);
                            Session["CurrentViewProjectID"] = newProjectItem.Id;
                            Session["CurrentViewProjectName"] = newProjectItem.ProjectName;
                            return RedirectToAction("Index");
                        }
                        ModelState.AddModelError("", "A project with that name already exists!");
                    }
                }
            }
            return View(model);
        }

        [Authorize]
        public ActionResult UpdateProjectInfo(long id = -1)
        {
            var project = _readOnlyRepository.GetById<ProjectEntity>(id);
            if (project != null)
            {
                var model = new NewProjectModel
                {
                    ID = project.Id,
                    ProjectName = project.ProjectName,
                    ProjectDescription = project.ProjectDescription
                };
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UpdateProjectInfo(NewProjectModel model)
        {
            if (ModelState.IsValid)
            {
                var project = _readOnlyRepository.FirstOrDefault<ProjectEntity>(x => x.Id == model.ID);
                if (project != null)
                {
                    project.ProjectName = model.ProjectName;
                    project.ProjectDescription = model.ProjectDescription;
                    _writeOnlyRepository.Update(project);
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        public ActionResult ArchiveProject(long id = -1)
        {
            var project = _readOnlyRepository.FirstOrDefault<ProjectEntity>(x => x.Id == id);
            if (project != null)
            {
                project.Archive();
                _writeOnlyRepository.Update(project);
            }
            return RedirectToAction("Index");
        }

        public ActionResult ActivateProject(long id = -1)
        {
            var project = _readOnlyRepository.FirstOrDefault<ProjectEntity>(x => x.Id == id);
            if (project != null)
            {
                project.Activate();
                _writeOnlyRepository.Update(project);
            }
            return RedirectToAction("Index");
        }

        

        public ActionResult ArchiveHistory(long id = -1)
        {
            var project = _readOnlyRepository.FirstOrDefault<UserHistoryEntity>(x => x.Id == id);
            if (project != null)
            {
                project.Archive();
                _writeOnlyRepository.Update(project);
            }
            return RedirectToAction("Index");
        }

        public ActionResult ActivateHistory(long id = -1)
        {
            var project = _readOnlyRepository.FirstOrDefault<UserHistoryEntity>(x => x.Id == id);
            if (project != null)
            {
                project.Activate();
                _writeOnlyRepository.Update(project);
            }
            return RedirectToAction("Index");
        }


        public ActionResult ArchiveUserType(long id = -1)
        {
            var project = _readOnlyRepository.FirstOrDefault<UserTypeEntity>(x => x.Id == id);
            if (project != null)
            {
                project.Archive();
                _writeOnlyRepository.Update(project);
            }
            return RedirectToAction("Index");
        }

        public ActionResult ActivateUserType(long id = -1)
        {
            var project = _readOnlyRepository.FirstOrDefault<UserTypeEntity>(x => x.Id == id);
            if (project != null)
            {
                project.Activate();
                _writeOnlyRepository.Update(project);
            }
            return RedirectToAction("Index");
        }
    }
}