using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MyWeb.Areas.Administrator.Models
{
    public class Seo
    {
        public static string Translate(string phrase)
        {
            string trans = phrase.ToLower();

            trans = trans.Replace("ç", "c").Replace("ı", "i").Replace("ş", "s").Replace("ğ", "g").Replace("ö", "o").Replace("ü", "u");

            // invalid chars, make into spaces
            trans = Regex.Replace(trans, @"[^a-z0-9\s-]", "");
            // convert multiple spaces/hyphens into one space       
            trans = Regex.Replace(trans, @"[\s-]+", " ").Trim();
            // cut and trim it
            trans = trans.Substring(0, trans.Length <= 100 ? trans.Length : 100).Trim();
            // hyphens
            trans = Regex.Replace(trans, @"\s", "-");

            return trans;
        }

        static Seo()
        {

        }
    }
}