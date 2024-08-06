using AutoMapper;
using Boilerplate.Infrastructure.AnnotationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Boilerplate.Infrastructure.Utilities
{
    public static class Shared
    {
        public static Mapper AutoMapperInstance<Source, Target>()
        {
            var _map = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Source, Target>();
            }));
            return _map;
        }

        public static PropertyInfo GetKeyNameField<T>()
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            Dictionary<string, string> displayFields = new Dictionary<string, string>();

            foreach (PropertyInfo property in properties)
            {
                KeyAttribute obj = property.GetCustomAttribute(typeof(KeyAttribute), true) as KeyAttribute;
                if (obj != null)
                {
                    return property;
                }
            }

            return null;
        }


        public static Dictionary<string, string> GetDisplayNameFields<T>(bool hasActionColumn)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            Dictionary<string, string> displayFields = new Dictionary<string, string>();

            if (hasActionColumn == true)
            {
                displayFields.Add("Action", "Action");
            }

            Dictionary<string, List<KeyValuePair<string, dynamic>>> propertyInfo = new Dictionary<string, List<KeyValuePair<string, dynamic>>>();

            foreach (PropertyInfo property in properties)
            {
                DisplayNameAttribute obj = property.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>().SingleOrDefault();
                DisplayOrderAttribute displayOrderAttr = property.GetCustomAttributes(typeof(DisplayOrderAttribute), true).Cast<DisplayOrderAttribute>().SingleOrDefault();
                if (obj != null)
                {
                    propertyInfo.Add(property.Name, new List<KeyValuePair<string, dynamic>> {
                    new KeyValuePair<string, dynamic>("DisplayOrder",displayOrderAttr == null ? 999 : displayOrderAttr.DisplayOrder),
                    new KeyValuePair<string, dynamic>("DisplayName",obj.DisplayName)
                    });
                }
            }

            foreach (var property in propertyInfo.OrderBy(o => o.Value[0].Value).ToList())
            {
                displayFields.Add(property.Key, property.Value[1].Value);
            }

            return displayFields;
        }

    }
}
