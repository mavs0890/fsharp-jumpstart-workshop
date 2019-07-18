namespace fsharp_jumpstart_worskhop.Logic

open System

module MemberName = 
    let capitalizeFirstLetter (name : string) : string =
        let firstLetter = name.[0] |> Char.ToUpper
        let restOfName = name.Substring 1
        string firstLetter + restOfName

    let trim (name : string) : string =
        name.Trim()

    let toLower (name : string) : string =
        name.ToLower()

    let removeEmptySpaces (name : string) : string =
        name.Replace(" ", "")        

    let format = trim >> toLower >> removeEmptySpaces >> capitalizeFirstLetter
