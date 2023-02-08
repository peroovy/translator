﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using Core.Execution.DataModel.Magic;

namespace Core.Execution.DataModel.Objects
{
    public class String : Obj, IIndexReadable, ICollection
    {
        private static readonly ClassObj BaseClassObj = new(nameof(String));

        public String(string value) : base(BaseClassObj)
        {
            Value = value;
        }

        public string Value { get; }

        public override string AsDebugString => Regex.Escape($"\"{Value}\"");

        public int Length => Value.Length;

        public Obj this[int index]
        {
            get
            {
                index = NormalizeIndex(index);

                if (!IsInBound(index))
                    throw new IndexOutOfRangeException();

                return new String(ToString()[index].ToString());
            }
        }

        public override string ToString()
        {
            return Value;
        }

        private bool IsInBound(int index)
        {
            return index >= 0 && index < Value.Length;
        }

        private int NormalizeIndex(int index)
        {
            return index >= 0 ? index : Value.Length + index;
        }

        public static String __add__(String left, String right)
        {
            return new(left.Value + right.Value);
        }

        public static String __mult__(String str, Number number)
        {
            var result = new StringBuilder();

            var amount = (int)Math.Round(number.Value);
            for (var i = 0; i < amount; i++)
                result.Append(str.Value);

            return new String(result.ToString());
        }

        public static Bool __eq__(String left, String right)
        {
            return new(left.Equals(right));
        }

        public static Bool __neq__(String left, String right)
        {
            return new(!left.Equals(right));
        }

        public static Bool __lt__(String left, String right)
        {
            return new(string.CompareOrdinal(left.Value, right.Value) < 0);
        }

        public static Bool __lte__(String left, String right)
        {
            return new(string.CompareOrdinal(left.Value, right.Value) <= 0);
        }

        public static Bool __gt__(String left, String right)
        {
            return new(string.CompareOrdinal(left.Value, right.Value) > 0);
        }

        public static Bool __gte__(String left, String right)
        {
            return new(string.CompareOrdinal(left.Value, right.Value) >= 0);
        }
    }
}