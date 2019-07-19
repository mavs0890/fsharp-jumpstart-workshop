namespace fsharp_jumpstart_workshop.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open fsharp_jumpstart_workshop
open fsharp_jumpstart_workshop.Types
open fsharp_jumpstart_workshop.Workflows
open fsharp_jumpstart_workshop.Repositories
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Mvc
open System.Web.Http
open Newtonsoft.Json

[<CLIMutable>]
type MemberModel = {
    FirstName : string
    LastName : string
    Email : string
    PlanId : string
}   

[<CLIMutable>]
type UpdateEmailModel = {
    Id : int
    EmailToUpdate : string
}   

[<Route("api/[controller]")>]
[<ApiController>]
type MembersController () =
    inherit ControllerBase()

    [<HttpGet>]
    member this.Get() =
        let members : Member[] = Dependencies.getAllMembersWorkflow () |> Array.ofList
        ActionResult<Member[]>(members) 

    [<HttpGet("{id}")>]
    member this.Get(id:int) : ActionResult =
        let memberFound = Dependencies.findMemberById id
       
        match memberFound with
        | Some m -> this.Ok(m) :> ActionResult
        | None -> this.NotFound() :> ActionResult

    [<HttpGet("email/{email}")>]
    member this.Get(email:string) : ActionResult =
        let memberFound = Dependencies.findMemberByEmail email
       
        match memberFound with
        | Some m -> this.Ok(m) :> ActionResult
        | None -> this.NotFound() :> ActionResult

    [<HttpPost("email")>]
    member this.Post(model:UpdateEmailModel) : ActionResult =
        Dependencies.updateEmailWorkflow model.EmailToUpdate model.Id 
       
        this.Ok() :> ActionResult  

    [<HttpPost>]
    member this.Post([<FromBody>] memberToSave:MemberModel) =
        let success = 
            Dependencies.saveMemberWorkflow 
                memberToSave.FirstName
                memberToSave.LastName
                memberToSave.Email
                memberToSave.PlanId
        match success with
        | Ok _ -> this.Ok() :> ActionResult
        | Error err -> 
            let errorMessage =  
                match err with
                | EmailValidationError.TooShort -> "Email needs to be atleast 3 characters long"
                | EmailValidationError.BadAtCount -> "Email needs to have atleast and only 1 @"
                | EmailValidationError.NoTextBeforeOrAfterAt -> "Email needs to have text before and after @"
            this.BadRequest(errorMessage) :> ActionResult




