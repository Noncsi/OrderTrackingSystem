using Microsoft.EntityFrameworkCore;
using OrderTrackingApp.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace OrderTrackingApp.Helpers
{
    public static class DownloadItems
    {
        private static string fullHTML;
        private static string itemUrlBeginning = "https://www.arukereso.hu/mobiltelefon-c3277/samsung/";
        private static string endString = "/\" data-akl2pp";

        private static List<string> pages = new List<string>() {
                "https://www.arukereso.hu/mobiltelefon-c3277/f:samsung,erintokepernyo/",
                "https://www.arukereso.hu/mobiltelefon-c3277/f:samsung,erintokepernyo/?start=25",
                "https://www.arukereso.hu/mobiltelefon-c3277/f:samsung,erintokepernyo/?start=50",
                "https://www.arukereso.hu/mobiltelefon-c3277/f:samsung,erintokepernyo/?start=75"
            };

        private static List<Item> items;
        public static List<Item> Items
        {
            get
            {
                if (items == null)
                {
                   items = new List<Item>();
                    return items;
                }
                else
                {
                    return items;
                }
            }
            set { }
        }

        public static void DownloadHTML(string page)
        {
            WebRequest request = WebRequest.Create(page);
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            fullHTML = reader.ReadToEnd();
            fullHTML = fullHTML.Remove(0, 200000);
            reader.Close();
            response.Close();
        }

        public static string getBetween(string strStart, string strEnd)
        {
            if (fullHTML.Contains(strStart) && fullHTML.Contains(strEnd))
            {
                int Start, End;
                Start = fullHTML.IndexOf(strStart, 0) + strStart.Length;
                End = fullHTML.IndexOf(strEnd, Start);
                if (Start > 0 && End > Start)
                {
                    return fullHTML.Substring(Start, End - Start - 11);
                }
            }
            return "";
        }

        private static void FormatStrings()
        {
            foreach (Item item in Items)
            {
                string newName = item.Name.Replace("-", " ");
                newName = new string("samsung " + newName);
                newName = newName.ToUpper();
                item.Name = newName;
            }
        }

        public static void GetItems()
        {
            List<string> itemNames = new List<string>();
            foreach (string page in pages)
            {
                DownloadHTML(page);
                while (fullHTML.Length > itemUrlBeginning.Length)
                {
                    string itemName = getBetween(itemUrlBeginning, endString);

                    if (!itemName.Contains("velemenyek") && itemName != "")
                    {
                        itemNames.Add(itemName);
                    }
                    fullHTML = fullHTML.Remove(0, itemUrlBeginning.Length);
                }
            }
            itemNames = itemNames.Distinct().ToList();
            foreach(string name in itemNames)
            {
                Items.Add(new Item() { Name = name });
            }
            FormatStrings();
        }

        public static void InsertToDB(ApplicationDBContext db)
        {
            if (db.Item.Any())
            {
                return;
            }
            GetItems();
            foreach (Item item in Items)
            {
                db.Item.Add(item);
            }
            db.SaveChanges();
        }
    }
}
