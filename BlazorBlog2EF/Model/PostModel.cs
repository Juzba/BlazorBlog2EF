using System.ComponentModel.DataAnnotations;
using BlazorBlog2EF.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;

namespace BlazorBlog2EF.Model
{
    public class PostModel
    {
        public int Id { get; set; }
        public string? Autor { get; set; }

        [Required(ErrorMessage = "Zadej titulek!")]
        public string? Title { get; set; }

        public DateTime DateT { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Zadej text!")]
        public string? Text { get; set; }

        public bool IsOnTop { get; set; }
    }


}
