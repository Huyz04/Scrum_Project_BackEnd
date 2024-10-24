﻿namespace ScrumBackEnd.Dto
{
    public class RegisterCampaignDto
    {
        public string Name { get; set; } = string.Empty;
        public string SDT { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string SDTParent { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public string Aim { get; set; } = string.Empty;
        public string MSSV { get; set; } = string.Empty;
        public Guid CampaignId  { get; set; } 
    }
}
