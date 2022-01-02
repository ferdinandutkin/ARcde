﻿using Microsoft.Extensions.Logging;

namespace Shared.Logging
{
    public class LoggerConfiguration
    {
        public string AssemblyPath { get; set; }
        public LogLevel Level { get; set; }

        public void Deconstruct(out string path, out LogLevel level) => (path, level) = (AssemblyPath, Level);
    }
};


