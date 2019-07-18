namespace Tests

open System
open Xunit
open Swensen.Unquote
open fsharp_jumpstart_workshop.Logic
open fsharp_jumpstart_workshop.Types

module ValidationTests =

    [<Fact>]
    let ``validateEmail will verify email is atleast 3 characters `` () = 
        //setup
        let invalidEmail = "ab"
        let validEmail = "a@b"
        let validEmailLong = "abcdefghijklnopqrtuvwxyz@abcdefghijklnopqrtuvwxyz"

        //execute
        let resultForInvalidEmail = UnvalidatedEmail invalidEmail |> Validation.validateEmail
        let resultForValidEmail = UnvalidatedEmail validEmail |> Validation.validateEmail
        let resultForValidEmailLong = UnvalidatedEmail validEmailLong |> Validation.validateEmail

        //verify
        test <@ resultForInvalidEmail = Error EmailValidationError.TooShort @>
        test <@ resultForValidEmail = Ok (ValidatedEmail validEmail) @>
        test <@ resultForValidEmailLong = Ok (ValidatedEmail validEmailLong) @>

    [<Fact>]
    let ``validateEmail will verify email contains at symbol`` () = 
        //setup
        let invalidEmail = "abcdefg"
        let validEmail = "abcdefg@abcdefg"

        //execute
        let resultForInvalidEmail = UnvalidatedEmail invalidEmail |> Validation.validateEmail
        let resultForValidEmail = UnvalidatedEmail validEmail |> Validation.validateEmail

        //verify
        test <@ resultForInvalidEmail = Error EmailValidationError.BadAtCount @>
        test <@ resultForValidEmail = Ok (ValidatedEmail validEmail) @> 

    [<Fact>]
    let ``validateEmail will verify email only contains at symbol once`` () =
        //setup
        let invalidEmail = "abc@abc@abc"
        let validEmail = "abc@abc"   

        //execute
        let resultForInvalidEmail = UnvalidatedEmail invalidEmail |> Validation.validateEmail
        let resultForValidEmail = UnvalidatedEmail validEmail |> Validation.validateEmail

        //verify
        test <@ resultForInvalidEmail = Error EmailValidationError.BadAtCount @>
        test <@ resultForValidEmail = Ok (ValidatedEmail validEmail) @> 

    [<Fact>]
    let ``validateEmail will verify that there is text before and after the at symbol`` () =
        //setup
        let invalidEmail = "abc@"
        let invalidEmail2 = "@abc"
        let validEmail = "abc@abc"  

        //execute
        let resultForInvalidEmail = UnvalidatedEmail invalidEmail |> Validation.validateEmail
        let resultForValidEmail2 = UnvalidatedEmail invalidEmail2 |> Validation.validateEmail
        let resultForValidEmail = UnvalidatedEmail validEmail |> Validation.validateEmail

        //verify
        test <@ resultForInvalidEmail = Error EmailValidationError.NoTextBeforeOrAfterAt @>
        test <@ resultForValidEmail2 = Error EmailValidationError.NoTextBeforeOrAfterAt @>
        test <@ resultForValidEmail = Ok (ValidatedEmail validEmail)  @>
