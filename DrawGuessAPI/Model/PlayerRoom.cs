using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrawGuessAPI.Model
{
    public partial class PlayerRoom
    {
        [Column("playerId")]
        public int PlayerId { get; set; }
        [Column("roomId")]
        public int RoomId { get; set; }
        [Required]
        [Column("playerRole")]
        [StringLength(10)]
        public string PlayerRole { get; set; }
        [Column("playerScore")]
        public int PlayerScore { get; set; }
        [Column("canDraw")]
        public bool? CanDraw { get; set; }

        [ForeignKey("PlayerId")]
        [InverseProperty("PlayerRoom")]
        public virtual Player Player { get; set; }
        [ForeignKey("RoomId")]
        [InverseProperty("PlayerRoom")]
        public virtual Room Room { get; set; }
    }
}
