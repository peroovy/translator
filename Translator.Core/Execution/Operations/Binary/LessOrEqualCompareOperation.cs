﻿using Translator.Core.Lexing;

namespace Translator.Core.Execution.Operations.Binary
{
    public class LessOrEqualCompareOperation : BinaryOperation
    {
        protected override string OperatorMethodName => "op_LessThanOrEqual";

        protected override TokenTypes Operator => TokenTypes.LeftArrowEquals;
    }
}