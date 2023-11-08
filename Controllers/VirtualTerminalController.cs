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
using System.Xml;

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
        public ActionResult Index(VirtualTerminalViewModel viewModel)
        {
            var newVM = _virtualTerminalRepository.CreateVirtualTerminal((int)HttpContext.Session.GetInt32("MerchantId"));

            try
            {
                if (ModelState.IsValid)
                {
                    var response = TransactionToXml(viewModel);

                    if (response.Contains("<Desc>Transaction Authorized Successfully</Desc>"))
                    {
                        ViewBag.Message = "Transaction created successfully.";

                        newVM.LocationID = null;
                        newVM.CardAccountNumber = "";
                        newVM.Amount = null;
                        newVM.TerminalID = null;
                        newVM.CardTypeID = null;
                        newVM.ReferenceID = null;
                    }
                    else
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(response);
                        XmlNodeList list = xmlDoc.GetElementsByTagName("StatusDesc");
                        var msg = list[0].InnerText;

                        ViewBag.Message = String.Format("Unable to process transaction. Error message: {0}", msg);

                        // refill selected values
                        int LocID = (int)viewModel.LocationID;

                        if (LocID != 0)
                        {
                            newVM.LocationID = LocID;
                            newVM.TerminalsList = _virtualTerminalRepository.GetTerminalSelectItems(LocID);
                            newVM.ReferenceID = viewModel.ReferenceID;
                            newVM.ReferenceType = viewModel.ReferenceType;
                            newVM.ReferenceTypeList = _virtualTerminalRepository.GetReferenceTypes();
                        }

                        int TermID = (int)viewModel.TerminalID;

                        if (TermID != 0)
                        {
                            newVM.TerminalID = TermID;
                            newVM.CardTypeList = _virtualTerminalRepository.GetCardTypeSelectItems(TermID);
                            newVM.TransCodeList = _virtualTerminalRepository.GetTransCodeSelectItems(TermID);
                            newVM.CardTypeID = viewModel.CardTypeID;
                            newVM.TransCodeID = viewModel.TransCodeID;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            
            return View(newVM);
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
                viewModel.Terminal = dBContext.Terminals.Where(x => x.Terminal30Id == viewModel.TerminalID).FirstOrDefault();
            }

            string sessionID = Guid.NewGuid().ToString().ToUpper();
            string tid = viewModel.Terminal.TId.ToString();
            string amount = viewModel.Amount.ToString();
            string tranTypeID = viewModel.CardTypeID.ToString();
            string tranCode = viewModel.TransCodeID.ToString();
            string comments = viewModel.TransactionComments;
            string acctID = viewModel.CardAccountNumber.ToString();

            string refID = "";
            string refCatID = "";
            if (viewModel.ReferenceID != null)
                refID = viewModel.ReferenceID.ToString();
            if (viewModel.ReferenceType != null)
                refCatID = viewModel.ReferenceType.ToString();

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
