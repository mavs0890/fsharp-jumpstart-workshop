namespace fsharp_jumpstart_workshop.Repositories

open Dapper
open System.Data.SQLite

module Database =

    let p (key : string) (value : 'a) = (key, box value)

    let readData<'a> (connectionString : string) statement parameters =
        use conn = new SQLiteConnection(connectionString)
        conn.Open()
        let result = conn.Query<'a>(statement, parameters)
        result

    let writeData (connectionString : string) statement parameters =
        use conn = new SQLiteConnection(connectionString)
        conn.Open()
        conn.Execute(statement, parameters) |> ignore