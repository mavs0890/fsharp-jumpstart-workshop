namespace fsharp_jumpstart_workshop.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open fsharp_jumpstart_workshop.Types
open fsharp_jumpstart_workshop.Workflows
open fsharp_jumpstart_workshop.Repositories

[<Route("api/[controller]")>]
[<ApiController>]
type MembersController () =
    inherit ControllerBase()

    [<HttpGet>]
    member this.Get() =
        let readData = PostgresConnection.readData<MemberRepository.MemberDto> "connectionString" //todo: we need to figure out what to do with this type param
        let members : Member[] =[||]
        ActionResult<Member[]>(members) 

    [<HttpGet("{id}")>]
    member this.Get(id:int) =
        let memberToReturn = { FirstName = "Marlon"; LastName = "Vilorio"; Email="marlon@test.com"; PlanId="testplanid" }
        ActionResult<Member>(memberToReturn)

    [<HttpPost>]
    member this.Post([<FromBody>] value:string) =
        ()

