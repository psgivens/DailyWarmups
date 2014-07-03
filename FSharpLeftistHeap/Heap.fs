module Example 

type HeapNode = | Empty | Node of (int * int * HeapNode * HeapNode) 
    
module Heap = 
    
    let add x y = x + y
    
    let makeNode element nodeA nodeB =
        match nodeA, nodeB with
        | Node(e, r, a, b), Empty ->    Node(element, 1, nodeA, Empty)
        | Empty, Node(e, r, a, b) ->    Node(element, 1, nodeB, Empty)
        | Empty, Empty ->               Node(element, 1, Empty, Empty)
        | Node(e1, r1, a1, b1), Node(e2, r2, a2, b2) -> 
            if (r1 < r2) then           Node(element, r1 + 1, nodeB, nodeA)
            else                        Node(element, r2 + 1, nodeA, nodeB)

    let rec merge nodeA nodeB =
        match nodeA, nodeB with
        | Node(_,_,_,_), Empty ->   nodeA
        | Empty, Node(_,_,_,_) ->   nodeB
        | Empty, Empty ->           Empty
        | Node(e1, r1, a1, b1), Node(e2, r2, a2, b2) -> 
            if (e1 < e2) then       makeNode e1 a1 (merge b1 nodeB)
            else                    makeNode e2 a2 (merge b2 nodeA)  

    let insert node element =
        merge node (makeNode element Empty Empty)

    let removeHead node =
        match node with 
        | Empty -> Empty
        | Node(e, r, a1, b1) -> (merge a1 b1)

    let foldBack =     
        let rec recFoldBack cont f acc node =
            match node with
            | Empty -> cont acc
            | Node(e,r,a,b) -> recFoldBack (fun list -> cont(f e list)) f acc (merge a b)
        recFoldBack (fun list -> list) 

    let toList = foldBack (fun item acc -> item::acc) []
       
module List =
    let toHeap list =
        list |>
        List.fold (fun acc item -> Heap.insert acc item) HeapNode.Empty
            
