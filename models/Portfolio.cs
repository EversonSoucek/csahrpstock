using System.ComponentModel.DataAnnotations.Schema;
using api.models;

namespace csahrpstock.models
{
    [Table("Portfolio")]
    public class Portfolio
    {
        public string AppUserId { get; set; }
        public int StockId {get; set;}
        public AppUser AppUser { get; set; }
        public Stock Stock { get; set; }
    }
}