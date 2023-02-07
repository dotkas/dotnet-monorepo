// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Tools.Properties;

namespace Microsoft.EntityFrameworkCore.Tools.Commands;

// ReSharper disable once ArrangeTypeModifiers
internal partial class DbContextOptimizeCommand
{
    protected override int Execute(string[] args)
    {
        if (new SemanticVersionComparer().Compare(EFCoreVersion, "6.0.0") < 0)
        {
            throw new CommandException(Resources.VersionRequired("6.0.0"));
        }

        using var executor = CreateExecutor(args);
        executor.OptimizeContext(
            _outputDir!.Value(),
            _namespace!.Value(),
            Context!.Value());

        return base.Execute(args);
    }
}
