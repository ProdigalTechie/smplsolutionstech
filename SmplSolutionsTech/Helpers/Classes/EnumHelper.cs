using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace SmplSolutionsTech.Helpers.Classes
{
    public static class EnumHelper
    {
        public static List<SelectListItem> GetSelectList(this Type enumType, bool includeValueInText = false)
        {
            var list = new List<SelectListItem>();
            foreach (var val in Enum.GetValues(enumType))
            {
                list.Add(new SelectListItem { Text = $"{(includeValueInText ? $"{(int)val} - " : string.Empty)}{val.GetDisplayName(enumType)}", Value = $"{(int)val}" });
            }
            return list.OrderBy(x => x.Text).ToList();
        }

        private static string GetDisplayName(this object o, Type enumType)
        {
            if (!Enum.IsDefined(enumType, o)) return null;
            var attr = GetDisplayAttribute(o);
            return attr != null ? attr.GetName() : o.ToString();
        }

        public static string GetDisplayName(this Enum enu)
        {
            var attr = GetDisplayAttribute(enu);
            return attr != null ? attr.GetName() : enu.ToString();
        }

        private static DisplayAttribute GetDisplayAttribute(object value)
        {
            Type type = value.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException(string.Format("Type {0} is not an enum", type));
            }

            // Get the enum field.
            var field = type.GetField(value.ToString());
            return field == null ? null : field.GetCustomAttribute<DisplayAttribute>();
        }

        public static List<SelectListItem> GetSelectListName(this Type enumType)
        {
            var list = new List<SelectListItem>();
            foreach (var val in Enum.GetValues(enumType))
            {
                list.Add(new SelectListItem { Text = $"{val.GetDisplayName(enumType)}", Value = $"{val.GetDisplayName(enumType)}" });
            }
            return list.OrderBy(x => x.Text).ToList();
        }
    }
}
