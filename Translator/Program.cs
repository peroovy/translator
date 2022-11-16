﻿using System;
using System.Globalization;
using Ninject;
using Ninject.Extensions.Conventions;
using Translator.Core.Evaluation;
using Translator.Core.Evaluation.BinaryOperations;
using Translator.Core.Lexing;
using Translator.Core.Lexing.TokenParsers;
using Translator.Core.Logging;
using Translator.Core.Logging.Handlers;
using Translator.Core.Syntax;
using Translator.Core.Text;

namespace Translator
{
    public static class Program
    {
        private const string CoreAssembly = "Translator.Core";
        
        public static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            
            var container = ConfigureContainer();
            
            var logger = container.Get<ILogger>();
            var handler = container.Get<ILogHandler>();

            var textParser = container.Get<ITextParser>();
            var lexer = container.Get<ILexer>();
            var syntaxParser = container.Get<ISyntaxParser>();
            var evaluator = container.Get<IEvaluator>();

            while (true)
            {
                var lines = textParser.ParseLines(Console.ReadLine());
                var tokens = lexer.Tokenize(lines);
                var syntaxNode = syntaxParser.Parse(tokens);
                var value = syntaxNode.Accept(evaluator);

                if (!logger.IsEmpty)
                {
                    handler.Handle(logger);
                    logger.Reset();
                    continue;
                }
                
                Console.WriteLine(value);
            }
        }

        private static StandardKernel ConfigureContainer()
        {
            var container = new StandardKernel();

            container.Bind<ILogger>().To<Logger>().InSingletonScope();
            container.Bind<ILogHandler>().To<ConsoleHandler>().InSingletonScope();

            container.Bind<ITextParser>().To<TextParser>().InSingletonScope();
            container.Bind<ILexer>().To<Lexer>().InSingletonScope();
            container.Bind<ISyntaxParser>().To<SyntaxParser>().InSingletonScope();
            container.Bind<IEvaluator>().To<Evaluator>().InSingletonScope();
            
            container.Bind(conf => conf
                .From(CoreAssembly)
                .SelectAllClasses()
                .InheritedFrom<ITokenParser>()
                .BindAllInterfaces());
            
            container.Bind(conf => conf
                .From(CoreAssembly)
                .SelectAllClasses()
                .InheritedFrom<IBinaryOperation>()
                .BindAllInterfaces());

            return container;
        }        
    }
}