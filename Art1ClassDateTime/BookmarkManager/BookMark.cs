﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BookmarkManager
{
    class BookMark
    {
        public BookMark(string naam, string url)
        { 
            Naam = naam;
            URL = url;
        }
        public string Naam { get; set; }
        public string URL { get; set; }
        public void OpenSite()
        {
            Process.Start(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe", URL);
        }
    }
}
