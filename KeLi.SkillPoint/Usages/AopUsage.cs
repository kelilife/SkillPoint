using System;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;

namespace KeLi.SkillPoint.Usages
{
    internal class AopUsage : IAnalyzers
    {
        public void ShowResult()
        {
            var test = new TestAopClass();

            Console.WriteLine();
            test.Hello();

            Console.WriteLine();
            test.Output("Test");
        }
    }

    [AopProxy]
    internal class TestAopClass : ContextBoundObject
    {
        public string Hello()
        {
            return nameof(Hello);
        }

        public void Output(string name)
        {
            Console.WriteLine(name);
        }
    }

    public class AopProxyAttribute : ProxyAttribute
    {
        public override MarshalByRefObject CreateInstance(Type serverType)
        {
            return new AopRealProxy(serverType).GetTransparentProxy() as MarshalByRefObject;
        }
    }

    public class AopRealProxy : RealProxy
    {
        public AopRealProxy(Type serverType) : base(serverType)
        {
        }

        public override IMessage Invoke(IMessage message)
        {
            if (message is IConstructionCallMessage callMessage)
            {
                var result = InitializeServerObject(callMessage);

                SetStubData(this, result.ReturnValue);

                return result;
            }

            if (message is not IMethodCallMessage methodMsg)
                return null;

            try
            {
                Console.Write("Before: ");
                Console.WriteLine(methodMsg.MethodName);

                var args = methodMsg.Args;
                var result = methodMsg.MethodBase.Invoke(GetUnwrappedServer(), args);

                if (result is not null)
                    Console.WriteLine(result);

                Console.Write("After: ");
                Console.WriteLine(methodMsg.MethodName);

                message = new ReturnMessage(result, args, args.Length, methodMsg.LogicalCallContext, methodMsg);
            }
            catch (Exception e)
            {
                message = new ReturnMessage(e, methodMsg);
            }

            return message;
        }
    }
}