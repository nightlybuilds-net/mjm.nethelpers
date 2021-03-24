using System.Reflection;
using mjm.nethelpers.Extensions;
using Shouldly;
using Xunit;

namespace mjm.nethelpers.tests
{
    public class ReflectionHelperShould
    {
        [Fact]
        public void InvokePublicVoidMethod()
        {
            var mock = new ReflectionMock();
            mock.ByReflection().InvokeMethod(nameof(ReflectionMock.PublicMethod));
            
            mock.PublicInvoked.ShouldBeTrue();
        }
        
        [Fact]
        public void InvokeMethodWithReturn()
        {
            var mock = new ReflectionMock();
            var res = mock.ByReflection().InvokeMethod<int>(nameof(ReflectionMock.PublicMethodWithReturn));
            
            res.ShouldBe(1);
            mock.PublicMethodWithReturnInvoked.ShouldBeTrue();
        }
        
        [Fact]
        public void InvokePrivateVoidMethod()
        {
            var mock = new ReflectionMock();
            mock.ByReflection().InvokeMethod("PrivateMethod", BindingFlags.NonPublic|BindingFlags.Instance);
            
            mock.PrivateInvoked.ShouldBeTrue();
        }
        
        [Fact]
        public void InvokePrivateMethodWithReturn()
        {
            var mock = new ReflectionMock();
            var res = mock.ByReflection().InvokeMethod<int>("PrivateMethodWithReturn", BindingFlags.NonPublic|BindingFlags.Instance);
            
            res.ShouldBe(1);
            mock.PrivateMethodWithReturnInvoked.ShouldBeTrue();
        }
        
        [Fact]
        public void GetPublicPropertyValue()
        {
            var mock = new ReflectionMock();
            var res = mock.ByReflection().GetProperty<int>(nameof(ReflectionMock.PublicProperty));
            
            res.ShouldBe(2);
        }
        
        [Fact]
        public void GetPrivatePropertyValue()
        {
            var mock = new ReflectionMock();
            var res = mock.ByReflection().GetProperty<int>("PrivateProperty",BindingFlags.NonPublic|BindingFlags.Instance);
            
            res.ShouldBe(3);
        }
        
        [Fact]
        public void SetPublicPropertyValue()
        {
            var mock = new ReflectionMock();
            mock.ByReflection().SetProperty<int>(nameof(ReflectionMock.PublicProperty), 10);
            
            mock.PublicProperty.ShouldBe(10);
        }
        
        [Fact]
        public void SetPrivatePropertyValue()
        {
            var mock = new ReflectionMock();
            mock.ByReflection().SetProperty<int>("PrivateProperty", 11,BindingFlags.NonPublic|BindingFlags.Instance);
            var res = mock.ByReflection().GetProperty<int>("PrivateProperty",BindingFlags.NonPublic|BindingFlags.Instance);
            
            res.ShouldBe(11);
        }
        
        [Fact]
        public void GetFieldValue()
        {
            var mock = new ReflectionMock();
            var res = mock.ByReflection().GetField<int>("_fieldValue");
            res.ShouldBe(100);
        }
        
        [Fact]
        public void SetFieldValue()
        {
            var mock = new ReflectionMock();
            mock.ByReflection().SetField<int>("_fieldValue",111);
            var res = mock.ByReflection().GetField<int>("_fieldValue");
            res.ShouldBe(111);
        }
    }

    class ReflectionMock
    {
        private int _fieldValue;

        public ReflectionMock()
        {
            this.PublicProperty = 2;
            this.PrivateProperty = 3;
            this._fieldValue = 100;
        }

        public int PublicProperty { get; set; }
        private int PrivateProperty { get; set; }

        public void PublicMethod()
        {
            this.PublicInvoked = true;
        }
        
        private void PrivateMethod()
        {
            this.PrivateInvoked = true;
        }

        public bool PrivateInvoked { get; private set; }

        public int PublicMethodWithReturn()
        {
            this.PublicMethodWithReturnInvoked = true;
            return 1;
        }
        
        private int PrivateMethodWithReturn()
        {
            this.PrivateMethodWithReturnInvoked = true;
            return 1;
        }

        public bool PrivateMethodWithReturnInvoked { get; private set; }

        public bool PublicMethodWithReturnInvoked { get; private set; }

        public bool PublicInvoked { get; private set; }
    }
}