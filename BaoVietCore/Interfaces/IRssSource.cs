﻿using BaoVietCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoVietCore.Interfaces
{
    public interface IRssSource
    {
        Task<RssResult> GetFeed(string url);
    }

    public class RssResult
    {
        public IEnumerable<IFeedItem> Feeds { get; set; }
        public PaperType Paper { get; set; }
    }
}
