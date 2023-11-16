using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.Jwt;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

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

        builder.RegisterType<ProductSizeManager>().As<IProductSizeService>().InstancePerLifetimeScope();
        builder.RegisterType<EfProductSizeDal>().As<IProductSizeDal>().InstancePerLifetimeScope();

        builder.RegisterType<OrderManager>().As<IOrderService>();
        builder.RegisterType<EfOrderDal>().As<IOrderDal>();


        builder.RegisterType<EfProductColorDal>().As<IProductColorDal>();

        builder.RegisterType<UserManager>().As<IUserService>();
        builder.RegisterType<EfUserDal>().As<IUserDal>();

        builder.RegisterType<AuthManager>().As<IAuthService>();
        builder.RegisterType<JwtHelper>().As<ITokenHelper>();


        var assembly = System.Reflection.Assembly.GetExecutingAssembly();

        builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().SingleInstance();
    }
}