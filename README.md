# WebSharper Popover API Binding

This repository provides an F# [WebSharper](https://websharper.com/) binding for the [Popover API](https://developer.mozilla.org/en-US/docs/Web/API/Popover_API), enabling WebSharper applications to show and hide HTML popovers using the native browser API.

## Repository Structure

The repository consists of two main projects:

1. **Binding Project**:

   - Contains the F# WebSharper binding for the Popover API.

2. **Sample Project**:
   - Demonstrates how to use the Popover API with WebSharper syntax.
   - Includes a GitHub Pages demo: [View Demo](https://dotnet-websharper.github.io/popover/)

## Installation

To use this package in your WebSharper project, add the NuGet package:

```bash
   dotnet add package WebSharper.Popover
```

## Building

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine.

### Steps

1. Clone the repository:

   ```bash
   git clone https://github.com/dotnet-websharper/popover.git
   cd popover
   ```

2. Build the Binding Project:

   ```bash
   dotnet build WebSharper.Popover/WebSharper.Popover.fsproj
   ```

3. Build and Run the Sample Project:

   ```bash
   cd WebSharper.Popover.Sample
   dotnet build
   dotnet run
   ```

## Example Usage

Below is an example of how to use the Popover API in a WebSharper project:

```fsharp
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
```

This example demonstrates how to programmatically control the visibility of a native popover element using WebSharper and the Popover API.

## Browser Support

- The Popover API is supported in most modern browsers. Check the [compatibility table](https://developer.mozilla.org/en-US/docs/Web/API/Popover_API#browser_compatibility) on MDN for more details.
