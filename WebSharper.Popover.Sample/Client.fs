namespace WebSharper.Popover.Sample

open WebSharper
open WebSharper.Popover
open WebSharper.JavaScript
open WebSharper.UI.Client
open WebSharper.UI.Server
open WebSharper.UI.Templating

module Templates =
    type MainTemplate = Template<"index.html", ClientLoad.FromDocument>
[<JavaScript>]
module Client =

    [<SPAEntryPoint>]
    let Main () =
            
            Templates.MainTemplate.PopoverSample()
                .PopoverInit(fun (el:Dom.Element) ->
                    let pop = As<HTMLElement>(el)
                    pop.OnToggle <- (fun evt ->
                        if evt.NewState <> evt.OldState then
                            Console.Log $"Popover state: {evt.NewState}"
                        )
                    
                    let popbtn = As<HTMLButtonElement>(JS.Document.GetElementById("open-btn"))
                    popbtn.PopoverTargetAction <- TargetActionType.Toggle
                    popbtn.PopoverTargetElement <- el
                )
                .Doc()
                |> Doc.RunById "main"
        