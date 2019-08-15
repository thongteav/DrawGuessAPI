using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrawGuessAPI.Model
{
    public partial class Message
    {
        [Column("messageId")]
        public int MessageId { get; set; }
        [Column("playerId")]
        public int? PlayerId { get; set; }
        [Column("roomId")]
        public int? RoomId { get; set; }
        [Required]
        [Column("content")]
        [StringLength(255)]
        public string Content { get; set; }

        [ForeignKey("PlayerId")]
        [InverseProperty("Message")]
        public virtual Player Player { get; set; }
        [ForeignKey("RoomId")]
        [InverseProperty("Message")]
        public virtual Room Room { get; set; }
    }
}
