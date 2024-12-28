using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondWeather.Data.Data.Model
{
    public class UserSettings
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(128)]
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
