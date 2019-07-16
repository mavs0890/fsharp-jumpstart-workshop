namespace fsharp_jumpstart_workshop.Repositories

open System
open System.Collections
open fsharp_jumpstart_workshop.Types
//open System.Data.SQLite
open Microsoft.Data.Sqlite
open FSharp.Data.Sql

module MemberRepository =
    let p (key : string) (value : 'a) = (key, box value)

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
                p "id" (Guid.NewGuid |> string)
                p "firstName" memberToSave.FirstName 
                p "lastName" memberToSave.LastName
                p "email" memberToSave.Email
                p "planId" memberToSave.PlanId
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
                p "id" id
            ] |> dict)
        |> Seq.tryHead
        |> Option.map toDomain


    
    //let [<Literal>] resolutionPath = @"/Users/marlon-vilorio/.nuget/packages/microsoft.data.sqlite.core/2.2.6/lib/netstandard2.0" 
    let [<Literal>] connectionString = "Data Source=" + __SOURCE_DIRECTORY__ + @"\Scripts\fsharpjumpstart.db;Version=3"
    // create a type alias with the connection string and database vendor settings
    // type sql = SqlDataProvider< 
    //               ConnectionString = connectionString,
    //               //ResolutionPath = resolutionPath,
    //               DatabaseVendor = Common.DatabaseProviderTypes.SQLITE,
    //               UseOptionTypes = true >
   // let ctx = sql.GetDataContext()

    let getAll =

        // let query = """
        //     select id, first_name as FirstName, last_name as LastName, email, plan_id as PlanId)
        //     from members;
        // """

        []