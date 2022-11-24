﻿using Translator.Core.Lexing;

namespace Translator.Core.Execution.Operations.Binary
{
    public class InequalityOperation : BinaryOperation
    {
        protected override string OperatorMethodName => "op_Inequality";

        protected override TokenTypes Operator => TokenTypes.ExclamationMarkEquals;
    }
}