using System.Collections.Generic;

namespace BlazorApp.Web.Models
{
    public class DropdownModel
    {
        public bool IsOpen { get; set; } = false;
    
        public bool ButtonHasFocus { get; set; } = false;
    }

    public class Location
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Property> Properties { get; set; }
    }

    public class Property
    {
        public string ImageUrl { get; set; }
        public int Beds { get; set; }
        public int Baths { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int ReviewCount { get; set; }
        public int Rating { get; set; }
    }
}
