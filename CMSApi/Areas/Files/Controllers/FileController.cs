using CMSApi.Areas.Files.Models;
using CMSLcLy.Data.Bank;
using CMSLcLy.Data.Bank.BankShortCut;
using CMSLcLy.Data.EnumMaster;
using CMSLcLy.Data.File;
using CMSLcLy.Data.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMSLcLy.Data.Chat;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using CMSLcLy.Data.User;
using CMSApi.Models;
using System.Web.Http;

namespace CMSApi.Areas.Files.Controllers
{
    [System.Web.Http.Authorize]
    public class FileController : Controller
    {

        // GET: Files/File
        public ActionResult FileListing()
        {
            return View();
        }

        public ActionResult FileDetails(string fileNo)
        {
            var fileType = "";
            using (var mgr = new CMSLcLy.Data.File.Manager())
            {
                fileType = mgr.GetFileTypeByFileNo(fileNo);
            }

            switch (fileType)
            {
                case "SPA":
                    return RedirectToAction("Index","SPAnLoan" ,new
                    {
                        fileNo = fileNo,
                        area = "Files"
                    });
                    break;
                case "Refinancing":
                    return RedirectToAction("Index", "Refinancing", new
                    {
                        fileNo = fileNo,
                        area = "Files"
                    });
                    break;
                case "POTC":
                    return RedirectToAction("Index", "POTC", new
                    {
                        fileNo = fileNo,
                        area = "Files"
                    });
                    break;
                case "Transfer":
                    return RedirectToAction("Index", "Transfer", new
                    {
                        fileNo = fileNo,
                        area = "Files"
                    });
                    break;
                default:
                    return RedirectToAction("FileListing");
            }
        }

        [System.Web.Http.HttpPost]
        public dynamic GetFileListing()
        {
            List<FileListingMasterViewModel> model  = null;

            using (var mgr = new CMSLcLy.Data.File.Manager())
            {
                model = mgr.GetList();
            }

            int filteredResultsCount;
            int totalResultsCount;
            var res = model;

            var result = new List<FileListingMasterViewModel>(res.Count);
           
            return Json(new
            {
                // this is what datatables wants sending back
                draw = 1,
                recordsTotal = res.Count,
                recordsFiltered = res.Count,
                data =res
            }, JsonRequestBehavior.AllowGet);

        }

        [System.Web.Http.HttpPost]
        public dynamic GetWorkflow(string fileId)
        {
            var wfList = new List<WFMasterItemViewModel>();
            var wfListing = new List<WFViewModel>();
            if (!string.IsNullOrEmpty(fileId))
            {
                using (var mgr = new CMSLcLy.Data.File.Manager())
                {
                    wfList = mgr.ListByFileId(Convert.ToInt32(fileId)).ToList();
                }

                if(wfList.Count()> 0)
                {
                    foreach(var wf in wfList)
                    {
                        var tempWf = new WFViewModel()
                        {
                            Id = wf.Id,
                            WorkFlowMasterDesc = wf.WorkFlowMasterDesc,
                            Description = wf.Description,
                            IsCompleted = wf.isCompleted == 0 ? "Not Complete" : "Completed"
                        };

                        wfListing.Add(tempWf);
                    }
                }
            }

            return Json(new
            {
                // this is what datatables wants sending back
                draw = 1,
                recordsTotal = wfListing.Count,
                recordsFiltered = wfListing.Count,
                data = wfListing
            }, JsonRequestBehavior.AllowGet);

        }

        [System.Web.Http.HttpGet]
        public dynamic GetByRoomName(string roomName)
        {
            List<ChatViewModel> chatViewModel = new List<ChatViewModel>();

            using (var mgr = new CMSLcLy.Data.Chat.Manager())
            {
               var chatmasterViewModel = mgr.GetByRoomName(roomName).ToList();

                foreach (var chat in chatmasterViewModel.OrderBy(x => x.CreatedDate))
                {
                    var model = new ChatViewModel()
                    {
                        CustomerName = chat.CustomerName,
                        Message = chat.Message,
                        RoomName = chat.RoomName,
                        CreatedDate = chat.CreatedDate.ToString("dd/MM/yyyy HH:mm:ss")
                    };
                    chatViewModel.Add(model);
                }
            }

            return Json(chatViewModel, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public dynamic GetUserId()
        {
            var user = new UserMasterItemViewModel();

            using (var mgr = new CMSLcLy.Data.User.Manager())
            {
                user = mgr.getUser(User.Identity.Name).ToList().FirstOrDefault();
            }

            if (user == null)
                return Json("", JsonRequestBehavior.AllowGet);

            return Json(user, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpPost]
        public JsonResult SendMessage([FromBody] ChatViewModel model)
        {
            if (model == null)
                return Json("Message Empty!", JsonRequestBehavior.AllowGet);


            chatmasterViewModel viewModel = new chatmasterViewModel();
            viewModel.CustomerName = model.CustomerName;
            viewModel.RoomName = model.RoomName;
            viewModel.Message = model.Message;
            viewModel.CreatedDate = DateTime.Now;
            viewModel.ModifiedDate = DateTime.Now;

            using (var mgr = new CMSLcLy.Data.Chat.Manager())
            {
                var result = mgr.Save(viewModel);
            }

            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public JsonResult GetFileNo()
        {
            var startNo = 1;
            var lastestBatchNo = "";
            using (var mgr = new CMSLcLy.Data.File.Manager())
            {
                lastestBatchNo = mgr.GetLatestBatchNo();
            }

            var fileCount = 0;

            if (lastestBatchNo != "")
            {
                var no = lastestBatchNo.Split('-');
                if(no.Count() > 1)
                {
                    fileCount = Convert.ToInt32(no[1]);
                }
            }

            if (fileCount > 9999)
            {
                startNo += 1;
                fileCount = fileCount - 9999;
            }
            else if (fileCount == 9999)
            {
                startNo += 1;
                fileCount = 1;
            }
            else
            {
                fileCount += 1;
            }

            return Json(startNo.ToString("000") + "-" + fileCount.ToString("0000"), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public JsonResult GetRelatedFileNo(string userID)
        {
            IList<DocumentItemViewModel> documentItemViewModel = null;

            using (var mgr = new CMSLcLy.Data.File.Manager())
            {
                documentItemViewModel = mgr.List(userID).ToList();
            }

            return Json(documentItemViewModel, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public JsonResult GetWorkflowList()
        {
            IList<WorkflowItemViewModel> model = null;

            using (var mgr = new CMSLcLy.Data.Workflow.Manager())
            {
                model = mgr.List().ToList();
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public JsonResult GetBankList()
        {
            IList<bankmasterItemViewModel> model = null;

            using (var mgr = new CMSLcLy.Data.Bank.Manager())
            {
                model = mgr.List().ToList();
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public JsonResult GetBankName(string branchName)
        {
            bankmasterItemViewModel model = null;

            using (var mgr = new CMSLcLy.Data.Bank.Manager())
            {
                model = mgr.GetByBranchName(branchName);
            }

            bankshortcutmasterItemViewModel model1 = null;
            using (var mgr1 = new CMSLcLy.Data.Bank.BankShortCut.Manager())
            {
                model1 = mgr1.Get(model.BankShortCutID);
            }

            return Json(model1, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public JsonResult GetEnumType(string enumType)
        {
            IList<EnumMasterItemViewModel> model = null;

            using (var mgr = new CMSLcLy.Data.EnumMaster.Manager())
            {
                model = mgr.List(enumType).ToList();
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }

    }
}