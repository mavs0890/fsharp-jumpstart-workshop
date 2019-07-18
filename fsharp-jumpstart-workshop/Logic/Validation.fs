namespace fsharp_jumpstart_workshop.Logic

open System
open fsharp_jumpstart_workshop.Types

module Validation = 
    let validateEmail (email : string) : bool =
        let splitEmail = email.Split("@")
        email.Length > 2 && (splitEmail.Length - 1) = 1 && (splitEmail |> Array.filter (fun (s : string) -> s.Length = 0)).Length = 0
