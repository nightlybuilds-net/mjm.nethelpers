using System;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace mjm.nethelpers.tests
{
    public class RunnerHelperShould
    {
        [Fact]
        public void RunExceptionHandlerIfRunFail()
        {
            var exceptionThrowed = false;
            RunnerHelper.RunAndManageException(() => throw new Exception(), exception => exceptionThrowed = true);
            exceptionThrowed.ShouldBeTrue();
        }
        
        [Fact]
        public async Task RunExceptionHandlerIfTaskRunFail()
        {
            async Task<bool> TestRunner()
            {
                await Task.Delay(10);
                throw new Exception("123456");
            }

            var exceptionThrowed = false;
            var result = await RunnerHelper.RunAndManageException(TestRunner, exception =>
            {
                exceptionThrowed = true;
                return Task.FromResult(false);
            });
            
            exceptionThrowed.ShouldBeTrue();
            result.ShouldBeFalse();
        }
    }
}