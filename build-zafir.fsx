#load "tools/includes.fsx"
open IntelliFactory.Build

let bt =
    BuildTool().PackageId("WebSharper.Google.CodePrettify")
        .VersionFrom("WebSharper")
        .WithFSharpVersion(FSharpVersion.FSharp30)
        .WithFramework(fun f -> f.Net40)

let main =
    bt.WebSharper4.Extension("WebSharper.Google.CodePrettify")
        .SourcesFromProject()
        .Embed([])
        .References(fun r -> [])

let tests =
    bt.WebSharper4.SiteletWebsite("WebSharper.Google.CodePrettify.Tests")
        .SourcesFromProject()
        .Embed([])
        .References(fun r ->
            [
                r.Project(main)
                r.NuGet("WebSharper.Testing").Latest(true).Reference()
                r.NuGet("WebSharper.UI.Next").Latest(true).Reference()
            ])

bt.Solution [
    main
    tests

    bt.NuGet.CreatePackage()
        .Configure(fun c ->
            { c with
                Title = Some "WebSharper bindings for Google.CodePrettify"
                LicenseUrl = Some "http://websharper.com/licensing"
                ProjectUrl = Some "https://github.com/intellifactory/websharper.google.codeprettify"
                Description = "Google's code-prettify for WebSharper"
                RequiresLicenseAcceptance = true })
        .Add(main)
]
|> bt.Dispatch
