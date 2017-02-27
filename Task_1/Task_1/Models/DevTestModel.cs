using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Task_1.Models
{
    public class DevTest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Compaign name")]
		[StringLength(255, ErrorMessage = "CampaignName cannot be longer than 255 characters.")]
		public string CampaignName { get; set; }

        public Nullable<DateTime> Date { get; set; }

        
        [Display(Name = "Clicks")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Only number allowed.")]
        public string Clicks { get; set; }

        
        [Display(Name = "Conversions")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Only number allowed.")]
        public string Conversions { get; set; }

        
        [Display(Name = "Impressions")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Only number allowed.")]
        public string Impressions { get; set; }

        
        [Display(Name = "Affiliate name")]
		[StringLength(255, ErrorMessage = "AffiliateName cannot be longer than 255 characters.")]
		public string AffiliateName { get; set; }
    }
}