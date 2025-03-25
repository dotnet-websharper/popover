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

        let ToggleEventInit =
            Pattern.Config "ToggleEventInit" {
                Required = []
                Optional = [
                    "newState", ToggleEventState.Type
                    "oldState", ToggleEventState.Type
                ]
            }

        Class "ToggleEvent"
        |=> Inherits T<Dom.Event>
        |=> Nested [ToggleEventState; ToggleEventInit]
        |+> Static [
            Constructor (T<string>?eventType * !?ToggleEventInit?init)
        ]   
        |+> Instance [
            "newState" =? ToggleEventState
            "oldState" =? ToggleEventState
        ]
    
    let PopoverState =
        Pattern.EnumStrings "Popover.PopoverState" [
            "auto"
            "hint"
            "manual"
        ]

    let TargetActionType =
        Pattern.EnumStrings "Popover.TargetActionType" [
            "hide"
            "show"
            "toggle"
        ]

    let ShowPopoverOptions =
        Pattern.Config "ShowPopoverOptions" {
            Required = []
            Optional = ["source", T<HTMLElement>]
        }

    let TogglePopoverOptions =
        Pattern.Config "TogglePopoverOptions" {
            Required = []
            Optional = [
                "force", T<bool>
                "source", T<HTMLElement>
            ]
        }
        
    let Assembly =
        Assembly [
            Namespace "WebSharper.Popover" [
                ToggleEvent
                PopoverState
                ShowPopoverOptions
                TogglePopoverOptions
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
