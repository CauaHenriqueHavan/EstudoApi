using Xunit;

namespace estudo.tests.Configurations
{
    [CollectionDefinition(nameof(InMemoryCollection))]
    public class InMemoryCollection : ICollectionFixture<InMemoryBaseFixture>
    {
    }
}
