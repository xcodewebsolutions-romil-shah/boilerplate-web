using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Boilerplate.Infrastructure.Dtos;
using Boilerplate.Infrastructure.Utilities;
using Boilerplate.Services.Contracts;
using Boilerplate.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.Web.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly IAccountTransactionService accountTransactionService;
        public TransactionsController(IAccountTransactionService _accountTransactionService)
        {
            accountTransactionService = _accountTransactionService;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Account Transactions";
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Modify(Guid transactionID)
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult GetTransactions()
        {
            try
            {
                var data = accountTransactionService.GetData();

                var listResponse = new ListResponseDto<AccountTransactionListDto>(data, new List<string> {
                $"<a href=\"/Transactions/Modify/{{0}}\"><i class=\"fa fa-pencil-alt\"></i></a>"
                });

                return PartialView("~/Views/Shared/_TabularPartial.cshtml", listResponse);
            }
            catch (Exception ex)
            {
                return PartialView("~/Shared/Error", ex);
            }
        }

        [HttpPost]
        public JsonResult CreateOrUpdateTransaction()
        {
            return Json(true);
        }
    }
}