using Microsoft.Extensions.DependencyInjection;
using Servicio.Core.Business.Interfaces;
using Servicio.Core.Business.Mantenimiento;
using Servicio.Core.Data.BDMantenimiento;
using Servicio.Core.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicio.Core.Venta.ConfigService
{
    public static class IoC
    {
        //IoC (Intersion Of Control)
        //Registro de los metodos para ser usados por las interfaces (inyeccion de dependencias)
        public static IServiceCollection AddRegistration(this IServiceCollection service)
        {
            service.AddSingleton<IServiceCliente, ServiceCliente>();
            service.AddSingleton<IDataCliente, DataCliente>();

            service.AddSingleton<IServiceUsuario, ServiceUsuario>();
            service.AddSingleton<IDataUsuario, DataUsuario>();

            service.AddSingleton<IServiceConceptoVenta, ServiceConceptoVenta>();
            service.AddSingleton<IDataConceptoVenta, DataConceptoVenta>();

            service.AddSingleton<IServiceEmpleado, ServiceEmpleado>();
            service.AddSingleton<IDataEmpleado, DataEmpleado>();

            service.AddSingleton<IServiceProducto, ServiceProducto>();
            service.AddSingleton<IDataProducto, DataProducto>();

            service.AddSingleton<IServiceVenta, ServiceVenta>();
            service.AddSingleton<IDataVenta, DataVenta>();

            service.AddSingleton<IServiceParametro, ServiceParametro>();
            service.AddSingleton<IDataParametro, DataParametro>();

            service.AddSingleton<IServiceReport, ServiceReport>();
            service.AddSingleton<IDataReport, DataReport>();

            return service;
        }
    }
}
