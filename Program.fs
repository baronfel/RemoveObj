﻿open System.IO

[<EntryPoint>]
let main _ =
    try
        let dir = Directory.GetCurrentDirectory()

        Directory.GetFiles(dir, "*.*proj", SearchOption.AllDirectories)
        |> Seq.map (fun p ->
            let p = Path.GetDirectoryName p
            Path.Combine (p, "obj")
        )
        |> Seq.iter (fun n -> Directory.Delete(n, true))

        0
    with
    | ex ->
        printfn "%s" ex.Message
        -1
