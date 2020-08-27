using System;
using System.IO;
using Shouldly;
using Xunit;
using Xunit.Sdk;

namespace mjm.nethelpers.tests
{
    public class DisposableShould
    {
        [Fact]
        public void dispose_resource_after_use()
        {
            var fake = new FakeDisposable();
            var disposable = Disposable.Of(() => fake);
            disposable.Use(fakeDisposable => fakeDisposable.Call());
            
            fake.Disposed.ShouldBeTrue();
        }
    }

    class FakeDisposable : IDisposable
    {
        public bool Disposed { get; private set; }
        
        public void Call(){}
        
        public void Dispose()
        {
            this.Disposed = true;
        }
    }
}