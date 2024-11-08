using System;
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
                //foreach (var value in prop.CustomAttributes.Any())
                {
                    prop.CustomAttributes.Any((a) => { return a.AttributeType.Name == "cc"; });
                    //if (prop.Attributes. == null) ;
                }
            }

            return vm;
        }
    }
}
