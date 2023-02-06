using Microsoft.AspNetCore.DiagnosticsViewPage.Views;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiGIn.Models
{
    public class ModalContainerViewModel
    {
        public String Caption { get; set; }
        public String Name { get; set; }
        public Int32 Width { get; set; }
        public Func<object, object> Content { get; set; }
    }
}