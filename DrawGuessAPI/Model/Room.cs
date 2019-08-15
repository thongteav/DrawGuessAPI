using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrawGuessAPI.Model
{
    public partial class Room
    {
        public Room()
        {
            Message = new HashSet<Message>();
            PlayerRoom = new HashSet<PlayerRoom>();
        }

        [Column("roomId")]
        public int RoomId { get; set; }
        [Required]
        [Column("roomName")]
        [StringLength(255)]
        public string RoomName { get; set; }
        [Required]
        [Column("roomType")]
        [StringLength(15)]
        public string RoomType { get; set; }
        [Column("roomPin")]
        [StringLength(255)]
        public string RoomPin { get; set; }
        [Column("maxPlayers")]
        public int MaxPlayers { get; set; }
        [Column("drawing")]
        public string Drawing { get; set; }
        [Column("answer")]
        [StringLength(255)]
        public string Answer { get; set; }

        [InverseProperty("Room")]
        public virtual ICollection<Message> Message { get; set; }
        [InverseProperty("Room")]
        public virtual ICollection<PlayerRoom> PlayerRoom { get; set; }
    }
}
