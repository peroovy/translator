﻿using System;
using Repl.Utils;

namespace Repl.KeyHandlers;

public class BackspaceHandler : IKeyHandler
{
    public ConsoleKey Key => ConsoleKey.Backspace;
    
    public void Handle(ConsoleKeyInfo info, SubmissionDocument submissionDocument)
    {
        submissionDocument.Remove();
    }
}