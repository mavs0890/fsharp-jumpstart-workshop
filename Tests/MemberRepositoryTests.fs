namespace Tests

open System
open Xunit
open fsharp_jumpstart_workshop.Repositories

module MemberRepositoryTests =

    [<Fact>]
    let ``getAll returns all members regardless of plan`` () =
        let members = MemberRepository.getAll ()
        printfn "%i" members.Length
        Assert.True(members.Length <> 0)
