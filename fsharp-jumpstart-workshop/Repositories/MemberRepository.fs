namespace fsharp_jumpstart_workshop.Repositories

open System
open System.Collections
open fsharp_jumpstart_workshop.Types
open System.Data.SQLite
//open Microsoft.Data.Sqlite
open FSharp.Data.Sql
open Dapper

module MemberRepository =

    [<CLIMutable>]
    type MemberDto = {
        FirstName : string
        LastName : string
        Email : string
        PlanId : string 
    }

    let toDomain (dto : MemberDto) : Member =
        {
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
                Database.p "id" (Guid.NewGuid |> string)
                Database.p "firstName" memberToSave.FirstName 
                Database.p "lastName" memberToSave.LastName
                Database.p "email" memberToSave.Email
                Database.p "planId" memberToSave.PlanId
            ] |> dict)

    
        
    let findById readData id =
        let query = """
            select id, first_name as FirstName, last_name as LastName, email, plan_id as PlanId)
            from members
            where id = @id;
        """
        readData
            query
            ([ 
                Database.p "id" id
            ] |> dict)
        |> Seq.tryHead
        |> Option.map toDomain


    
    let [<Literal>] connectionString = @"Data Source=" + __SOURCE_DIRECTORY__ + @"/Scripts/fsharpjumpstart.db;Version=3"


    let getAll () =

        let selectSql = "select id, first_name, last_name, email, plan_id from members;"
        let results = Database.readData<MemberDto> connectionString selectSql ([Database.p "" ""] |> dict)

        results |> List.ofSeq
