namespace WebSharper.Google.CodePrettifySample

open WebSharper
open WebSharper.JavaScript
open WebSharper.JQuery
open WebSharper.UI.Next
open WebSharper.UI.Next.Client
open WebSharper.UI.Next.Html
open WebSharper.UI.Next.Templating

[<JavaScript>]
module Client =

    [<SPAEntryPoint>]
    let Main () =
        WebSharper.Google.CodePrettify.PR.PrettyPrint()
        let t = WebSharper.Google.CodePrettify.PR.PrettyPrintOne("let f x y = x*y |> true |> \"dvcsdv\"") //the background won't change since the containing <pre> tag won't get the "prettyprint" class
        let res = preAttr [Attr.Class "prettyprint"] []
        let button = 
            Doc.Button "Dynamic highlighting" [] (fun () ->
                res.Dom.InnerHTML <- "let f x y = x*y |> true |> \"dvcsdv\""
                WebSharper.Google.CodePrettify.PR.PrettyPrint()
            )

        Doc.Concat [
            t |> Doc.Verbatim
            br[]
            button
            res
        ]
        |>  Doc.RunById "main"
