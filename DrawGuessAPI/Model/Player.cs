using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrawGuessAPI.Model
{
    public partial class Player
    {
        public Player()
        {
            Message = new HashSet<Message>();
            PlayerRoom = new HashSet<PlayerRoom>();
        }

        [Column("playerId")]
        public int PlayerId { get; set; }
        [Required]
        [Column("playerName")]
        [StringLength(25)]
        public string PlayerName { get; set; }

        [InverseProperty("Player")]
        public virtual ICollection<Message> Message { get; set; }
        [InverseProperty("Player")]
        public virtual ICollection<PlayerRoom> PlayerRoom { get; set; }
    }
}
