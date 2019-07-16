namespace Tests

open System
open Xunit
open fsharp_jumpstart_workshop.Repositories

module MemberRepositoryTests =

    [<Fact>]
    let ``getAll returns all members regardless of plan`` () =
        let members = MemberRepository.getAll
        Assert.True(members.Length <> 0)
