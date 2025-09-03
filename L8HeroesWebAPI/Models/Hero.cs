using System;
using System.ComponentModel.DataAnnotations;

namespace L8HeroesWebAPI.Models
{
	public class Hero
	{
        [Key]

        public int Id { get; set; }
        public string name { get; set; }
        public string powers { get; set; }
    }
}

