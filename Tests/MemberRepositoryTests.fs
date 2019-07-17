namespace Tests

open System
open Xunit
open fsharp_jumpstart_workshop.Repositories
open Swensen.Unquote
open fsharp_jumpstart_workshop.Types

module MemberRepositoryTests =

    let private createTestMember () = {
        Id = Random().Next()
        FirstName = "FirstName_" + (Guid.NewGuid() |> string)
        LastName = "LastName_" + (Guid.NewGuid() |> string)
        Email = (Guid.NewGuid() |> string) + "@test.com"
        PlanId = "Plan_" + (Guid.NewGuid |> string) 
    }

    [<Fact>]
    let ``getAll returns all members regardless of plan`` () =
        //setup
        let member1 = createTestMember ()
        let member2 = createTestMember ()
        let member3 = createTestMember ()
        MemberRepository.save TestDependencies.writer member1
        MemberRepository.save TestDependencies.writer member2
        MemberRepository.save TestDependencies.writer member3

        //execute
        let members = MemberRepository.getAll TestDependencies.memberRepositoryReader

        //verify
        test <@ members.Length = 3 @>

        //cleanup
        MemberRepository.delete TestDependencies.writer member1.Id
        MemberRepository.delete TestDependencies.writer member2.Id
        MemberRepository.delete TestDependencies.writer member3.Id
        let noMembersLeft = MemberRepository.getAll TestDependencies.memberRepositoryReader
        test <@ noMembersLeft |> List.isEmpty @>

    [<Fact>]
    let ``findById returns none when id is not found`` () =
        //execute
        let memberNotFound = MemberRepository.findById TestDependencies.memberRepositoryReader 0

        //verify
        test <@ None = memberNotFound @>  

    [<Fact>]
    let ``findById returns returns some member when id is found`` () =
        //setup
        let member1 = createTestMember ()
        MemberRepository.save TestDependencies.writer member1
        
        //execute
        let memberFound = MemberRepository.findById TestDependencies.memberRepositoryReader member1.Id

        //verify
        test <@ Some member1 = memberFound @>

        //cleanup
        MemberRepository.delete TestDependencies.writer member1.Id
        let noMembersLeft = MemberRepository.getAll TestDependencies.memberRepositoryReader
        test <@ noMembersLeft |> List.isEmpty @>      

    [<Fact>]
    let ``save saves a new entry`` () =
        //setup
        let member1 = createTestMember ()

        //execute
        MemberRepository.save TestDependencies.writer member1

        //verify
        let foundMember = MemberRepository.findById TestDependencies.memberRepositoryReader member1.Id
        test <@ foundMember.Value = member1 @> 

        //cleanup
        MemberRepository.delete TestDependencies.writer member1.Id
        let noMembersLeft = MemberRepository.getAll TestDependencies.memberRepositoryReader
        test <@ noMembersLeft |> List.isEmpty @>   






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
