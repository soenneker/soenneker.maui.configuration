using Soenneker.Tests.HostedUnit;

namespace Soenneker.Maui.Configuration.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class MauiConfigurationUtilTests : HostedUnitTest
{
    public MauiConfigurationUtilTests(Host host) : base(host)
    {

    }

    [Test]
    public void Default()
    {

    }
}
