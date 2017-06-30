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
                Resource "Apollo" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-apollo.js"
                Resource "Basic" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-basic.js"
                Resource "Clj" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-clj.js"
                Resource "Css" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-css.js"
                Resource "Dart" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-dart.js"
                Resource "Erlang" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-erlang.js"
                Resource "Ex" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-ex.js"
                Resource "Go" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-go.js"
                Resource "Hs" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-hs.js"
                Resource "Lasso" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-lasso.js"
                Resource "Lisp" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-lisp.js"
                Resource "Llvm" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-llvm.js"
                Resource "Logtalk" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-logtalk.js"
                Resource "Lua" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-lua.js"
                Resource "Matlab" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-matlab.js"
                Resource "Ml" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-ml.js"
                Resource "Mumps" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-mumps.js"
                Resource "N" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-n.js"
                Resource "Pascal" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-pascal.js"
                Resource "Proto" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-proto.js"
                Resource "R" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-r.js"
                Resource "Rd" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-rd.js"
                Resource "Rust" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-rust.js"
                Resource "Scala" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-scala.js"
                Resource "Sql" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-sql.js"
                Resource "Swift" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-swift.js"
                Resource "Tcl" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-tcl.js"
                Resource "Tex" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-tex.js"
                Resource "Vb" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-vb.js"
                Resource "Vhdl" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-vhdl.js"
                Resource "Wiki" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-wiki.js"
                Resource "Xq" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-xq.js"
                Resource "Yaml" "https://cdn.rawgit.com/google/code-prettify/master/src/lang-yaml.js"

                Resource "Js" "https://cdn.rawgit.com/google/code-prettify/master/loader/run_prettify.js"
                |> AssemblyWide

                Resource "DesertCss" "https://cdn.rawgit.com/google/code-prettify/master/styles/desert.css"
                Resource "DoxyCss" "https://cdn.rawgit.com/google/code-prettify/master/styles/doxy.css"
                Resource "ObsidianCss" "https://cdn.rawgit.com/google/code-prettify/master/styles/sons-of-obsidian.css"
                Resource "SunburstCss" "https://cdn.rawgit.com/google/code-prettify/master/styles/sunburst.css"
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
