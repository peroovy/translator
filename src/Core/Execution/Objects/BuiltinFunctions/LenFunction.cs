﻿using System.Collections.Immutable;
using Core.Execution.Objects.DataModel;

namespace Core.Execution.Objects.BuiltinFunctions
{
    public class LenFunction : BuiltinFunction
    {
        private const string ParameterName = "obj";

        public LenFunction() 
            : base(
                "len", 
                ImmutableArray.Create(ParameterName), 
                ImmutableArray<CallArgument>.Empty, 
                context =>
                {
                    var obj = context.Scope.Lookup(ParameterName);
                    
                    Obj value = obj is ICollection collection
                        ? new Number(collection.Length)
                        : new Null();
                    
                    return value;
                })
        {
        }
    }
}