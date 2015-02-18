using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FixturesVer1.Models
{
    public class ConversationReply
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConversationReplyId { get; set; }
        public string message { get; set; }
        public string usr_Username { get; set; }
        public DateTime? timestamp { get; set; }
        public bool isRead { get; set; }
        public int ConversationId { get; set; }
        public Conversation ConversationObj { get; set; }
    }
}