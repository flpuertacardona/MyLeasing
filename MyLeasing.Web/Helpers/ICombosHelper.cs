using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MyLeasing.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboPropertyTypes();
        IEnumerable<SelectListItem> GetComboBusinessTypes();
        IEnumerable<SelectListItem> GetComboLessees();
        IEnumerable<SelectListItem> GetComboAgents();
    }
}