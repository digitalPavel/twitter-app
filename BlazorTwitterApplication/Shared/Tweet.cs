using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTwitterApplication.Shared
{
    public  class Tweet
    {
        public string[] edit_history_tweet_ids { get; set; }
        public string id { get; set; }
        public string text { get; set; }
    }
}
