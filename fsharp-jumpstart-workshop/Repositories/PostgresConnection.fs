namespace fsharp_jumpstart_workshop.Repositories

open System
open Npgsql
open Dapper

module PostgresConnection =

    let readData<'a> connectionString statement parameters =
        use conn = new NpgsqlConnection(connectionString)
        conn.Open()
        let result = conn.Query<'a>(statement, parameters)
        result