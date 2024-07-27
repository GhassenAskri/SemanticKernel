using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;

namespace EmailAgent;

public static class KernelBuilder
{
    private static readonly IKernelBuilder _kernelBuilder = Kernel.CreateBuilder();

    public static Kernel BuildWithSkill<T>(T skill)
    {
        _kernelBuilder.Plugins.AddFromType<T>();
        return _kernelBuilder.Build();
    }

    public static void Build() => _kernelBuilder.Build();
    
    
}