using Autofac;
using Autofac.Unity;
using Strawhenge.Builder.Unity;
using Strawhenge.Builder.Unity.Blueprints;
using UnityEngine;

public static class DependencyInjection
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Configure()
    {
        AutofacUnity.Configure(builder =>
        {
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
        });
    }
}
