﻿using Translator.Core.Evaluation;

namespace Translator.Core.Syntax.AST
{
    public class NumberExpression : Expression
    {
        public NumberExpression(double value)
        {
            Value = value;
        }
        
        public double Value { get; }

        public override object Accept(IEvaluator evaluator) => evaluator.Evaluate(this);
    }
}