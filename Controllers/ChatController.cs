using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.Models;

namespace TP3_Chats.Controllers
{
    public class ChatController : Controller
    {
        //Récupère liste à jour
        private static List<Chat> chats = Chat.GetMeuteDeChats();

        // GET: Chat
        public ActionResult Index()
        {
            return View(chats); ;
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            var chat = chats.FirstOrDefault(c => c.Id == id);
            if (chat == null)
            {
                return RedirectToAction("Index");
            }

            return View(chat);
        }

       

        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            var chat = chats.FirstOrDefault(c => c.Id == id);
            if (chat == null)
            {
                return RedirectToAction("Index");
            }

            return View(chat);
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var chat = chats.FirstOrDefault(c => c.Id == id);
                if (chat != null)
                {
                    chats.Remove(chat);
                }
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}
