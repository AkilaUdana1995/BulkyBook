using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models
    {
    public class Product
        {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Range(1, 100000)]
        [DisplayName("List Price")]
        public double ListPrice { get; set; }

        [Required]
        [Range(1, 100000)]
        public double Price { get; set; }

        [Required]
        [Range(1, 100000)]
        [DisplayName("51 -100 pcs Price")]

        public double Price50 { get; set; }

        [Required]
        [Range(1, 100000)]
        [DisplayName("100+ per order")]
        public double Price100 { get; set; }

        [Required]
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        [Required]
        [DisplayName("Cover Type")]
        public int CoverTypeId { get; set; }
        [ForeignKey("CoverTypeId")]
        [ValidateNever]
        public CoverType CoverType { get; set; }

        [ValidateNever]
        public string ImageURL { get; set; }
        }
    }
