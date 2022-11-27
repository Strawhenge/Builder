using Autofac;
using Autofac.Unity;
using Strawhenge.Builder.Unity;
using UnityEngine;

public static class DependencyInjection
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Configure()
    {
        AutofacUnity.Configure(builder =>
        {
            builder
                .RegisterType<BlueprintRepository>()
                .AsSelf()
                .As<IBlueprintRepository>()
                .InstancePerLifetimeScope();
        });
    }
}
