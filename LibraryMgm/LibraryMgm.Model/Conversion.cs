using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;

namespace LibraryMgm.Model.Conversion
{
    public static class Conversion
    {
        public static List<T> ToListViewModel<T>(this SqlDataReader reader)
        {
            T vm;
            var classType = typeof(T);
            vm = (T)Activator.CreateInstance(classType);

            var objType = vm.GetType();
            var props = objType.GetProperties();

            var vmList = new List<T>();

            while (reader.Read())
            {
                vm = (T)Activator.CreateInstance(classType);
                vmList.Add(vm);
                foreach (var prop in props)
                {
                    var notMap = prop.CustomAttributes.Any(a => a.AttributeType.Name == nameof(NotMappedAttribute));
                    if (notMap)
                        continue;
                    else
                    {
                        try
                        {
                            prop.SetValue(vm, reader[prop.Name]);
                        }
                        catch { }
                    }
                }
            }
            return vmList;
        }

        public static SqlParameter[] ToSqlParameters<T>(T model)
        {
            var param = new List<SqlParameter>();
            var type = model.GetType();
            foreach (var prop in type.GetProperties())
            {
                param.Add(
                    new SqlParameter($"@{prop.Name}",
                    prop.GetValue(model)));
            }
            return param.ToArray();
        }
    }
}
