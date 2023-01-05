﻿using Core.Execution.Objects;
using Core.Utils.Diagnostic;

namespace Repl;

public interface IPrinter
{
    void PrintError(string message);

    void PrintDiagnostic(IDiagnosticBag diagnostic);

    void PrintResult(Obj value);
}