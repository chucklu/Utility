using System;
using System.ComponentModel;
using System.Data;

namespace Utility
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Covert a data row to an instance of specified class
        /// https://stackoverflow.com/a/9200446
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <returns></returns>
        public static T ToType<T>(this DataRow row) where T : new()
        {
            T obj = new T();
            var props = TypeDescriptor.GetProperties(obj);
            foreach (PropertyDescriptor prop in props)
            {
                if (row.Table.Columns.IndexOf(prop.Name) >= 0
                    && row[prop.Name].GetType() == prop.PropertyType)
                {
                    prop.SetValue(obj, row[prop.Name]);
                }
            }
            return obj;
        }

        public static string GetFullName(this Enum myEnum)
        {
            return $"{myEnum.GetType().Name}.{myEnum.ToString()}";
        }
    }
}
