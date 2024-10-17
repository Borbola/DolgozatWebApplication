using DolgozatWebApplication.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DolgozatWebApplication.Entities
{
    public class Computer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [StringLength(255)]
        public int Capacity {  get; set; }
        public int UserId { get; set; }
    }
}
