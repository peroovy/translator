﻿using Core.Utils.Text;

namespace Core.Utils.Diagnostic
{
    public struct Log
    {
        public Log(Level level, string message, Location location)
        {
            Level = level;
            Message = message;
            Location = location;
        }
        
        public Level Level { get; }
        
        public string Message { get; }

        public Location Location { get; }
    }
}