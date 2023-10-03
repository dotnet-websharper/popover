namespace WebSharper.Bindings.Popover

open WebSharper
open WebSharper.JavaScript
open WebSharper.InterfaceGenerator

module Definition =

    let ToggleEvent =
        let ToggleEventState =
            Pattern.EnumStrings "ToggleEvent.ToggleState" [
                "open"
                "closed"
            ]
        Class "ToggleEvent"
        |=> Inherits T<Dom.Event>
        |=> Nested [ToggleEventState]
        |+> Instance [
            "newState" =? ToggleEventState
            "oldState" =? ToggleEventState
        ]
    
    let PopoverState =
        Pattern.EnumStrings "Popover.PopoverState" [
            "auto"
            "manual"
        ]
    let TargetActionType =
        Pattern.EnumStrings "Popover.TargetActionType" [
            "hide"
            "show"
            "toggle"
        ]
        
    let Assembly =
        Assembly [
            Namespace "WebSharper.Popover" [
                ToggleEvent
                PopoverState

                TargetActionType
            ]
        ]

[<Sealed>]
type Extension() =
    interface IExtension with
        member ext.Assembly =
            Definition.Assembly

[<assembly: Extension(typeof<Extension>)>]
do ()
