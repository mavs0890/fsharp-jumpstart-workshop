namespace fsharp_jumpstart_workshop.Repositories

open System
open Npgsql
open Dapper
open System.Data.Sql
open System.Data.SQLite

module Database =

    let p (key : string) (value : 'a) = (key, box value)

    let readData<'a> (connectionString : string) statement parameters =
        use conn = new SQLiteConnection(connectionString)
        conn.Open()
        let result = conn.Query<'a>(statement, parameters)
        result