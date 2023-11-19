using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;

class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode

    public static int Main () => Execute<Build>(x => x.Publish);

    readonly Configuration Configuration = Configuration.Release;

    [Solution]
    readonly Solution Solution;

    AbsolutePath SrcDirectory => RootDirectory / "src";

    AbsolutePath TemplateAppServerDirectory => SrcDirectory / "TemplateApp.Server";

    AbsolutePath TemplateAppServerProjectFile => TemplateAppServerDirectory / "TemplateApp.Server.csproj";

    AbsolutePath OutputDirectory => RootDirectory / "output";

    Target Clean => _ => _
        .Executes(() =>
        {
            DotNetTasks.DotNetClean(s => s
                .SetProject(Solution)
                .SetConfiguration(Configuration)
                .SetVerbosity(DotNetVerbosity.Minimal)
            );
        });

    Target Restore => _ => _
        .DependsOn(Clean)
        .Executes(() =>
        {
            DotNetTasks.DotNetRestore(s => s
                .SetProjectFile(Solution)
            );
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetTasks.DotNetBuild(s => s
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
            );
        });

    Target Publish => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            OutputDirectory.CreateOrCleanDirectory();

            DotNetTasks.DotNetPublish(s => s
                .SetProject(TemplateAppServerProjectFile)
                .SetConfiguration(Configuration)
                .SetOutput(OutputDirectory / "App")
            );
        });
}
