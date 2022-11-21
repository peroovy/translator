﻿using Translator.Core.Text;

namespace Translator.Core.Lexing
{
    public struct TextLocation
    {
        public TextLocation(Line line, int position)
        {
            Line = line;
            Position = position;
        }
        
        public Line Line { get; }
        
        public int Position { get; }
    }
}