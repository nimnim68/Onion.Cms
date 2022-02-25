﻿using System.Collections.Generic;

namespace Onion.Cms.Domain.DTOs.Site.Common
{
    public class MenuDto
    {
        public long Id { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public List<MenuDto> Child { get; set; }
        
    }
}