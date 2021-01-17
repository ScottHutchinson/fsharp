- [ ] [MailboxProcessor still process messages(and receives) after Dispose is invoked](https://github.com/dotnet/fsharp/issues/10720)
- [ ] [Question about the test ``Dont Suggest Completely Wrong Stuff``](https://github.com/dotnet/fsharp/discussions/10823)
    * Modify FCS to suggest symbols from referenced assemblies, not just open namespaces.
    * Update the test to expect more suggestions.
    * I figure the fix should be two parts: 1. Recommend System.IO.Path. 2. Add a code fix that adds "open System.IO". But I just don't think the test does what it says it does.
    * For `Process.Start("explorer.exe", @"https://www.google.com/") |> ignore`, VS suggests `open System` instead of `open System.Diagnostics`.
    * The compiler error message suggests `Progress` instead of `System.Diagnostics.Process`.
    
