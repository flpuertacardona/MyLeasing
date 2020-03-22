using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyLeasing.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboPropertyTypes();
        IEnumerable<SelectListItem> GetComboBusinessTypes();
        IEnumerable<SelectListItem> GetComboLessees();
        IEnumerable<SelectListItem> GetComboAgents();
        IEnumerable<SelectListItem> GetComboRoles();
    }
}