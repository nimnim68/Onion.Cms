using System;
using System.Collections.Generic;

namespace Onion.Cms.Framework.Helper
{
    public static class ObjectExtension
    {
        private static List<KeyValuePair<string, string>> ToKeyValuePair(object obj, bool canNullValue, bool listMode,
            int itemNumber = 0)
        {
            if (obj == null) return null;
            var items = new List<KeyValuePair<string, string>>();
            var propertyInfos = obj.GetType().GetProperties();
            foreach (var item in propertyInfos)
            {
                string key = item.Name;
                if (Char.IsUpper(key[0])) key = Char.ToLower(key[0]) + item.Name.Substring(1);
                if (listMode) key += $"[{itemNumber}]";

                var value = item.GetValue(obj, null);
                if (value is IEnumerable<string>)
                {
                    var convertedValue = value as IEnumerable<string>;
                    foreach (var valItem in convertedValue)
                    {
                        items.Add(new KeyValuePair<string, string>(key, valItem.ToString()));
                    }
                }
                else if (value != null || canNullValue)
                {
                    items.Add(new KeyValuePair<string, string>(key, value?.ToString()));
                }
            }
            return items;
        }

        public static List<KeyValuePair<string, string>> ToKeyValuePair(this object obj)
        {
            return ToKeyValuePair(obj, false, false);
        }
    }
}