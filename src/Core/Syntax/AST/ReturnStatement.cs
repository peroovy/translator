﻿using Core.Execution;
using Core.Execution.DataModel.Objects;
using Core.Lexing;
using Core.Syntax.AST.Expressions;

namespace Core.Syntax.AST
{
    public class ReturnStatement : Statement
    {
        public ReturnStatement(SyntaxToken keyword, Expression expression, SyntaxToken semicolon)
        {
            Keyword = keyword;
            Expression = expression;
            Semicolon = semicolon;
        }
        
        public SyntaxToken Keyword { get; }
        
        public Expression Expression { get; }
        
        public SyntaxToken Semicolon { get; }

        public override SyntaxToken FirstChild => Keyword;

        public override SyntaxToken LastChild => Semicolon;
        
        public override Obj Accept(IExecutor executor) => executor.Execute(this);
    }
}