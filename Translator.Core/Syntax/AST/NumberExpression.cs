﻿using System;
using Translator.Core.Evaluation;
using Translator.Core.Lexing;

namespace Translator.Core.Syntax.AST
{
    public class NumberExpression : Expression
    {
        public NumberExpression(SyntaxToken token)
        {
            Value = Convert.ToDouble(token.Value);
        }
        
        public double Value { get; }

        public override T Accept<T>(IVisitor<T> visitor) => visitor.Visit(this);
    }
}