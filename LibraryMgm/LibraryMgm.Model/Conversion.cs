using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;

namespace LibraryMgm.Model.Conversion
{
    public static class Conversion
    {
        public static T ToViewModel<T>(this SqlDataReader reader)
        {
            T vm;
            var classType = typeof(T);
            vm = (T)Activator.CreateInstance(classType);

            var objType = vm.GetType();
            var props = objType.GetProperties();

            foreach (var prop in props)
            {
                var notMap = prop.CustomAttributes.Any(a => a.AttributeType.Name == nameof(NotMappedAttribute));
                if (notMap)
                    continue;
                try
                {
                    prop.SetValue(vm, reader[prop.Name]);
                }
                catch { }
            }

            return vm;
        }
    }
}
