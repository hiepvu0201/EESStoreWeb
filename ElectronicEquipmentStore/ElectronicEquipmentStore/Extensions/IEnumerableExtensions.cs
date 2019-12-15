
using ElectronicEquipmentStore.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicEquipmentStore.Extensions
{
    public static class IEnumerableExtensions
    {
        //This for dropdown category
        public static IEnumerable<SelectListItem> ToSelectListItemCategory<T>(this IEnumerable<T> items, string selectedValue)
        {
            return from item in items
                   select new SelectListItem
                   {
                       Text = item.GetPropertyValue("tenDM"),
                       Value = item.GetPropertyValue("maDM"),
                       Selected = item.GetPropertyValue("maDM").Equals(selectedValue)
                   };
        }

        //This for dropdown productgroup
        public static IEnumerable<SelectListItem> ToSelectListItemProductGroup<T>(this IEnumerable<T> items, string selectedValue)
        {
            return from item in items
                   select new SelectListItem
                   {
                       Text = item.GetPropertyValue("tenNSP"),
                       Value = item.GetPropertyValue("maNSP"),
                       Selected = item.GetPropertyValue("maNSP").Equals(selectedValue)
                   };
        }

        //For dropdown which table have value=Id and get Name
        public static IEnumerable<SelectListItem> ToSelectListItemString<T>(this IEnumerable<T> items, string selectedValue)
        {
            if(selectedValue==null)
            {
                selectedValue = "";
            }

            return from item in items
                   select new SelectListItem
                   {
                       Text = item.GetPropertyValue("Name"),
                       Value = item.GetPropertyValue("Id"),
                       Selected = item.GetPropertyValue("Id").Equals(selectedValue.ToString())
                   };
        }

    }
}