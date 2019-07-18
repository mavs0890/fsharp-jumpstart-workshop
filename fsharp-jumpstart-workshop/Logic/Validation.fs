namespace fsharp_jumpstart_workshop.Logic

open System
open fsharp_jumpstart_workshop.Types

module Validation = 
    let validateEmail (UnvalidatedEmail email) : Result<ValidatedEmail, EmailValidationError> = 
        match email.Length > 2 with
        | false -> Error EmailValidationError.TooShort
        | true -> 
            let splitEmail = email.Split("@")
            match (splitEmail.Length - 1) = 1 with
            | false -> Error EmailValidationError.BadAtCount
            | true ->
                match (splitEmail |> Array.filter (fun (s : string) -> s.Length = 0)).Length = 0 with
                | false -> Error EmailValidationError.NoTextBeforeOrAfterAt
                | true -> Ok (ValidatedEmail email)