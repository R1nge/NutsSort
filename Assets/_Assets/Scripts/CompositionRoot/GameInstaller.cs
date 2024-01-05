using _Assets.Scripts.Gameplay;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.CompositionRoot
{
    public class GameInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<RewindService>(Lifetime.Singleton);
            builder.Register<BoltMoverService>(Lifetime.Singleton);
        }
    }
}