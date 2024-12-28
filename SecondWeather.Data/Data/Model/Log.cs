using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondWeather.Data.Data.Model
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        [MaxLength(128)]
        public string? Source { get; set; }
    }
}
