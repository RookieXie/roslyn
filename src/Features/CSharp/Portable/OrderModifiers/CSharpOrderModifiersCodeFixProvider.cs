﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Composition;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.CodeStyle;
using Microsoft.CodeAnalysis.CSharp.Extensions;
using Microsoft.CodeAnalysis.OrderModifiers;

namespace Microsoft.CodeAnalysis.CSharp.OrderModifiers
{
    [ExportCodeFixProvider(LanguageNames.CSharp), Shared]
    internal class CSharpOrderModifiersCodeFixProvider : AbstractOrderModifiersCodeFixProvider
    {
        public CSharpOrderModifiersCodeFixProvider()
            : base(CSharpCodeStyleOptions.PreferredModifierOrder, CSharpOrderModifiersHelper.Instance)
        {
        }

        protected override SyntaxTokenList TokenList(IEnumerable<SyntaxToken> tokens)
            => SyntaxFactory.TokenList(tokens);

        protected override SyntaxTokenList GetModifiers(SyntaxNode node)
            => node.GetModifiers();

        protected override SyntaxNode WithModifiers(SyntaxNode node, SyntaxTokenList modifiers)
            => node.WithModifiers(modifiers);
    }
}