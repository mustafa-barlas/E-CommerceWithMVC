using Autofac;
using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {

        //builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
        //builder.RegisterType<ProductManager>().As<IProductService>().InstancePerLifetimeScope();
        //builder.RegisterType<ProductManager>().As<IProductService>().InstancePerDependency();


        builder.RegisterType<ProductManager>().As<IProductService>().InstancePerLifetimeScope();
        builder.RegisterType<EfProductDal>().As<IProductDal>().InstancePerLifetimeScope();

        builder.RegisterType<CategoryManager>().As<ICategoryService>().InstancePerLifetimeScope();
        builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().InstancePerLifetimeScope();

        builder.RegisterType<ColorManager>().As<IColorService>().InstancePerLifetimeScope();
        builder.RegisterType<EfColorDal>().As<IColorDal>().InstancePerLifetimeScope();

        builder.RegisterType<OrderManager>().As<IOrderService>();
        builder.RegisterType<EfOrderDal>().As<IOrderDal>();


        builder.RegisterType<UserManager>().As<IUserService>();
        builder.RegisterType<EfUserDal>().As<IUserDal>();

        builder.RegisterType<RoleManager>().As<IRoleService>();
        builder.RegisterType<EfRoleDal>().As<IRoleDal>();

        builder.RegisterType<AccountManager>().As<IAccountService>();
        builder.RegisterType<AccountManager>().AsSelf();

        builder.RegisterType<CityManager>().As<ICityService>();
        builder.RegisterType<EfCityDal>().As<ICityDal>();

        builder.RegisterType<AddressManager>().As<IAddressService>();
        builder.RegisterType<EfAddressDal>().As<IAddressDal>();

        builder.RegisterType<UserForRegisterValidator>().AsSelf().SingleInstance();

        builder.RegisterType<ReportManager>().As<IReportService>();
        builder.RegisterType<EfProductOrderDal>().As<IProductOrderDal>();


        var assembly = System.Reflection.Assembly.GetExecutingAssembly();

        builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().SingleInstance();
    }
}