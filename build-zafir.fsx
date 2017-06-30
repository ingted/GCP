#load "tools/includes.fsx"
open IntelliFactory.Build

let bt =
    BuildTool().PackageId("Zafir.Google.Codeprettify")
        .VersionFrom("Zafir")
        .WithFSharpVersion(FSharpVersion.FSharp30)
        .WithFramework(fun f -> f.Net40)

let main =
    bt.Zafir.Extension("WebSharper.Google.Codeprettify")
        .SourcesFromProject()
        .Embed([])
        .References(fun r -> [])

let tests =
    bt.Zafir.SiteletWebsite("WebSharper.Google.Codeprettify.Tests")
        .SourcesFromProject()
        .Embed([])
        .References(fun r ->
            [
                r.Project(main)
                r.NuGet("Zafir.Testing").Latest(true).Reference()
                r.NuGet("Zafir.UI.Next").Latest(true).Reference()
            ])

bt.Solution [
    main
    tests

    bt.NuGet.CreatePackage()
        .Configure(fun c ->
            { c with
                Title = Some "WebSharper.Google.Codeprettify"
                LicenseUrl = Some "http://websharper.com/licensing"
                ProjectUrl = Some "https://github.com/intellifactory/[3;2~https://github.com/google/code-prettify"
                Description = "Google's code prettify for WebSharper"
                RequiresLicenseAcceptance = true })
        .Add(main)
]
|> bt.Dispatch
