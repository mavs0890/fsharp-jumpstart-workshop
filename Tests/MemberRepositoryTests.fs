namespace Tests

open Xunit
open fsharp_jumpstart_workshop.Repositories
open fsharp_jumpstart_workshop
open Swensen.Unquote
open fsharp_jumpstart_workshop.Types

module MemberRepositoryTests =

    [<Fact>]
    let ``getAll returns all members regardless of plan`` () =
        let members = MemberRepository.getAll Dependencies.reader
        test <@ not (members |> List.isEmpty) @>

    [<Fact>]
    let ``findById returns none when id is not found`` () =
        let memberNotFound = MemberRepository.findById Dependencies.reader 0
        test <@ None = memberNotFound @>  

    [<Fact>]
    let ``findById returns returns some member when id is found`` () =
        let memberFound = MemberRepository.findById Dependencies.reader 3
        let expecteMember : Member = { Id = 3; FirstName = "Doug"; LastName = "West"; Email = "doug@email.com"; PlanId = "plan_1"}
        test <@ Some expecteMember = memberFound @>

    [<Fact>]
    let ``save saves a new entry`` () =
        let memberToSave = { Id = 222; FirstName = "Douglas"; LastName = "Westinson"; Email = "douglas@email.com"; PlanId = "plan_1"}
        MemberRepository.save Dependencies.writer memberToSave

        let foundMember = MemberRepository.findById Dependencies.reader 222
        MemberRepository.delete Dependencies.writer 222
        test <@ foundMember.Value = memberToSave @> 
        let fm = MemberRepository.findById Dependencies.reader 222        
        test <@ None = fm @>

    // [<Fact>]
    // let ``save will fail if entry exists already`` () =
    //     let memberToSave = { Id = 222; FirstName = "Douglas"; LastName = "Westinson"; Email = "douglas@email.com"; PlanId = "plan_1"}
    //     MemberRepository.save Dependencies.writer memberToSave

    //     let foundMember = MemberRepository.findById Dependencies.reader 222

    //     Assert.Throws(fun _ -> MemberRepository.save Dependencies.writer memberToSave) |> ignore
        
    //     MemberRepository.delete Dependencies.writer 222
    //     test <@ foundMember.Value = memberToSave @> 
    //     let fm = MemberRepository.findById Dependencies.reader 222        
    //     test <@ None = fm @>    
