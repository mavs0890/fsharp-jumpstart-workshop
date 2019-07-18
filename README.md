

## Set up

**Prerequisites:**

* VSCode: https://code.visualstudio.com/download
* NET Core 2.2: https://dotnet.microsoft.com/download/dotnet-core/2.2
* Ionide: https://marketplace.visualstudio.com/items?itemName=Ionide.Ionide-fsharp

**Clone our workshop code base:**


* Make sure your in a directory where you want to save the codebase locally
* run following the command line/terminal:

    `git clone https://github.com/mavs0890/fsharp-jumpstart-workshop.git`

**Let's make sure everything is running fine:**

* First Build the solution by running the following command:

    `dotnet build`

* Next let's run the solution: 

    `dotnet run --project fsharp-jumpstart-workshop`

    * Once it's running go to (in your browser): localhost:5000/swagger
    * You should be able to run git the following endpoints:
        * GET: `api/Members`
        * GET: `api/Members/{id}`
        * GET: `api/Members/email/{email}`

    * Try them out by using id `1` and email `tami@email.com`

* Then let's run all tests. There should be 6 passing and 6 failing tests:

    `dotnet test`

* You are now ready to start on module 1


## MODULE 1



