namespace Tests

open fsharp_jumpstart_workshop.Repositories
open System.Collections.Generic

module TestDependencies =
    let [<Literal>] connectionString = @"Data Source=" + __SOURCE_DIRECTORY__ + @"/Scripts/testingdb.db;Version=3"

    let memberRepositoryReader: string -> obj -> IEnumerable<MemberRepository.MemberDto> =  Database.readData connectionString

    let writer: string -> obj -> unit = Database.writeData connectionString