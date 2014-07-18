// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.


type HeapNode = Empty | Node of int * int * HeapNode * HeapNode

module Heap = 
    let makeNode element nodeA nodeB = 
        match nodeA, nodeB with
        | Empty, Empty -> Node(element, 0, Empty, Empty)
        | _, Empty -> Node(element, 0, nodeA, Empty)
        | Empty, _ -> Node(element, 0, nodeB, Empty)
        | Node(elementA, rankA, leftA, rightA), Node(elementB, rankB, leftB, rightB) ->
        if rankA < rankB then   Node(element, rankA + 1, nodeB, nodeA)
        else                    Node(element, rankB + 1, nodeA, nodeB)

    let rec merge nodeA nodeB =
        match nodeA, nodeB with
        | Empty, Empty -> Empty
        | _, Empty -> nodeA
        | Empty, _ -> nodeB
        | Node(elementA, rankA, leftA, rightA), Node(elementB, rankB, leftB, rightB) ->
        if elementA < elementB then makeNode elementA rightA (merge leftA nodeB) 
        else                        makeNode elementB rightB (merge leftB nodeA)

    let insert element nodeA =
        merge nodeA (makeNode element Empty Empty)

    let foldBack =
        let rec recFoldBack cont f acc node =
            match node with
            | Empty -> cont acc 
            | Node(e, r, left, right) -> recFoldBack (fun list -> cont(f e list)) f acc (merge left right)  
        recFoldBack (fun list -> list)

    let toList = foldBack (fun item acc -> item::acc) []

//module List =
//    let toHeap list =
//        



[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code
