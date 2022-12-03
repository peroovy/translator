﻿using System;
using System.Collections.Immutable;

namespace Interpreter.Core.Execution.Objects.BuiltinFunctions
{
    public class InputFunction : BuiltinFunction
    {
        private const string ParameterName = "message";

        public InputFunction() 
            : base(
                "input",
                ImmutableArray.Create(ParameterName), 
                (_, scope, stack) =>
                {
                    var message = scope.Lookup(ParameterName).ToString();
                    
                    Console.Write(message);
                    var value = Console.ReadLine();
                    
                    stack.PushFunctionResult(new String(value));
                })
        {
        }
    }
}