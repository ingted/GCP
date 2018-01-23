namespace WebSharper.Google.CodePrettifySample

open WebSharper
open WebSharper.JavaScript
open WebSharper.JQuery
open WebSharper.UI
open WebSharper.UI.Client
open WebSharper.UI.Html
open WebSharper.UI.Templating
open WebSharper.Google.CodePrettify

[<JavaScript>]
module Client =

    [<SPAEntryPoint>]
    let Main () =
        PR.PrettyPrint()
        let t = PR.PrettyPrintOne("let f x y = x*y |> true |> \"dvcsdv\"", "ml", 5) //the background won't change since the containing <pre> tag won't get the "prettyprint" class
        let res = pre [Attr.Class "prettyprint"] []
        let button = 
            Doc.Button "Dynamic highlighting" [] (fun () ->
                res.Dom.InnerHTML <- "let f x y = x*y |> true |> \"dvcsdv\""
                PR.PrettyPrint()
            )

        Doc.Concat [
            t |> Doc.Verbatim
            br [] []
            button
            res
        ]
        |>  Doc.RunById "main"
