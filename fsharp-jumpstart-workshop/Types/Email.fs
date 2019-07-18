namespace fsharp_jumpstart_workshop.Types

type UnvalidatedEmail = UnvalidatedEmail of string

type ValidatedEmail = ValidatedEmail of string

type EmailValidationError = 
| TooShort
| BadAtCount
| NoTextBeforeOrAfterAt