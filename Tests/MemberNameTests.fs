namespace Tests

open System
open Xunit
open Swensen.Unquote
open fsharp_jumpstart_worskhop.Logic
open fsharp_jumpstart_workshop.Types

module MemberNameTests =

    [<Fact>]
    let ``capitalizeFirstLetter will capitalize first letter of word that is passed in`` () = 
        //setup
        let longWord = "trichotillomania"
        let shortWord = "j"

        //execute
        let resultFirstName = MemberName.capitalizeFirstLetter longWord
        let resultLastName = MemberName.capitalizeFirstLetter shortWord

        //verify
        test <@ resultFirstName = "Trichotillomania" @>
        test <@ resultLastName = "J" @>

    [<Fact>]
    let ``format will ensure name is trimmed remove empty spaces and capitalized correctly`` () = 
        //setup
        let firstName = "  jack son"
        let lastName = "hendric kson    "

        //execute
        let resultFirstName = MemberName.format firstName
        let resultLastName = MemberName.format lastName

        //verify
        test <@ resultFirstName = "Jackson" @>
        test <@ resultLastName = "Hendrickson" @>



