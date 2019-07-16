namespace fsharp_jumpstart_workshop.Workflows

open System
open fsharp_jumpstart_workshop.Types

module MemberWorkflows =

    let getAll 
        ( getAllMembers : unit -> Member list )
        =
            getAllMembers
