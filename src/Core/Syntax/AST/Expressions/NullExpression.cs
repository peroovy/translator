﻿using Core.Execution;
using Core.Execution.Objects;
using Core.Lexing;
using Core.Utils.Text;

namespace Core.Syntax.AST.Expressions
{
    public class NullExpression : LiteralExpression
    {
        public NullExpression(SourceText sourceText, SyntaxToken token) : base(sourceText, token)
        {
        }
        
        public override Obj Accept(IExecutor executor) => executor.Execute(this);
    }
}