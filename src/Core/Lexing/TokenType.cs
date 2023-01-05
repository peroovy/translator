﻿namespace Core.Lexing
{
    public enum TokenType
    {
        Unknown,
        
        Number,
        Identifier,
        String,

        TrueKeyword,
        FalseKeyword,
        IfKeyword,
        ElseKeyword,
        WhileKeyword,
        ForKeyword,
        DefKeyword,
        ReturnKeyword,
        AndKeyword,
        OrKeyword,
        NullKeyword,
        BreakKeyword,
        ContinueKeyword,
        NotKeyword,

        NewLine,
        Space,
        Semicolon,
        Comma,

        Plus,
        Minus,
        Star,
        Slash,
        OpenParenthesis,
        CloseParenthesis,
        OpenBrace,
        CloseBrace,
        OpenBracket,
        CloseBracket,
        Equals,
        LeftArrow,
        RightArrow,
        LeftArrowEquals,
        RightArrowEquals,
        DoubleEquals,
        PlusEquals,
        MinusEquals,
        StarEquals,
        SlashEquals,
        PercentEquals,
        ExclamationMarkEquals,
        Percent,

        Eof
    }
}