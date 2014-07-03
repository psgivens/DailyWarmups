// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

open Example

[<EntryPoint>]
let main argv = 
    
    let l1 = List.toHeap [65; 64; 21; 89; 99; 83; 10; 82]

    let l2 = Heap.toList l1

    Heap.add 2 3 |> ignore
    printfn "%A" argv
    0 // return an integer exit code


