using AutoMapper;
using MerchantMVC.Models;
using MerchantMVC.Repositories;
using MerchantMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using System.Net.Sockets;
using static Humanizer.In;
using System.Xml.Linq;

namespace MerchantMVC.Controllers
{
    public class VirtualTerminalController : Controller
    {
        private IVirtualTerminalRepository _virtualTerminalRepository;
        
        public VirtualTerminalController(IVirtualTerminalRepository virtualTerminalRepository)
        {
            _virtualTerminalRepository = virtualTerminalRepository;
        }
        public ActionResult Index()
        {
            var vm = _virtualTerminalRepository.CreateVirtualTerminal((int)HttpContext.Session.GetInt32("MerchantId"));

            return View(vm);
        }

        [HttpPost]
        public ActionResult Submit(VirtualTerminalViewModel viewModel)
        {
            var response = TransactionToXml(viewModel);

            if (response != null)
            {
                ViewBag.Message = "Transaction submitted successfully.";
            }
            else
            {
                ViewBag.Message = "Please verify transaction details.";
            }

            return View("Index", viewModel);
        }

        [HttpGet]
        public JsonResult GetTerminals(int locationID)
        {
                var terminals = _virtualTerminalRepository.GetTerminals(locationID).ToList();
                var json = terminals.Select(x => new { id = x.Terminal30Id, text = x.TermDescrip });

                return Json(json);
        }

        [HttpGet]
        public JsonResult GetCardTypes(int terminalID)
        {
            var cardtypes = _virtualTerminalRepository.GetCardTypes(terminalID).ToList();
            var json = cardtypes.Select(x => new { id = x.CardTypeId, text = x.CardTypeName });

            return Json(json);
        }

        [HttpGet]
        public JsonResult GetTransCodes(int terminalID)
        {
            var cardtypes = _virtualTerminalRepository.GetTransCodes(terminalID).ToList();
            var json = cardtypes.Select(x => new { id = x.TranCode, text = x.TranCodeName });

            return Json(json);
        }

        #region "XML functions"
        public static string TransactionToXml(VirtualTerminalViewModel viewModel)
        {
            using (EbaseDBContext dBContext = new EbaseDBContext())
            {
                viewModel.Terminal = dBContext.Terminals.Where(x => x.Terminal30Id == viewModel.Terminal30ID).FirstOrDefault();
            }

            string sessionID = Guid.NewGuid().ToString().ToUpper();
            string tid = viewModel.Terminal.TId.ToString();
            string amount = viewModel.Amount.ToString();
            string tranTypeID = viewModel.CardTypeID.ToString();
            string tranCode = viewModel.TransCodeID.ToString();
            string comments = viewModel.TransactionComments;
            string acctID = viewModel.CardAccountNumber.ToString();
            string refID = viewModel.ReferenceID.ToString();
            string refCatID = viewModel.ReferenceType.ToString();

            XElement xmlTransaction = new XElement("EDC",
                new XAttribute("Type", "TransactionRequest"),
                new XElement("CustLoginID", "tcraig"),
                new XElement("Pswd", "p@ssword1"),
                new XElement("RqUID", sessionID),
                new XElement("TerminalID", tid),
                new XElement("CurAmt", amount),
                new XElement("TranTypeID", tranTypeID),
                new XElement("TrnCode", tranCode),
                new XElement("Memo", comments),
                new XElement("CardAcctID",
                    new XElement("AcctID", acctID)
                ));

            if (!String.IsNullOrEmpty(refCatID))
            {
                xmlTransaction.Add(new XElement("ReferenceID", refID));
                xmlTransaction.Add(new XElement("ReferenceCategoryID", refCatID));
            }

            var xmlString = xmlTransaction.ToString();

            var IP = "172.31.4.10";
            var Port = 55200;

            return SendXmlTransaction(IP, Port, xmlString);
        }

        public static string SendXmlTransaction(string IP, int Port, string message)
        { 
            StringBuilder responseMessage = new StringBuilder();

            try
            {
                int ETX = 3;
                message += (char)ETX;
                TcpClient client = new TcpClient(IP, Port);
                NetworkStream stream = client.GetStream();

                Byte[] data = Encoding.ASCII.GetBytes(message);
                stream.Write(data, 0, data.Length);
                int bytesRead = 0;

                do
                {
                    bytesRead = stream.Read(data, 0, data.Length);
                    responseMessage.AppendFormat("{0}", Encoding.ASCII.GetString(data, 0, bytesRead));
                }

                while (stream.DataAvailable);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                //TO-DO: Log error
                throw;                
            }

            return responseMessage.ToString();
        }

#endregion
    }
}
