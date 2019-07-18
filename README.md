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

**First we will focus on making the tests in fsharp-jumpstart-workshop/Tests/ValidationTests.fs pass**

* Run test and verify that there is 4 failing

    `dotnet test --filter Tests.ValidationTests`

* These tests are testing a function that validates that an email is shaped correctly. You can find the function that they are testing in `fhsarp-jumpstart-workshop/Logic/Validation.fs` the function is called `validateEmail`
    * You will notice that `validateEmail` has a function called `failwith`, this is the equivalent of throwing an exception in F#. Just remove that line and add your code

* Your assignment is to make these four tests pass by implementing `validateEmail`
    * Start by just making the 1st test pass, then move on to the 2nd and so on...
    * `validateEmail` is a function that will take an email, verify that it is atleast 3 characters longs, verify that it has an @ symbol only once, and verify that there is text on both sides of the @ symbol

    * Test 1 Tips - Verify there is atleast 3 characters:
        * String in F# has the same or similar properties as C#, JavaScript, and Java

    * Test 2 Tips - Verify that the @ symbol is present:
        * Consider using `String.Split`

    * Test 3 Tips - Verify that the @ symbol only appears once:
        * If you use `String.Split` correctly in the previous test this one will likely pass as well

    * Test 4 Tips - verify that there is text on both sides of the @ symbol:
        * Remember that `String.Split` will return an array of strings try to see how you can use to help you fulfill this requirement

**Stretch assignment:**

* Run test and verify that there is 2 failing

    `dotnet test --filter Tests.MemberNameTests`


* These tests are testing a function that formats a name correctly. You can find the function that they are testing in `fhsarp-jumpstart-workshop/Logic/MemberName.fs` the function is called `format`
    * You will notice that `format` has a function called `failwith`, this is the equivalent of throwing and exception in F#. Just remove that line and add your code

    * Start by making the first test pass by implmeneting the function `capitalizeFirstLetter` . This function will take a word and capitalize the first letter

    * Second you will make the 2nd test pass by implementing format, the challenge here is to use composition in order to implement format. Please compose format by using `capitalizeFirstLetter, trim, toLower, and removeEmptySpaces`. `trim, toLower, and removeEmptySpaces` are implemented for you already. Remember the composition symbol is `>>`

    * Test 1 Tips - Verify it `capitalizeFirstLetter` capitalizes first letter
        * Use `String.Substring` and `Char.ToUpper`

    * Test 2 Tips - Verify format removes extra spaces in the name and capitalizes only first letter
        * remove name parameter and compose using all the other functions provided in the MemberName.fs file


## MODULE 2

* Run the following to move to the next branch:

    `git checkout 'start-module-2'`

**We want email errors to be more explicit on why an email is not valid. When we use these email in the future we want to make sure that only valid emails are scheduled to be sent.**

1. Create an `UnvalidatedEmail` type and a `ValidatedEmail` type in `Logic/Email.fs`.

2. Create an `EmailValidationError` in `Logic/Email.fs` type to represent the 3 types of errors that you can have: 
    * Too Short
    * Missing @
    * no text on either side of @

3. Refactor tests to verify that they return the correct result type
    * Make sure that the `validateEmail` function only takes in an `UnvalidatedEmail` and returns a `Result<validatedEmail, EmailValidationError>` 
    * Temporarily change implementation of `validateEmail` to `failwith "not-implemented"`

4. Refactor `MemberWorkflows.save` and `MemberController.post` to work with the result type.

5. Implement `validateEmail` so that all tests will pass.

## Module 3

* Create a function in `Repositories/MemberRepository.fs` to update a member email: `updateEmail`
    * Use TDD by first writing a test in `MemberRepositoryTests.fs` making it fail and then making it pass

**Stretch**

* Implement a whole vertical slice of to update email
    * Implement a `POST` endpoint in `MemberController.fs`
    * Implement an `updateEmail` workflow in `MemberWorkflows.fs`

* Verify that it works by updating the email of a member.