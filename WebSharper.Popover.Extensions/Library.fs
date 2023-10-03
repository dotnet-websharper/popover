namespace WebSharper.Popover

open WebSharper
open WebSharper.JavaScript


[<JavaScript;AutoOpen>]
module Extensions =
    type HTMLElement with
        [<Inline "$this.popover">]
        member this.Popover with get():PopoverState = null
        [<Inline "$this.popover = $value">]
        member this.Popover with set(value:PopoverState) = value |> ignore

        
        [<Inline "$this.hidePopover()">]
        member this.HidePopover() = ()
        
        [<Inline "$this.showPopover()">]
        member this.ShowPopover() = () 
        [<Inline "$this.togglePopover()">]
        member this.TogglePopover() = ()
        
        [<Inline "$this.ontoggle">]
        member this.OnToggle with get()  : (ToggleEvent -> unit) = ignore
        [<Inline "$this.ontoggle = $callback">]
        member this.OnToggle with set(callback:ToggleEvent -> unit) = ()
        [<Inline "$this.onbeforetoggle">]
        member this.OnBeforeToggle with get()  : (ToggleEvent -> unit) = ignore
        [<Inline "$this.onbeforetoggle = $callback">]
        member this.OnBeforeToggle with set(callback:ToggleEvent -> unit) = ()
    
    type HTMLButtonElement with
        [<Inline "$this.popoverTargetElement">]
        member this.PopoverTargetElement with get():Dom.Element = X<Dom.Element>
        [<Inline "$this.popoverTargetElement = $value">]
        member this.PopoverTargetElement with set(value:Dom.Element) = ()
    
        [<Inline "$this.popoverTargetAction">]
        member this.PopoverTargetAction with get():TargetActionType = X<TargetActionType>
        [<Inline "$this.popoverTargetAction = $value">]
        member this.PopoverTargetAction with set(value:TargetActionType) = ()


    type HTMLInputElement with
        [<Inline "$this.popoverTargetElement">]
        member this.PopoverTargetElement with get():Dom.Element = X<Dom.Element>
        [<Inline "$this.popoverTargetElement = $value">]
        member this.PopoverTargetElement with set(value:Dom.Element) = ()
    
        [<Inline "$this.popoverTargetAction">]
        member this.PopoverTargetAction with get():TargetActionType = X<TargetActionType>
        [<Inline "$this.popoverTargetAction = $value">]
        member this.PopoverTargetAction with set(value:TargetActionType) = ()


            
            
