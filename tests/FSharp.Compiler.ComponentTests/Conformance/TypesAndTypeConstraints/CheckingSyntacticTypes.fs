// Copyright (c) Microsoft Corporation.  All Rights Reserved.  See License.txt in the project root for license information.

namespace FSharp.Compiler.ComponentTests.Conformance.TypesAndTypeConstraints

open Xunit
open NUnit.Framework
open FSharp.Test.Utilities.Compiler
open FSharp.Test.Utilities.Xunit.Attributes

module CheckingSyntacticTypes =

    // This test was automatically generated (moved from FSharpQA suite - Conformance/TypesAndTypeConstraints/CheckingSyntacticTypes)
    //<Expects status="error" id="FS3151" span="(12,5-12,35)">This member, function or value declaration may not be declared 'inline'</Expects>
    [<Theory; Directory(__SOURCE_DIRECTORY__ + "/../../resources/tests/Conformance/TypesAndTypeConstraints/CheckingSyntacticTypes", Includes=[|"E_CannotInlineVirtualMethods1.fs"|])>]
    let ``CheckingSyntacticTypes - E_CannotInlineVirtualMethods1.fs - --test:ErrorRanges`` compilation =
        compilation
        |> asFsx
        |> withOptions ["--test:ErrorRanges"]
        |> compile
        |> shouldFail
        |> withErrorCode 3151
        |> withDiagnosticMessageMatches "This member, function or value declaration may not be declared 'inline'"
        |> ignore

    // This test was automatically generated (moved from FSharpQA suite - Conformance/TypesAndTypeConstraints/CheckingSyntacticTypes)
    //<Expects status="error" id="FS3151" span="(27,20-27,34)">This member, function or value declaration may not be declared 'inline'</Expects>
    [<Theory; Directory(__SOURCE_DIRECTORY__ + "/../../resources/tests/Conformance/TypesAndTypeConstraints/CheckingSyntacticTypes", Includes=[|"E_CannotInlineVirtualMethod2.fs"|])>]
    let ``CheckingSyntacticTypes - E_CannotInlineVirtualMethod2.fs - --test:ErrorRanges`` compilation =
        compilation
        |> asFsx
        |> withOptions ["--test:ErrorRanges"]
        |> compile
        |> shouldFail
        |> withErrorCode 3151
        |> withDiagnosticMessageMatches "This member, function or value declaration may not be declared 'inline'"
        |> ignore

    [<Test>]
    let ``CheckingSyntacticTypes - TcTyconDefnCore_CheckForCyclicStructsAndInheritance - DU with Cyclic Tuple`` () =
        FSharp """
namespace FSharpTest

    [<Struct>]
    type Tree =
        | Empty
        | Children of Tree * Tree
"""
        |> compile
        |> shouldFail
        |> withErrorCode 954
        |> ignore

    [<Test>]
    let ``CheckingSyntacticTypes - TcTyconDefnCore_CheckForCyclicStructsAndInheritance - DU with Cyclic Struct Tuple`` () =
        FSharp """
namespace FSharpTest

    [<Struct>]
    type Tree =
        | Empty
        | Children of struct (Tree * Tree)
"""
        |> compile
        |> shouldFail
        |> withErrorCode 954
        |> ignore

    [<Test>]
    let ``CheckingSyntacticTypes - TcTyconDefnCore_CheckForCyclicStructsAndInheritance - DU with Cyclic Struct Tuple of int, Tree`` () =
        FSharp """
namespace FSharpTest

    [<Struct>]
    type Tree =
        | Empty
        | Children of struct (int * Tree)
"""
        |> compile
        |> shouldFail
        |> withErrorCode 954
        |> ignore

    [<Test>]
    let ``CheckingSyntacticTypes - TcTyconDefnCore_CheckForCyclicStructsAndInheritance - DU with Non-cyclic Struct Tuple`` () =
        FSharp """
namespace FSharpTest

[<Struct>]
type Tree =
    | Empty
    | Children of struct (int * string)
"""
        |> compile
        |> shouldSucceed
        |> ignore
