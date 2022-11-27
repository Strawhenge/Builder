using Autofac;
using Autofac.Unity;
using Strawhenge.Builder.Menu;
using Strawhenge.Builder.Unity;
using Strawhenge.Builder.Unity.Blueprints;
using Strawhenge.Builder.Unity.ScriptableObjects;
using Strawhenge.Common.Unity;
using UnityEngine;
using ILogger = Strawhenge.Common.Logging.ILogger;

public static class DependencyInjection
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Configure()
    {
        AutofacUnity.Configure(builder =>
        {
            builder
                .RegisterType<UnityLogger>()
                .As<ILogger>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<BuilderManager>()
                .AsSelf()
                .SingleInstance();

            builder
                .RegisterType<BlueprintFactory>()
                .As<IBlueprintFactory>()
                .SingleInstance();

            builder
                .RegisterType<BlueprintRepository>()
                .AsSelf()
                .As<IBlueprintRepository>()
                .SingleInstance();

            builder
                .RegisterType<BlueprintScriptableObjectMenu>()
                .As<IBlueprintScriptableObjectMenu>()
                .SingleInstance();

            builder
                .RegisterType<MenuItemsFactory<BlueprintScriptableObject>>()
                .AsSelf()
                .SingleInstance();

            builder
                .RegisterType<BuilderMenu>()
                .AsSelf()
                .SingleInstance();

            builder
                .RegisterType<MenuView>()
                .AsSelf()
                .As<IMenuView>()
                .SingleInstance();
        });
    }
}
