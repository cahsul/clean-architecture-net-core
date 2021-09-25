using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Extensions
{

    public static class ApplyAllConfigurationsFromNameSpaceExtension
    {

        // source : https://www.it-swarm-id.com/id/c%23/mendaftar-secara-massal-ientitytypeconfiguration-inti-kerangka-entitas/835855220/
        public static void ApplyAllConfigurationsFromNameSpace(this ModelBuilder modelBuilder, string configNamespace = "")
        {
            var applyGenericMethods = typeof(ModelBuilder).GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            var applyGenericApplyConfigurationMethods = applyGenericMethods.Where(m => m.IsGenericMethod && m.Name.Equals("ApplyConfiguration", StringComparison.OrdinalIgnoreCase));
            var applyGenericMethod = applyGenericApplyConfigurationMethods.Where(m => m.GetParameters().FirstOrDefault().ParameterType.Name == "IEntityTypeConfiguration`1").FirstOrDefault();


            var applicableTypes = Assembly.GetExecutingAssembly().GetTypes().Where(c => c.IsClass && !c.IsAbstract && !c.ContainsGenericParameters);

            if (!string.IsNullOrEmpty(configNamespace))
            {
                applicableTypes = applicableTypes.Where(c => c.Namespace == configNamespace);
            }

            foreach (var type in applicableTypes)
            {
                foreach (var iface in type.GetInterfaces())
                {
                    // if type implements interface IEntityTypeConfiguration<SomeEntity>
                    if (iface.IsConstructedGenericType && iface.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                    {
                        // make concrete ApplyConfiguration<SomeEntity> method
                        var applyConcreteMethod = applyGenericMethod.MakeGenericMethod(iface.GenericTypeArguments[0]);
                        // and invoke that with fresh instance of your configuration type
                        applyConcreteMethod.Invoke(modelBuilder, new object[] { Activator.CreateInstance(type) });
                        Console.WriteLine("applied model " + type.Name);
                        break;
                    }
                }
            }
        }
    }
}
