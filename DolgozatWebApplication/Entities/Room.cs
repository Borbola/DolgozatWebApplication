using DolgozatWebApplication.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DolgozatWebApplication.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [StringLength(255)]
        public DateTime ManufactureDate { get; set; }
        public int RoomId { get; set; }
    }
}
