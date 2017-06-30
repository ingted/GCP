namespace WebSharper.Google.Codeprettify.Extension

open WebSharper
open WebSharper.InterfaceGenerator

module Definition =
    let PR = Class "PR"

    PR
        |+> Static [
            Constructor T<unit>
            "prettyPrint" => !? T<unit -> unit> * !? T<JavaScript.Dom.Node> ^-> T<unit>
            "prettyPrintOne" => T<string> * !? T<string> * !?  (T<int> + T<bool>) ^-> T<string>
        ]|> ignore


    let Assembly =
        Assembly [
            Namespace "WebSharper.Google.Codeprettify.Resources" [
                Resource "Js" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-ml.js" |> AssemblyWide
                Resource "Css" "https://cdn.rawgit.com/google/code-prettify/master/loader/run_prettify.js?skin=sons-of-obsidian&autorun=false"
                |> AssemblyWide
            ]
            Namespace "WebSharper.Google.Codeprettify" [
                PR
            ]
        ]


[<Sealed>]
type Extension() =
    interface IExtension with
        member x.Assembly = Definition.Assembly

[<assembly: Extension(typeof<Extension>)>]
do ()
