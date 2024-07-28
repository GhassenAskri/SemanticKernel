using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

namespace EmailAgent;

public static class KernelBuilder
{
    public static readonly IKernelBuilder _kernelBuilder = Kernel.CreateBuilder();

    public static Kernel BuildWithSkill<T>(T skill) where T : class
    {
        _kernelBuilder.Services.AddSingleton<T>();
        _kernelBuilder.Plugins.AddFromType<T>();
        return _kernelBuilder.Build();
    }

    public static void Build() => _kernelBuilder.Build();
}