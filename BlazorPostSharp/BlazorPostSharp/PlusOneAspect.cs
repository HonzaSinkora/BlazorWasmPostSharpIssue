using System;
using PostSharp.Aspects;
using PostSharp.Aspects.Advices;
using PostSharp.Serialization;

namespace BlazorApp1.Shared
{
    [PSerializable]
    public class PlusOneAspect : MethodLevelAspect
    {
        [OnMethodInvokeAdvice, SelfPointcut]
        public void IncreaseValue([Argument(0)] int parameter, [ReturnValue] out int returnValue)
        {
            returnValue = parameter + 1;
        }
    }

    [Serializable]
    public class PlusOneAspectOld : MethodInterceptionAspect
    {
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            args.ReturnValue = (int)args.Arguments[0] + 1;
        }
    }
}