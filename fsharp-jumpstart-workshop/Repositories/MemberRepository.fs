namespace fsharp_jumpstart_workshop.Repositories

open System.Collections.Generic
open fsharp_jumpstart_workshop.Types
open FSharp.Data.Sql

module MemberRepository =

    [<CLIMutable>]
    type MemberDto = {
        Id : int
        FirstName : string
        LastName : string
        Email : string
        PlanId : string 
    }

    let toDomain (dto : MemberDto) : Member =
        {
            Id = dto.Id
            FirstName = dto.FirstName
            LastName = dto.LastName
            Email = dto.Email
            PlanId = dto.PlanId
        }

    let save writeData (memberToSave : Member) : unit =
        let query = """
            insert into members
            (id, first_name, last_name, email, plan_id)
            values
            (@id, @firstName, @lastName, @email, @planId);
        """
        writeData
            query
            ([
                Database.p "id" (memberToSave.Id)
                Database.p "firstName" memberToSave.FirstName 
                Database.p "lastName" memberToSave.LastName
                Database.p "email" memberToSave.Email
                Database.p "planId" memberToSave.PlanId
            ] |> dict)

    let delete writeData (id : int) : unit =
        let query = """
            delete from members
            where id = @id
        """
        writeData
            query
            ([
                Database.p "id" id
            ] |> dict)        

    
        
    let findById (readData: string -> obj -> IEnumerable<MemberDto>) (id : int) : Member option =

        let selectSql ="""
            select id, first_name as FirstName, last_name as LastName, email, plan_id as PlanId
            from members
            where id = @id;
            """
        readData selectSql ([Database.p "id" id] |> dict) 
        |> List.ofSeq 
        |> List.map toDomain 
        |> List.tryHead


    let getAll (readData: string -> obj -> IEnumerable<MemberDto>) : Member list =

        let selectSql = "select id, first_name as firstName, last_name as lastName, email, plan_id as planId from members;"
        let results = readData selectSql ([Database.p "" ""] |> dict)

        results 
        |> List.ofSeq
        |> List.map toDomain
