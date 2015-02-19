using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FixturesVer1.Models
{
    public class Conversation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConversationId { get; set; }
        public string Title { get; set; }
        public string UserOne { get; set; }
        public string UserTwo { get; set; }
        public DateTime? TimeStamp { get; set; }
        public bool IsRead { get; set; }
        public IList<ConversationReply> ConversationReplyList { get; set; }
    }
}