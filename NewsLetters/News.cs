﻿using System.ComponentModel.DataAnnotations;

namespace NewsLetters
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
