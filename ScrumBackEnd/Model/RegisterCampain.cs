﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ScrumBackEnd.Model
{
    [Table("RegisterCampain")]
    public class RegisterCampain
    {
        public Guid Id { get; set; }
        public Guid CampaignId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string SDT { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string SDTParent { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public string Aim { get; set; } = string.Empty;
        public string MSSV {  get; set; } = string.Empty;   
    }
}
