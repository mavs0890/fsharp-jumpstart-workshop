namespace Tests

open System
open Xunit
open Swensen.Unquote
open fsharp_jumpstart_worskhop.Logic
open fsharp_jumpstart_workshop.Types

module ValidationTests =

    [<Fact>]
    let ``validateEmail will verify email is atleast 3 characters `` () = 
        //setup
        let invalidEmail = "ab"
        let validEmail = "a@b"
        let validEmailLong = "abcdefghijklnopqrtuvwxyz@abcdefghijklnopqrtuvwxyz"

        //execute
        let resultForInvalidEmail = Validation.validateEmail invalidEmail
        let resultForValidEmail = Validation.validateEmail validEmail
        let resultForValidEmailLong = Validation.validateEmail validEmailLong

        //verify
        test <@ not resultForInvalidEmail @>
        test <@ resultForValidEmail @>
        test <@ resultForValidEmailLong @>

    [<Fact>]
    let ``validateEmail will verify email contains at symbol`` () = 
        //setup
        let invalidEmail = "abcdefg"
        let validEmail = "abcdefg@abcdefg"

        //execute
        let resultForInvalidEmail = Validation.validateEmail invalidEmail
        let resultForValidEmail = Validation.validateEmail validEmail

        //verify
        test <@ not resultForInvalidEmail @>
        test <@ resultForValidEmail @> 

    [<Fact>]
    let ``validateEmail will verify email only contains at symbol once`` () =
        //setup
        let invalidEmail = "abc@abc@abc"
        let validEmail = "abc@abc"   

        //execute
        let resultForInvalidEmail = Validation.validateEmail invalidEmail
        let resultForValidEmail = Validation.validateEmail validEmail

        //verify
        test <@ not resultForInvalidEmail @>
        test <@ resultForValidEmail @>

    [<Fact>]
    let ``validateEmail will verify that there is text before and after the at symbol`` () =
        //setup
        let invalidEmail = "abc@"
        let invalidEmail2 = "@abc"
        let validEmail = "abc@abc"  

        //execute
        let resultForInvalidEmail = Validation.validateEmail invalidEmail
        let resultForValidEmail2 = Validation.validateEmail invalidEmail2
        let resultForValidEmail = Validation.validateEmail validEmail

        //verify
        test <@ not resultForInvalidEmail @>
        test <@ not resultForValidEmail2 @>
        test <@ resultForValidEmail @>

